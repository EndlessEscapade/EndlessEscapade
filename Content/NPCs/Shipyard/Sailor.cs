﻿using System;
using System.Collections.Generic;
using EndlessEscapade.Common.Systems.World;
using EndlessEscapade.Utilities.Extensions;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.Biomes.CaveHouse;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EndlessEscapade.Content.NPCs.Shipyard;

[AutoloadHead]
public class Sailor : ModNPC
{
    public static event Action OnBoatRepair;

    public override void SetStaticDefaults() {
        NPCID.Sets.ExtraFramesCount[Type] = 9;
        NPCID.Sets.AttackFrameCount[Type] = 4;
        NPCID.Sets.DangerDetectRange[Type] = 700;
        NPCID.Sets.AttackType[Type] = 0;
        NPCID.Sets.AttackTime[Type] = 90;
        NPCID.Sets.AttackAverageChance[Type] = 30;
        NPCID.Sets.HatOffsetY[Type] = 4;

        var drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0) { Velocity = 1f };

        NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

        NPC.Happiness.SetNPCAffection(NPCID.Pirate, AffectionLevel.Hate);
        NPC.Happiness.SetNPCAffection(NPCID.Angler, AffectionLevel.Love);
        NPC.Happiness.SetNPCAffection(NPCID.DyeTrader, AffectionLevel.Like);
        NPC.Happiness.SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Dislike);

        NPC.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Love);
        NPC.Happiness.SetBiomeAffection<DesertBiome>(AffectionLevel.Like);
        NPC.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Hate);

        Main.npcFrameCount[Type] = 25;
    }

    public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry) {
        bestiaryEntry.Info.AddRange(
            new IBestiaryInfoElement[] { BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Ocean, new FlavorTextBestiaryInfoElement(Mod.GetLocalizationValue("Bestiary.Sailor")) }
        );
    }

    public override void SetDefaults() {
        NPC.townNPC = true;
        NPC.friendly = true;
        NPC.width = 30;
        NPC.height = 50;
        NPC.damage = 10;
        NPC.defense = 15;
        NPC.lifeMax = 500;
        NPC.knockBackResist = 0.5f;
        AnimationType = NPCID.Guide;
        NPC.HitSound = SoundID.NPCHit1;
        NPC.DeathSound = SoundID.NPCDeath1;
        NPC.aiStyle = NPCAIStyleID.Passive;
    }

    public override bool PreAI() {
        var moreThanOne = NPC.CountNPCS(Type) > 1;

        if (moreThanOne) {
            NPC.active = false;
        }

        return moreThanOne;
    }

    public override void ModifyNPCLoot(NPCLoot npcLoot) {
        npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Shipyard.SailorHat>(), 1));
    }

    public override void SetChatButtons(ref string button, ref string button2) {
        button = Language.GetTextValue("LegacyInterface.28");
        button2 = Mod.GetLocalizationValue("Buttons.Sailor.Sailing");
    }

    public override void OnChatButtonClicked(bool firstButton, ref string shopName) {
        if (firstButton) {
            shopName = "Shop";
            return;
        }

        var player = Main.LocalPlayer;

        var hasMoney = player.CanAfford(Item.buyPrice(gold: 5));

        foreach (int wood in RecipeGroup.recipeGroups[RecipeGroupID.Wood].ValidItems) {
            var hasMaterials = player.HasItemStack(ItemID.Silk, 20) && player.HasItemStack(wood, 150);

            if (!ShipyardSystem.BoatFixed && hasMaterials && hasMoney) {
                player.ConsumeItemStack(ItemID.Silk, 20);
                player.ConsumeItemStack(wood, 150);
                player.PayCurrency(Item.buyPrice(gold: 5));

                OnBoatRepair.Invoke();

                Main.npcChatText = Mod.GetLocalizationValue("Dialogue.Sailor.ShipRepairDialogue");
                return;
            }
        }

        var dialogue = ShipyardSystem.BoatFixed ? "CommonDialogue" : "PromptDialogue";
        var selected = $"Dialogue.Sailor.Ship{dialogue}{(Main.rand.NextBool() ? 0 : 1)}";

        Main.npcChatText = Mod.GetLocalizationValue(selected);
    }

    public override string GetChat() {
        var chat = new WeightedRandom<string>();

        if (!NPC.AnyNPCs(NPCID.Angler)) {
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.AnglerDialogue0"));
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.AnglerDialogue1"));
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.AnglerDialogue2"));
            return chat;
        }

        if (Main.dayTime) {
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.DayDialogue0"));
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.DayDialogue1"));
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.DayDialogue2"));
        }
        else {
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.NightDialogue0"));
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.NightDialogue1"));
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.NightDialogue2"));
        }

        if (Main.raining) {
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.RainDialogue0"));
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.RainDialogue1"));
        }

        if (Main.moonType == (int)MoonPhase.Empty) {
            chat.Add(Mod.GetLocalizationValue("Dialogue.Sailor.NewMoonDialogue"));
        }

        return chat.Get();
    }

    public override List<string> SetNPCNameList() {
        return new List<string> { "Skipper" };
    }

    public override void TownNPCAttackStrength(ref int damage, ref float knockback) {
        damage = 20;
        knockback = 4f;
    }

    public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown) {
        cooldown = 30;
        randExtraCooldown = 30;
    }

    public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
        projType = ProjectileID.Anchor;
        attackDelay = 1;
    }

    public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset) {
        multiplier = 12f;
        randomOffset = 2f;
    }

    public override bool CanTownNPCSpawn(int numTownNPCs) {
        return true;
    }

    public override bool CanGoToStatue(bool toKingStatue) {
        return true;
    }
}
