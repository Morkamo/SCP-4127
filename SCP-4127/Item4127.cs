using System;
using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using PluginAPI.Core;
using UnityEngine;
using MEC;

using static ItemType;

using Random = System.Random;
using evArgs = Exiled.Events.Handlers.Player;

namespace SCP_4127
{
    [CustomItem(Coin)]
    public class Item4127 : CustomItem
    {
        public override uint Id { get; set; } = 1;
        public override float Weight { get; set; } = 1f;
        public override string Name { get; set; } = "SCP-4127";
        public override string Description { get; set; } = "Its SCP-4127";
        public override SpawnProperties SpawnProperties { get; set; } = new();
        public override ItemType Type { get; set; } = Coin;
        
        [Description("The time after which, at the moment of tossing the coin, the event will happen")]
        public float timeToActivate { get; set; } = 1.6f;
        
        public override Vector3 Scale { get; set; } = new(1f, 1f, 1f);

        protected override void SubscribeEvents()
        {
            evArgs.FlippingCoin.Subscribe(OnFlippingCoin);
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            evArgs.FlippingCoin.Unsubscribe(OnFlippingCoin);
            base.UnsubscribeEvents();
        }
        
        protected override void OnDropping(DroppingItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                ev.Item.Scale = Scale;
            }
        }

        List<RoomType> HczRooms = new()
        {
            RoomType.Hcz049,
            RoomType.Hcz939,
            RoomType.HczCrossing,
            RoomType.HczCurve,
            RoomType.HczServers,
            RoomType.HczTestRoom,
            RoomType.HczTCross,
            RoomType.HczStraight
        };
        
        List<ItemType> Guns = new()
        {
            GunCrossvec,
            GunCOM15,
            GunE11SR,
            GunFSP9,
            GunLogicer,
            GunCOM18,
            GunRevolver,
            GunAK,
            GunShotgun,
            ItemType.Jailbird,
            GunFRMG0,
            GunA7,
            ParticleDisruptor
        };
        
        List<ItemType> scpItems = new()
        {
            SCP500,
            SCP207,
            SCP018,
            SCP268,
            SCP330,
            SCP2176,
            SCP244a,
            SCP244b,
            SCP1853,
            SCP1576,
            AntiSCP207
        };
        
        List<ItemType> AllowedItems = new()
        {
            KeycardJanitor,
            KeycardScientist,
            KeycardResearchCoordinator,
            KeycardZoneManager,
            KeycardGuard,
            KeycardMTFPrivate,
            KeycardContainmentEngineer,
            KeycardMTFOperative,
            KeycardMTFCaptain,
            KeycardFacilityManager,
            KeycardChaosInsurgency,
            KeycardO5,
            GunCOM15,
            SCP500,
            SCP207,
            Ammo12gauge,
            GunE11SR,
            GunCrossvec,
            Ammo556x45,
            GunFSP9,
            GunLogicer,
            GrenadeHE,
            GrenadeFlash,
            Ammo44cal,
            Ammo762x39,
            Ammo9x19,
            GunCOM18,
            SCP018,
            SCP268,
            Coin,
            ArmorLight,
            ArmorCombat,
            ArmorHeavy,
            GunRevolver,
            GunAK,
            GunShotgun,
            SCP330,
            SCP2176,
            SCP244a,
            SCP244b,
            SCP1853,
            GunCom45,
            SCP1576,
            AntiSCP207,
            GunFRMG0,
            GunA7
        };
        
        List<ItemType> Grenades = new()
        {
            GrenadeHE,
            GrenadeFlash,
        };
        
        List<ItemType> Armors = new()
        {
            ArmorLight,
            ArmorCombat,
            ArmorHeavy
        };
        
        List<AmmoType> Ammo = new()
        {
            AmmoType.Nato9,
            AmmoType.Nato556,
            AmmoType.Nato762,
            AmmoType.Ammo44Cal,
        };
        
        List<ItemType> Keycards= new()
        {
            KeycardJanitor,
            KeycardScientist,
            KeycardResearchCoordinator,
            KeycardZoneManager,
            KeycardGuard,
            KeycardMTFPrivate,
            KeycardContainmentEngineer,
            KeycardMTFOperative,
            KeycardMTFCaptain,
            KeycardFacilityManager,
            KeycardChaosInsurgency,
            KeycardO5
        };

        public IEnumerator<float> LoseStamina4127(FlippingCoinEventArgs ev)
        {
            for (int time = 33; time > 0; time--)
            {
                if (Round.IsRoundEnded)
                    yield break;

                ev.Player.Stamina = 0;
                yield return Timing.WaitForSeconds(0.33f);
            }
        }

        public void OnFlippingCoin(FlippingCoinEventArgs ev)
        {
            Timing.CallDelayed(timeToActivate, () =>
            {
                if (Check(ev.Item))
                {
                    Random rnd = new();
                    byte isPositive = (byte)rnd.Next(2);

                    if (!ev.IsTails) // [Орёл]
                    {
                        if (isPositive is 1)
                        {
                            Random cases = new();
                            byte CaseEvent = (byte)cases.Next(1, 8);

                            switch (CaseEvent)
                            {
                                case 1:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case1_lucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.Heal(ev.Player.MaxHealth);
                                    break;

                                case 2:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case2_lucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.AddAhp(50f, 50f, 0);
                                    break;

                                case 3:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case3_lucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.Heal(50f, true);
                                    break;

                                case 4:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case4_lucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.Stamina = 0;
                                    break;

                                case 5:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case5_lucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    if (ev.Player.CurrentRoom.Type is not RoomType.Pocket)
                                        return;

                                    if (!Warhead.IsDetonated)
                                    {
                                        ev.Player.Teleport(HczRooms.GetRandomValue());
                                    }
                                    else
                                    {
                                        ev.Player.Teleport(RoomType.Surface);
                                    }

                                    break;

                                case 6:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case6_lucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.DisableAllEffects(EffectCategory.Negative);
                                    break;

                                case 7:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case7_lucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");
                                    break;
                            }
                        }
                        else
                        {
                            Random cases = new();
                            byte CaseEvent = (byte)cases.Next(1, 8);

                            switch (CaseEvent)
                            {
                                case 1:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case1_unlucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.Health = 1f;
                                    break;

                                case 2:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case2_unlucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    Timing.RunCoroutine(LoseStamina4127(ev));
                                    break;

                                case 3:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case3_unlucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.Kill(DamageType.Custom);
                                    break;

                                case 4:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case4_unlucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.EnableEffect(EffectType.PocketCorroding);
                                    break;

                                case 5:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case5_unlucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.DisableAllEffects(EffectCategory.Positive);
                                    break;

                                case 6:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case6_unlucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.RemoveItem(ev.Item);
                                    break;

                                case 7:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case7_unlucky_eagle} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");
                                    break;
                            }
                        }
                    }
                    else // [Решка]
                    {
                        if (isPositive is 1)
                        {
                            Random cases = new();
                            byte CaseEvent = (byte)cases.Next(1, 9);

                            switch (CaseEvent)
                            {
                                case 1:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case1_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    if (ev.Player.IsInventoryFull)
                                    {
                                        Spawn(ev.Player.Position, Item.Create(Guns.GetRandomValue()))!.Scale =
                                            Vector3.one;
                                    }
                                    else
                                    {
                                        ev.Player.AddItem(Guns.GetRandomValue());
                                    }

                                    break;

                                case 2:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case2_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    if (ev.Player.IsInventoryFull)
                                    {
                                        Spawn(ev.Player.Position, Item.Create(scpItems.GetRandomValue()))!.Scale =
                                            Vector3.one;
                                    }
                                    else
                                    {
                                        ev.Player.AddItem(scpItems.GetRandomValue());
                                    }

                                    break;

                                case 3:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case3_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    if (ev.Player.IsInventoryFull)
                                    {
                                        Spawn(ev.Player.Position, Item.Create(Grenades.GetRandomValue()))!.Scale =
                                            Vector3.one;
                                    }
                                    else
                                    {
                                        ev.Player.AddItem(Grenades.GetRandomValue());
                                    }

                                    break;

                                case 4:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case4_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    if (!ev.Player.IsInventoryFull)
                                    {
                                        ev.Player.AddItem(ItemType.Medkit);
                                    }
                                    else
                                    {
                                        Spawn(ev.Player.Position, Item.Create(ItemType.Medkit))!.Scale = Vector3.one;
                                    }

                                    if (!ev.Player.IsInventoryFull)
                                    {
                                        ev.Player.AddItem(ItemType.Painkillers);
                                    }
                                    else
                                    {
                                        Spawn(ev.Player.Position, Item.Create(ItemType.Painkillers))!.Scale =
                                            Vector3.one;
                                    }

                                    if (!ev.Player.IsInventoryFull)
                                    {
                                        ev.Player.AddItem(ItemType.Adrenaline);
                                    }
                                    else
                                    {
                                        Spawn(ev.Player.Position, Item.Create(ItemType.Adrenaline))!.Scale =
                                            Vector3.one;
                                    }

                                    break;

                                case 5:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case5_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    if (ev.Player.IsInventoryFull)
                                    {
                                        Spawn(ev.Player.Position, Item.Create(Keycards.GetRandomValue()))!.Scale =
                                            Vector3.one;
                                    }
                                    else
                                    {
                                        ev.Player.AddItem(Keycards.GetRandomValue());
                                    }

                                    break;

                                case 6:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case6_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    Random ammoValue = new();
                                    ev.Player.AddAmmo(Ammo.GetRandomValue(), Convert.ToUInt16(ammoValue.Next(30, 91)));
                                    break;

                                case 7:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case7_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    if (ev.Player.IsInventoryFull)
                                    {
                                        Spawn(ev.Player.Position, Item.Create(Armors.GetRandomValue()))!.Scale =
                                            Vector3.one;
                                    }
                                    else
                                    {
                                        ev.Player.AddItem(Armors.GetRandomValue());
                                    }

                                    break;

                                case 8:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case8_lucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");
                                    break;
                            }
                        }
                        else
                        {
                            Random cases = new();
                            byte CaseEvent = (byte)cases.Next(1, 9);

                            switch (CaseEvent)
                            {
                                case 1:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case1_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.EnableEffect(EffectType.SeveredHands);
                                    break;

                                case 2:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case2_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.Kill(DamageType.Custom);
                                    break;

                                case 3:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case3_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.RemoveItem(ev.Item);
                                    break;

                                case 4:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case4_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.ClearInventory();
                                    break;

                                case 5:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case5_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.ThrowGrenade(ProjectileType.FragGrenade).Projectile.Rigidbody.velocity =
                                        new Vector3(0f, 0f, 0f);
                                    break;

                                case 6:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case6_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.EnableEffect(EffectType.PocketCorroding);
                                    break;

                                case 7:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case7_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");

                                    ev.Player.DropItem(ev.Item);

                                    byte EmptySlots = (byte)ev.Player.Inventory.UserInventory.Items.Count;

                                    ev.Player.ClearInventory();

                                    for (byte slots = EmptySlots; slots > 0; slots--)
                                    {
                                        ev.Player.AddItem(AllowedItems.GetRandomValue());
                                    }

                                    break;

                                case 8:
                                    ev.Player.ShowHint(
                                        $"{Plugin.Instance.Config.case8_unlucky_tails} \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n \n");
                                    break;
                            }
                        }
                    }
                }
            });
        }
    }
}