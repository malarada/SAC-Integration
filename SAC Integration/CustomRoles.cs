using System.Collections.Generic;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using UnityEngine;



namespace SAC_Integration
{
    public class CustomRoles
    {
        [CustomRole(PlayerRoles.RoleTypeId.ClassD)]
        public class Echo16 : CustomRole // File Charlie-69
        {
            public override uint Id { get; set; } = 3;
            public override string Name { get; set; } = "Echo-16";
            public override string CustomInfo { get; set; } = "Echo-16 (Shadow Walker)";
            public override string Description { get; set; } = "Shadow Walker";
            public override int MaxHealth { get; set; } = 1000;
            public override PlayerRoles.RoleTypeId Role { get; set; } = PlayerRoles.RoleTypeId.Tutorial;
            public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
            {
                Limit = 1,
            };

            public override List<string> Inventory { get; set; } = new List<string>
            {
                "Echo-16-E1",
                "Echo-16-E2",
            };

            protected override void RoleAdded(Player player)
            {
                base.RoleAdded(player);

                Timing.CallDelayed(0.1f, () =>
                {
                    var Position = Room.Get(RoomType.LczGlassBox).Position;
                    player.Position = new Vector3(Position.x, Position.y + 1, Position.z);
                    foreach (var door in Room.Get(RoomType.LczGlassBox).Doors)
                    {
                        if (door.IsGate)
                            door.IsOpen = true;
                    }
                });
            }
        }

        [CustomRole(PlayerRoles.RoleTypeId.ClassD)]
        public class Delta02 : CustomRole
        {
            public override uint Id { get; set; } = 3;
            public override string Name { get; set; } = "Delta-02";
            public override string CustomInfo { get; set; } = "Delta-02 (Mr. Racist)";
            public override string Description { get; set; } = "Mr. Racist";
            public override int MaxHealth { get; set; } = 100;
            public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
            {
                Limit = 1,
            };
        }
    }
}
