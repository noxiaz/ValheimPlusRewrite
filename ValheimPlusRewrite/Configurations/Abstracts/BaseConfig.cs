using BepInEx.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Enums;
using ValheimPlusRewrite.Configurations.Helpers;

namespace ValheimPlusRewrite.Configurations.Abstracts
{
    public abstract class BaseConfig
    {
        [LoadingOption(LoadingMode.Never)]
        public bool IsEnabled { get; set; } = false;

        [LoadingOption(LoadingMode.Never)]
        public virtual bool NeedsServerSync { get; set; } = false;

        public void GenerateConfigManager()
        {
            var type = this.GetType();
            var properties = type.GetProperties();

            var configCreator = ConfigurationHelper.ConfigManagerFile;
            var configCreatorType = configCreator.GetType();
            var bindMethod = configCreatorType.GetMethods().FirstOrDefault(x => x.Name == "Bind" && x.GetParameters().Last().ParameterType == typeof(string));
            foreach (var item in properties)
            {
                var className = type.Name.Replace("Configuration", "");
                var propertyName = item.Name;
                var propertyType = item.PropertyType;
                var bindGenericMethod = bindMethod.MakeGenericMethod(propertyType);
                var configObject = bindGenericMethod.Invoke(configCreator, new object[] { className, propertyName, item.GetValue(this), "Something" });

                var configObjectType = configObject.GetType();
                var configObjectValueProperty = configObjectType.GetProperty("Value");
                configObjectValueProperty.SetValue(configObject, item.GetValue(this));

                EventInfo eventInfo = configObject.GetType().GetEvent("SettingChanged");
                Type eventType = eventInfo.EventHandlerType;

                MethodInfo handler = this.GetType().GetMethod("HandleChangedSetting");
                Delegate del = Delegate.CreateDelegate(eventInfo.EventHandlerType, null, handler);
                eventInfo.AddEventHandler(configObject, del);
            }
        }

        public void HandleChangedSetting(object sender, EventArgs args)
        {
            var settingChangedEventArgs = args as SettingChangedEventArgs;
            var currentValue = settingChangedEventArgs.ChangedSetting.BoxedValue;
            var section = settingChangedEventArgs.ChangedSetting.Definition.Section;
            var property = settingChangedEventArgs.ChangedSetting.Definition.Key;
            Log.LogInfo($"Section: {section} Property: {property} Value: {currentValue}");
            var configurationType = Configuration.Current.GetType();
            var configurationSectionProperty = configurationType?.GetProperty(section);
            var configurationSection = configurationSectionProperty?.GetValue(Configuration.Current);
            var config = configurationSectionProperty?.PropertyType?.GetProperty(property);
            config.SetValue(configurationSection, currentValue);
            //VPlusSettings.Apply();
        }
    }

}
