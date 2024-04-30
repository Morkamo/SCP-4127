using System;
using Exiled.API.Features;
using Exiled.CustomItems.API;

namespace SCP_4127
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        
        public override string Author => "Star-tap";
        public override string Name => "SCP-4127";
        public override string Prefix => "SCP-4127";
        public override Version Version => new Version(1, 0, 0);
        
        public Item4127 item4127;
        
        public override void OnEnabled()
        {
            Instance = this;
            item4127 = new();
            Config.scp_4127.Register();
        }

        public override void OnDisabled()
        {
            Instance = null;
            item4127 = null;
            Config.scp_4127.Unregister();
        }
    }
}