using System;

using Exiled.API.Features;

namespace SAC_Integration
{
    public class SACIntegration : Plugin<Config>
    {
        public override string Name => "SAC Integration";
        public override string Prefix => "SAC";
        public override string Author => "PyroCyclone";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 11, 0);

        public override void OnEnabled()
        {
            CustomEvents.RegisterRoles();
            CustomEvents.RegisterItems();
            CustomEvents.SubscribeEvents();
        }

        public override void OnDisabled()
        {
            CustomEvents.UnregisterRoles();
            CustomEvents.UnregisterItems();
            CustomEvents.UnsubscribeEvents();
        }
    }
}
