﻿using ValheimPlusRewrite.Configurations.Abstracts;

namespace ValheimPlusRewrite.Configurations.Sections
{
    public class PickableConfiguration : ServerSyncConfig
    {
        public float edibles { get; internal set; } = 0;
        public float flowersAndIngredients { get; internal set; } = 0;
        public float materials { get; internal set; } = 0;
        public float valuables { get; internal set; } = 0;
        public float surtlingCores { get; internal set; } = 0;
    }
}
