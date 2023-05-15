using System.ComponentModel;
using ValheimPlusRewrite.Configurations.Abstracts;
using ValheimPlusRewrite.Configurations.Attributes;
using ValheimPlusRewrite.Configurations.Models;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class ExperienceConfiguration : ServerSyncConfig
    {
		[ConfigDescription("The modifier value for the experience gained of Swords.")]
        public ConfigModel<float> Swords { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Knives.")]
		public ConfigModel<float> Knives { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Clubs.")]
		public ConfigModel<float> Clubs { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Polearms.")]
		public ConfigModel<float> Polearms { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Spears.")]
		public ConfigModel<float> Spears { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Blocking.")]
		public ConfigModel<float> Blocking { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Axes.")]
		public ConfigModel<float> Axes { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Bows.")]
		public ConfigModel<float> Bows { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of FireMagic.")]
		public ConfigModel<float> FireMagic { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of FrostMagic.")]
		public ConfigModel<float> FrostMagic { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Unarmed.")]
		public ConfigModel<float> Unarmed { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Pickaxes.")]
		public ConfigModel<float> Pickaxes { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of WoodCutting.")]
		public ConfigModel<float> WoodCutting { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Jump.")]
		public ConfigModel<float> Jump { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Sneak.")]
		public ConfigModel<float> Sneak { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Run.")]
		public ConfigModel<float> Run { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Swim.")]
		public ConfigModel<float> Swim { get; internal set; } = 0;
		[ConfigDescription("The modifier value for the experience gained of Ride.")]
		public ConfigModel<float> Ride { get; internal set; } = 0;

	}

}
