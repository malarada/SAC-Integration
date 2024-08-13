using Exiled.CustomItems;
using Exiled.CustomRoles;
using Exiled.Events.Handlers;
using System;

namespace SAC_Integration
{
    public class CustomEvents
    {
        public static void SubscribeEvents()
        {
            Player.Spawning += EventHandler.PlayerSpawning;
        }

        public static void UnsubscribeEvents()
        {
            Player.Spawning -= EventHandler.PlayerSpawning;
        }

        public static void RegisterRoles()
        {
            CustomRoles.Echo16.RegisterRoles(false, null);
        }

        public static void UnregisterRoles()
        {
            CustomRoles.Echo16.UnregisterRoles();
        }

        public static void RegisterItems()
        {
            CustomItems.ShadowStaff.RegisterItems();
            CustomItems.InfiniteRevolver.RegisterItems();
        }

        public static void UnregisterItems()
        {
            CustomItems.ShadowStaff.UnregisterItems();
            CustomItems.InfiniteRevolver.UnregisterItems();
        }
    }
}
