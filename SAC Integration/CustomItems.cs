using Exiled.API.Features.Spawn;
using Exiled.API.Features.Attributes;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using Exiled.API.Enums;
using Exiled.API.Features;

namespace SAC_Integration
{
    public class CustomItems
    {
        [CustomItem(ItemType.Flashlight)]
        public class ShadowStaff : CustomItem
        {
            public override uint Id { get; set; } = 1;
            public override string Name { get; set; } = "Echo-16-E1";
            public override string Description { get; set; } = "Shadow Staff";
            public override float Weight { get; set; } = 1f;
            public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
            {
            };

            protected override void SubscribeEvents()
            {
                Exiled.Events.Handlers.Player.ChangedItem += ChangedItem;
                Exiled.Events.Handlers.Player.TogglingFlashlight += UsedItem;
                base.SubscribeEvents();
            }

            protected override void UnsubscribeEvents()
            {
                Exiled.Events.Handlers.Player.ChangedItem -= ChangedItem;
                Exiled.Events.Handlers.Player.TogglingFlashlight -= UsedItem;
                base.UnsubscribeEvents();
            }

            private void ChangedItem(ChangedItemEventArgs ev)
            {
                if (!Check(ev.Player.CurrentItem))
                    return;

                if (ev.Player.GetEffect(EffectType.Ghostly).Intensity == 0)
                    ev.Player.DisableEffect(EffectType.Ghostly);
            }

            private void UsedItem(TogglingFlashlightEventArgs ev)
            {
                if (!Check(ev.Player.CurrentItem))
                    return;

                if (ev.Player.GetEffect(EffectType.Ghostly).Intensity == 0)
                {
                    ev.Player.EnableEffect(EffectType.Invisible);
                    ev.Player.EnableEffect(EffectType.Ghostly);
                }
                else
                {
                    ev.Player.DisableEffect(EffectType.Invisible);
                    ev.Player.DisableEffect(EffectType.Ghostly);
                }
            }
        }

        [CustomItem(ItemType.GunRevolver)]
        public class InfiniteRevolver : CustomItem
        {
            public override uint Id { get; set; } = 2;
            public override string Name { get; set; } = "Echo-16-E2";
            public override string Description { get; set; } = "Infinite Revolver";
            public override float Weight { get; set; } = 1f;
            public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
            {
            };

            protected override void SubscribeEvents()
            {
                Exiled.Events.Handlers.Player.Shooting += ShootingWeapon;
                base.SubscribeEvents();
            }

            protected override void UnsubscribeEvents()
            {
                Exiled.Events.Handlers.Player.Shooting -= ShootingWeapon;
                base.UnsubscribeEvents();
            }

            private void ShootingWeapon(ShootingEventArgs ev)
            {
                if (!Check(ev.Player.CurrentItem))
                    return;

                ev.Firearm.Ammo = (byte)(ev.Firearm.MaxAmmo + (byte)1);
            }
        }

        [CustomItem(ItemType.SCP500)]
        public class Echo02 : CustomItem
        {
            public override uint Id { get; set; } = 3;
            public override string Name { get; set; } = "Echo-02";
            public override string Description { get; set; } = "The Pills";
            public override float Weight { get; set; } = 1f;
            public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties()
            {
            };

            protected override void SubscribeEvents()
            {
                Exiled.Events.Handlers.Player.UsedItem += ItemUsed;
                base.SubscribeEvents();
            }

            protected override void UnsubscribeEvents()
            {
                Exiled.Events.Handlers.Player.UsedItem -= ItemUsed;
                base.UnsubscribeEvents();
            }

            private void ItemUsed(UsedItemEventArgs ev)
            {
                if (!Check(ev.Player.CurrentItem))
                    return;
            }
        }
    }
}
