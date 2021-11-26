﻿using System;
using System.Reflection;
using SecretAdmin.Features.Console;

namespace SecretAdmin.API.Features
{
    public abstract class Module<TCfg> : IModule<TCfg> where TCfg : IModuleConfig, new()
    {
        protected Module()
        {
            Assembly = Assembly.GetCallingAssembly();
            Name ??= Assembly.GetName().Name;
            Author ??= "Unknown";
            Version ??= Assembly.GetName().Version;
        }

        private Assembly Assembly { get; }
        public virtual string Name { get; set; }
        public virtual string Author { get; set; }
        public virtual Version Version { get; set; }

        public TCfg Config { get; } = new ();

        public virtual void OnEnabled()
        {
            Log.SpectreRaw($"The module {Name} [{Version}] by {Author} has been enabled.", "lightcyan1");
        }

        public virtual void OnDisabled()
        {
            Log.SpectreRaw($"The module {Name} [{Version}] by {Author} has been disabled.", "lightcyan1");
        }

        public virtual void OnRegisteringCommands()
        {
            Program.CommandHandler.RegisterCommands(Assembly);
        }
    }
}