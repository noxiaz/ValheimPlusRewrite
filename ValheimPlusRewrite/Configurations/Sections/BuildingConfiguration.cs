﻿using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class BuildingConfiguration : ServerSyncConfig
    {
        public bool noInvalidPlacementRestriction { get; internal set; } = false;
        public bool noMysticalForcesPreventPlacementRestriction { get; internal set; } = false;
        public bool noWeatherDamage { get; internal set; } = false;
        public float maximumPlacementDistance { get; internal set; } = 8;
        public float pieceComfortRadius { get; internal set; } = 10;
        public bool alwaysDropResources { get; internal set; } = false;
        public bool alwaysDropExcludedResources { get; internal set; } = false;
        public bool enableAreaRepair { get; internal set; } = false;
        public float areaRepairRadius { get; internal set; } = 7.5f;
    }
}
