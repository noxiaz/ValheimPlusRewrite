using BepInEx;
using IniParser;
using IniParser.Model;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Utilities;

namespace ValheimPlusRewrite.Configurations.Helpers
{
    public static class ConfigurationHelper
    {
        public static object ConfigManagerFile { get; internal set; }
        public static string Path { get; set; }

        public static void SaveSettings()
        {
            var stringBuilder = new StringBuilder();
            var configuration = Configuration.Current;
            var configurationType = configuration.GetType();
            foreach (var configurationProperty in configurationType.GetProperties(BindingFlags.Instance | BindingFlags.Public).OrderBy(x => x.Name))
            {
                stringBuilder.AppendLine($"[{configurationProperty.Name}]");
                stringBuilder.AppendLine("");
                var configurationPropertyValue = configuration.GetPropertyValue(configurationProperty.Name);
                if (configurationPropertyValue == null)
                {
                    continue;
                }

                var setttingClass = configurationPropertyValue.GetType();
                var sectionDescriptions = setttingClass.GetCustomAttributes<ConfigDescription>();
                foreach (var description in sectionDescriptions)
                {
                    stringBuilder.AppendLine($"; {description.Description}");
                }

                var baseSetting = configurationPropertyValue as BaseConfig;
                stringBuilder.AppendLine($"; Change false to true to enable this section, if you set this to false the mode will not be accessible.");
                stringBuilder.AppendLine($"Enabled = {baseSetting.IsEnabled}");
                stringBuilder.AppendLine("");
                foreach (var property in setttingClass.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly))
                {
                    var propertyValue = configurationPropertyValue.GetPropertyValue(property.Name);
                    var propertyDescriptions = property.GetCustomAttributes<ConfigDescription>();
                    foreach (var description in propertyDescriptions)
                    {
                        if (!string.IsNullOrEmpty(description.Description))
                        {
                            stringBuilder.AppendLine($"; {description.Description}");
                        }
                    }

                    stringBuilder.AppendLine($"{property.Name} = {propertyValue.GetPropertyValue("Value")}");
                    stringBuilder.AppendLine("");
                }
            }

            File.WriteAllText(Path, stringBuilder.ToString());
        }

        /// <summary>
        /// Loading settings from configuration file
        /// </summary>
        /// <returns>True/False</returns>
        public static bool LoadSettings()
        {
            try
            {
                if (!File.Exists(Path))
                {
                    Log.LogInfo($"Loading default configuration - Missing File");
                    GenerateConfigFile();
                    return true;
                }
                else
                {
                    Log.LogInfo($"Loading config file at: '{Path}'");
                    FileIniDataParser parser = new FileIniDataParser();
                    IniData configdata = parser.ReadFile(Path);
                    Configuration.Current = ReadFromFile(Path);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.LogError($"Could not load config file: {ex}");
                return false;
            }
        }

        /// <summary>
        /// Loading configuration from a stream
        /// </summary>
        /// <param name="iniStream">remote configuration stream</param>
        /// <returns>new configuration</returns>
        public static Configuration ReadFromStream(Stream iniStream)
        {
            IniData iniData;
            using (StreamReader iniReader = new StreamReader(iniStream))
            {
                FileIniDataParser parser = new FileIniDataParser();
                iniData = parser.ReadData(iniReader);
            }

            return ParseIni<Configuration>(iniData);
        }

        /// <summary>
        /// Loading configuration from a file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>new configuration</returns>
        public static Configuration ReadFromFile(string filePath)
        {
            var parser = new FileIniDataParser();
            var fileData = File.ReadAllText(filePath);
            Regex regex = new Regex("^#", RegexOptions.Multiline);
            fileData = regex.Replace(fileData, ";");
            IniData data;
            using (var memoryStream = StringToStream(fileData))
            {
                data = parser.ReadData(memoryStream);
            }

            return ParseIni<Configuration>(data);
        }

        public static Configuration DefaultConfigurtation()
        {
            var configuration = new Configuration();
            var configurationType = configuration.GetType();
            foreach (var configurationProperty in configurationType.GetProperties(BindingFlags.Instance | BindingFlags.Public).OrderBy(x => x.Name))
            {
                var classInfo = configurationType.GetProperty(configurationProperty.Name);
                var classType = classInfo.PropertyType;
                var instance = Activator.CreateInstance(classType);
                classInfo.SetValue(configuration, instance);
            }

            return configuration;
        }

        private static T ParseIni<T>(IniData iniData) where T : new()
        {
            var genericType = typeof(T);
            var obj = new T();
            foreach (var sectionData in iniData.Sections)
            {
                var classInfo = genericType.GetProperty(sectionData.SectionName);
                var classType = classInfo.PropertyType;
                var instance = Activator.CreateInstance(classType);
                classInfo.SetValue(obj, instance);
                if (sectionData.Keys["enabled"] == "false")
                {
                    Log.LogDebug($"Configuration - Section: {classType.Name} DISABLED - Loading Default");
                }
                else
                {
                    SetConfiguration(classType, instance, "IsEnabled", true);
                    foreach (var key in sectionData.Keys)
                    {
                        if (key.KeyName == "enabled")
                        {
                            continue;
                        }

                        SetConfiguration(classType, instance, key.KeyName, key.Value);
                    }
                }
            }

            return obj;
        }

        private static void SetConfiguration(Type classType, object instance, string keyName, object keyValue)
        {
            keyName = Char.ToUpper(keyName[0]) + keyName.Substring(1);
            PropertyInfo propertyInfo = classType.GetProperty(keyName);
            if (propertyInfo == null)
            {
                Log.LogError($"Configuration Wrong PropertyName - Section: {classType.Name} Key: {keyName} Value: {keyValue}");
            }
            else if (propertyInfo.PropertyType.IsGenericType)
            {
                Log.LogDebug($"Configuration - Section: {classType.Name} Key: {keyName} Value: {keyValue}");
                var model = propertyInfo.GetValue(instance);
                var valueProperty = model.GetType().GetProperty("Value");
                var genericType = propertyInfo.PropertyType.GenericTypeArguments[0];
                var value = ConvertValueType(keyValue, genericType);
                valueProperty.SetValue(model, Convert.ChangeType(value, genericType), null);
                propertyInfo.SetValue(instance, model, null);
            }
            else
            {
                var value = ConvertValueType(keyValue, propertyInfo.PropertyType);
                propertyInfo.SetValue(instance, Convert.ChangeType(value, propertyInfo.PropertyType), null);
            }
        }

        private static object ConvertValueType(object keyValue, Type type)
        {
            object value;
            if (type == typeof(KeyCode))
            {
                value = (KeyCode)Enum.Parse(typeof(KeyCode), keyValue as string);
            }
            else
            {
                value = keyValue;
            }

            return value;
        }

        private static StreamReader StringToStream(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return new StreamReader(stream);
        }

        private static void GenerateConfigFile()
        {
            Configuration.Current = DefaultConfigurtation();
            SaveSettings();
        }
    }
}
