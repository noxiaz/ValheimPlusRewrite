using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ExperienceConfiguration : ServerSyncConfig
    {
        public ConfigModel<float> Swords { get; internal set; } = 0;
		public ConfigModel<float> Knives { get; internal set; } = 0;
		public ConfigModel<float> Clubs { get; internal set; } = 0;
		public ConfigModel<float> Polearms { get; internal set; } = 0;
		public ConfigModel<float> Spears { get; internal set; } = 0;
		public ConfigModel<float> Blocking { get; internal set; } = 0;
		public ConfigModel<float> Axes { get; internal set; } = 0;
		public ConfigModel<float> Bows { get; internal set; } = 0;
		public ConfigModel<float> FireMagic { get; internal set; } = 0;
		public ConfigModel<float> FrostMagic { get; internal set; } = 0;
		public ConfigModel<float> Unarmed { get; internal set; } = 0;
		public ConfigModel<float> Pickaxes { get; internal set; } = 0;
		public ConfigModel<float> WoodCutting { get; internal set; } = 0;
		public ConfigModel<float> Jump { get; internal set; } = 0;
		public ConfigModel<float> Sneak { get; internal set; } = 0;
		public ConfigModel<float> Run { get; internal set; } = 0;
		public ConfigModel<float> Swim { get; internal set; } = 0;
		public ConfigModel<float> Ride { get; internal set; } = 0;

	}

}
