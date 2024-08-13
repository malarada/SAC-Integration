﻿using Exiled.API.Features;
using Exiled.API.Interfaces;

using System.IO;

namespace SAC_Integration
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = true;
    }
}
