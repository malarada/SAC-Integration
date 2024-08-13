using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.CustomRoles.API.Features;

namespace SAC_Integration
{
    public class EventHandler
    {
        internal static void PlayerSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.Role == PlayerRoles.RoleTypeId.ClassD)
            {
                CustomRole.Get("Echo-16").AddRole(ev.Player);
            }
        }
    }
}
