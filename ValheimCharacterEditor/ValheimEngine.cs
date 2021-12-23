using System;
using System.Collections.Generic;

namespace ValheimCharacterEditor
{
    public class ValheimEngine // This class should only be used to "store" the reverse engineered classes from the game and other required structs like Vec3.
    {
        static public String[] BeardsUI = { "No beard", "Braided 1", "Braided 2", "Braided 3", "Braided 4", "Long 1", "Long 2", "Short 1", "Short 2", "Short 3", "Thick 1" };
        static public String[] BeardsInternal = { "BeardNone", "Beard5", "Beard6", "Beard9", "Beard10", "Beard1", "Beard2", "Beard3", "Beard4", "Beard7", "Beard8" };
        static public String[] HairsUI = { "No hair", "Braided 1", "Braided 2", "Braided 3", "Braided 4", "Long 1", "Ponytail 1", "Ponytail 2", "Ponytail 3", "Ponytail 4", "Short 1", "Short 2", "Side Swept 1", "Side Swept 2", "Side Swept 3" };
        static public String[] HairsInternal = { "HairNone", "Hair3", "Hair11", "Hair12", "Hair13", "Hair6", "Hair1", "Hair2", "Hair4", "Hair7", "Hair5", "Hair8", "Hair9", "Hair10", "Hair14" };
        static public String[] Genders = { "Male", "Female" };
        static public String[] SkillsUI = { "Swords", "Knives", "Clubs", "Polearms", "Spears", "Blocking", "Axes", "Bows", "Unarmed", "Pickaxes", "WoodCutting", "Jump", "Sneak", "Run", "Swim", "Sneak" };
        static public String NameDisallowedCharacters = "0123456789,;.:-_´¨{}][+*`^¡¿'?=)(/&¬%$·#@!|ª\\º\"'";

        static public Dictionary<string, GameObjectItemProperties> ItemProperties = new Dictionary<string, GameObjectItemProperties>() {
            { "Acorn", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Acorn) },
            { "Amber", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Amber) },
            { "AmberPearl", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.AmberPearl) },
            { "AncientSeed", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.AncientSeed) },
            { "ArmorBronzeChest", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorBronzeChest) },
            { "ArmorBronzeLegs", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorBronzeLegs) },
            { "ArmorIronChest", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorIronChest) },
            { "ArmorIronLegs", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorIronLegs) },
            { "ArmorLeatherChest", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 400, DurabilityPerLevel: 100, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorLeatherChest) },
            { "ArmorLeatherLegs", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 400, DurabilityPerLevel: 100, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorLeatherLegs) },
            { "ArmorPaddedCuirass", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorPaddedCuirass) },
            { "ArmorPaddedGreaves", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorPaddedGreaves) },
            { "ArmorRagsChest", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 2, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorRootChest) },
            { "ArmorRagsLegs", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 2, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorRootLegs) },
            { "ArmorTrollLeatherChest", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 500, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorTrollLeatherChest) },
            { "ArmorTrollLeatherLegs", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 500, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorTrollLeatherLegs) },
            { "ArmorWolfChest", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorWolfChest) },
            { "ArmorWolfLegs", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArmorWolfLegs) },
            { "ArrowBronze", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowBronze) },
            { "ArrowFire", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowFire) },
            { "ArrowFlint", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowFlint) },
            { "ArrowFrost", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowFrost) },
            { "ArrowIron", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowIron) },
            { "ArrowNeedle", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowNeedle) },
            { "ArrowObsidian", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowObsidian) },
            { "ArrowPoison", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowPoison) },
            { "ArrowSilver", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowSilver) },
            { "ArrowWood", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ArrowWood) },
            { "AtgeirBlackmetal", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 175, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AtgeirBlackmetal) },
            { "AtgeirBronze", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 125, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AtgeirBronze) },
            { "AtgeirIron", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 175, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AtgeirIron) },
            { "AxeBlackMetal", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 175, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AxeBlackMetal) },
            { "AxeBronze", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 125, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AxeBronze) },
            { "AxeFlint", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 30, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AxeFlint) },
            { "AxeIron", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 175, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AxeIron) },
            { "AxeStone", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 30, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.AxeStone) },
            { "Barley", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Barley) },
            { "BarleyFlour", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BarleyFlour) },
            { "BarleyWine", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BarleyWine) },
            { "BarleyWineBase", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BarleyWineBase) },
            { "Battleaxe", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Battleaxe) },
            { "BattleaxeCrystal", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BattleaxeCrystal) },
            { "BeechSeeds", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BeechSeeds) },
            { "BeltStrength", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BeltStrength) },
            { "BirchSeeds", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BirchSeeds) },
            { "BlackMetal", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BlackMetal) },
            { "BlackMetalScrap", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BlackMetalScrap) },
            { "BlackSoup", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BlackSoup) },
            { "Bloodbag", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Bloodbag) },
            { "BloodPudding", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BloodPudding) },
            { "Blueberries", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Blueberries) },
            { "BoarJerky", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BoarJerky) },
            { "BombOoze", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BombOoze) },
            { "BoneFragments", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.BoneFragments) },
            { "Bow", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 50, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Bow) },
            { "BowDraugrFang", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BowDraugrFang) },
            { "BowFineWood", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BowFineWood) },
            { "BowHuntsman", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BowHuntsman) },
            { "Bread", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Bread) },
            { "Bronze", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Bronze) },
            { "BronzeNails", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.BronzeNails) },
            { "CapeDeerHide", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 400, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CapeDeerHide) },
            { "CapeLinen", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 6, MaxDurability: 1500, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CapeLinen) },
            { "CapeLox", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CapeLox) },
            { "CapeOdin", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 1, MaxDurability: 1500, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CapeOdin) },
            { "CapeTest", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.CapeTest) },
            { "CapeTrollHide", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 500, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CapeTrollHide) },
            { "CapeWolf", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CapeWolf) },
            { "Carrot", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Carrot) },
            { "CarrotSeeds", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.CarrotSeeds) },
            { "CarrotSoup", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CarrotSoup) },
            { "Chain", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Chain) },
            { "Chitin", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Chitin) },
            { "Cloudberry", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Cloudberry) },
            { "Club", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Club) },
            { "Coal", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Coal) },
            { "Coins", new GameObjectItemProperties(MaxStackSize: 999, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Coins) },
            { "CookedDeerMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.CookedDeerMeat) },
            { "CookedLoxMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.CookedLoxMeat) },
            { "CookedMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.CookedMeat) },
            { "CookedWolfMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.CookedWolfMeat) },
            { "Copper", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Copper) },
            { "CopperOre", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.CopperOre) },
            { "CryptKey", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.CryptKey) },
            { "Crystal", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Crystal) },
            { "Cultivator", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Cultivator) },
            { "Dandelion", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Dandelion) },
            { "Deathsquito_sting", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Deathsquito_sting) },
            { "DeerHide", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.DeerHide) },
            { "DeerMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.DeerMeat) },
            { "DeerStew", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.DeerStew) },
            { "DragonEgg", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.DragonEgg) },
            { "DragonTear", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.DragonTear) },
            { "dragon_bite", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.dragon_bite) },
            { "dragon_claw_left", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.dragon_claw_left) },
            { "dragon_claw_right", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.dragon_claw_right) },
            { "dragon_coldbreath", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.dragon_coldbreath) },
            { "dragon_coldbreath_OLD", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.dragon_coldbreath_OLD) },
            { "dragon_spit_shotgun", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.dragon_spit_shotgun) },
            { "dragon_taunt", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.dragon_taunt) },
            { "draugr_arrow", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.draugr_arrow) },
            { "draugr_axe", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.draugr_axe) },
            { "draugr_bow", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.draugr_bow) },
            { "draugr_sword", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.draugr_sword) },
            { "Eikthyr_antler", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Eikthyr_antler) },
            { "Eikthyr_charge", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Eikthyr_charge) },
            { "Eikthyr_flegs_OLD", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Eikthyr_flegs_OLD) },
            { "Eikthyr_stomp", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Eikthyr_stomp) },
            { "ElderBark", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.ElderBark) },
            { "Entrails", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Entrails) },
            { "Eyescream", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Eyescream) },
            { "Feathers", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Feathers) },
            { "FineWood", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FineWood) },
            { "FirCone", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FirCone) },
            { "FishCooked", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FishCooked) },
            { "FishingBait", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FishingBait) },
            { "FishingRod", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FishingRod) },
            { "FishRaw", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FishRaw) },
            { "FishWraps", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.FishWraps) },
            { "Flametal", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Flametal) },
            { "FlametalOre", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FlametalOre) },
            { "Flax", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Flax) },
            { "Flint", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Flint) },
            { "FreezeGland", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.FreezeGland) },
            { "GoblinArmband", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinArmband) },
            { "GoblinBrute_ArmGuard", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinBrute_ArmGuard) },
            { "GoblinBrute_Backbones", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinBrute_Backbones) },
            { "GoblinBrute_ExecutionerCap", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinBrute_ExecutionerCap) },
            { "GoblinBrute_HipCloth", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinBrute_HipCloth) },
            { "GoblinBrute_LegBones", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinBrute_LegBones) },
            { "GoblinBrute_ShoulderGuard", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinBrute_ShoulderGuard) },
            { "GoblinBrute_Taunt", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 7, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinBrute_Taunt) },
            { "GoblinClub", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinClub) },
            { "GoblinHelmet", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinHelmet) },
            { "GoblinKing_Beam", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinKing_Beam) },
            { "GoblinKing_Meteors", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinKing_Meteors) },
            { "GoblinKing_Nova", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinKing_Nova) },
            { "GoblinKing_Taunt", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinKing_Taunt) },
            { "GoblinLegband", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinLegband) },
            { "GoblinLoin", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinLoin) },
            { "GoblinShaman_Headdress_antlers", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinShaman_Headdress_antlers) },
            { "GoblinShaman_Headdress_feathers", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinShaman_Headdress_feathers) },
            { "GoblinShaman_Staff_Bones", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinShaman_Staff_Bones) },
            { "GoblinShaman_Staff_Feathers", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinShaman_Staff_Feathers) },
            { "GoblinShoulders", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinShoulders) },
            { "GoblinSpear", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinSpear) },
            { "GoblinSword", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 7, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinSword) },
            { "GoblinTorch", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinTorch) },
            { "GoblinTotem", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GoblinTotem) },
            { "GreydwarfEye", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.GreydwarfEye) },
            { "Guck", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Guck) },
            { "Hair1", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair1) },
            { "Hair10", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair10) },
            { "Hair11", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair11) },
            { "Hair12", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair12) },
            { "Hair13", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair13) },
            { "Hair14", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair14) },
            { "Hair2", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair2) },
            { "Hair3", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair3) },
            { "Hair4", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair4) },
            { "Hair5", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair5) },
            { "Hair6", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair6) },
            { "Hair7", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair7) },
            { "Hair8", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair8) },
            { "Hair9", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Hair9) },
            { "HairNone", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.HairNone) },
            { "Hammer", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 100, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Hammer) },
            { "HardAntler", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.HardAntler) },
            { "hatchling_spit_cold", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.hatchling_spit_cold) },
            { "HealthUpgrade_Bonemass", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.HealthUpgrade_Bonemass) },
            { "HealthUpgrade_GDKing", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.HealthUpgrade_GDKing) },
            { "HelmetBronze", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetBronze) },
            { "HelmetDrake", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetDrake) },
            { "HelmetDverger", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 100, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetDverger) },
            { "HelmetIron", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetIron) },
            { "HelmetLeather", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 400, DurabilityPerLevel: 100, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetLeather) },
            { "HelmetOdin", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 300, DurabilityPerLevel: 100, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetOdin) },
            { "HelmetPadded", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetPadded) },
            { "HelmetRoot", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 800, DurabilityPerLevel: 100, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetRoot) },
            { "HelmetTrollLeather", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 500, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetTrollLeather) },
            { "HelmetYule", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 1000, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.HelmetYule) },
            { "Hoe", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 200, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Hoe) },
            { "Honey", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Honey) },
            { "Iron", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Iron) },
            { "IronNails", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.IronNails) },
            { "IronOre", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.IronOre) },
            { "IronScrap", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.IronScrap) },
            { "KnifeBlackMetal", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.KnifeBlackMetal) },
            { "KnifeButcher", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.KnifeButcher) },
            { "KnifeChitin", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.KnifeChitin) },
            { "KnifeCopper", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.KnifeCopper) },
            { "KnifeFlint", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.KnifeFlint) },
            { "KnifeSilver", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.KnifeSilver) },
            { "LeatherScraps", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.LeatherScraps) },
            { "LinenThread", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.LinenThread) },
            { "LoxMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.LoxMeat) },
            { "LoxPelt", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.LoxPelt) },
            { "LoxPie", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.LoxPie) },
            { "lox_bite", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.lox_bite) },
            { "lox_stomp", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.lox_stomp) },
            { "MaceBronze", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MaceBronze) },
            { "MaceIron", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MaceIron) },
            { "MaceNeedle", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 150, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MaceNeedle) },
            { "MaceSilver", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MaceSilver) },
            { "MeadBaseFrostResist", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadBaseFrostResist) },
            { "MeadBaseHealthMedium", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadBaseHealthMedium) },
            { "MeadBaseHealthMinor", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadBaseHealthMinor) },
            { "MeadBasePoisonResist", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadBasePoisonResist) },
            { "MeadBaseStaminaMedium", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadBaseStaminaMedium) },
            { "MeadBaseStaminaMinor", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadBaseStaminaMinor) },
            { "MeadBaseTasty", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadBaseTasty) },
            { "MeadFrostResist", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadFrostResist) },
            { "MeadHealthMedium", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadHealthMedium) },
            { "MeadHealthMinor", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadHealthMinor) },
            { "MeadPoisonResist", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadPoisonResist) },
            { "MeadStaminaMedium", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadStaminaMedium) },
            { "MeadStaminaMinor", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadStaminaMinor) },
            { "MeadTasty", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MeadTasty) },
            { "MinceMeatSauce", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.MinceMeatSauce) },
            { "Mushroom", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Mushroom) },
            { "MushroomBlue", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MushroomBlue) },
            { "MushroomYellow", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.MushroomYellow) },
            { "NeckTail", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.NeckTail) },
            { "NeckTailGrilled", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.NeckTailGrilled) },
            { "Needle", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Needle) },
            { "Obsidian", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Obsidian) },
            { "Onion", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Onion) },
            { "OnionSeeds", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.OnionSeeds) },
            { "OnionSoup", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.OnionSoup) },
            { "Ooze", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Ooze) },
            { "PickaxeAntler", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.PickaxeAntler) },
            { "PickaxeBronze", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 120, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.PickaxeBronze) },
            { "PickaxeIron", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 150, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.PickaxeIron) },
            { "PickaxeStone", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.PickaxeStone) },
            { "PineCone", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.PineCone) },
            { "PlayerUnarmed", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.PlayerUnarmed) },
            { "Pukeberries", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Pukeberries) },
            { "QueenBee", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.QueenBee) },
            { "QueensJam", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.QueensJam) },
            { "Raspberry", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Raspberry) },
            { "RawMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.RawMeat) },
            { "Resin", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Resin) },
            { "Root", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Root) },
            { "RoundLog", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.RoundLog) },
            { "Ruby", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Ruby) },
            { "LoxSaddle", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.LoxSaddle) },
            { "Sausages", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Sausages) },
            { "SerpentMeat", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.SerpentMeat) },
            { "SerpentMeatCooked", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.SerpentMeatCooked) },
            { "SerpentScale", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.SerpentScale) },
            { "SerpentStew", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SerpentStew) },
            { "SharpeningStone", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SharpeningStone) },
            { "ShieldBanded", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 4, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldBanded) },
            { "ShieldBlackmetal", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 7, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldBlackmetal) },
            { "ShieldBlackmetalTower", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 7, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldBlackmetalTower) },
            { "ShieldBronzeBuckler", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldBronzeBuckler) },
            { "ShieldIronSquare", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldIronSquare) },
            { "ShieldIronTower", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 7, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldIronTower) },
            { "ShieldKnight", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldKnight) },
            { "ShieldSerpentscale", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 0, MaxDurability: 250, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldSerpentscale) },
            { "ShieldSilver", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 7, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldSilver) },
            { "ShieldWood", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 4, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldWood) },
            { "ShieldWoodTower", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 3, MaxVariants: 7, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.ShieldWoodTower) },
            { "ShocklateSmoothie", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.ShocklateSmoothie) },
            { "Silver", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Silver) },
            { "SilverNecklace", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.SilverNecklace) },
            { "SilverOre", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.SilverOre) },
            { "skeleton_bow", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.skeleton_bow) },
            { "skeleton_mace", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.skeleton_mace) },
            { "skeleton_sword", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.skeleton_sword) },
            { "SledgeCheat", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.SledgeCheat) },
            { "SledgeIron", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SledgeIron) },
            { "SledgeStagbreaker", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SledgeStagbreaker) },
            { "SpearBronze", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SpearBronze) },
            { "SpearChitin", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 50, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SpearChitin) },
            { "SpearElderbark", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SpearElderbark) },
            { "SpearFlint", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SpearFlint) },
            { "SpearWolfFang", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SpearWolfFang) },
            { "StaminaUpgrade_Greydwarf", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.StaminaUpgrade_Greydwarf) },
            { "StaminaUpgrade_Troll", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.StaminaUpgrade_Troll) },
            { "StaminaUpgrade_Wraith", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.StaminaUpgrade_Wraith) },
            { "Stone", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Stone) },
            { "StoneGolem_clubs", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.StoneGolem_clubs) },
            { "StoneGolem_hat", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.StoneGolem_hat) },
            { "StoneGolem_spikes", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.StoneGolem_spikes) },
            { "SurtlingCore", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.SurtlingCore) },
            { "SwordBlackmetal", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SwordBlackmetal) },
            { "SwordBronze", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SwordBronze) },
            { "SwordCheat", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SwordCheat) },
            { "SwordIron", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SwordIron) },
            { "SwordIronFire", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SwordIronFire) },
            { "SwordSilver", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 4, MaxVariants: 0, MaxDurability: 200, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.SwordSilver) },
            { "Tankard", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Tankard) },
            { "TankardOdin", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.TankardOdin) },
            { "Tar", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Tar) },
            { "Thistle", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Thistle) },
            { "Thunderstone", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Thunderstone) },
            { "Tin", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Tin) },
            { "TinOre", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TinOre) },
            { "Torch", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 20, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.Torch) },
            { "TrollHide", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrollHide) },
            { "TrophyBlob", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyBlob) },
            { "TrophyBoar", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyBoar) },
            { "TrophyAbomination", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyAbomination)},
            { "TrophyBonemass", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyBonemass) },
            { "TrophyDeathsquito", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyDeathsquito) },
            { "TrophyDeer", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyDeer) },
            { "TrophyDragonQueen", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyDragonQueen) },
            { "TrophyDraugr", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyDraugr) },
            { "TrophyDraugrElite", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyDraugrElite) },
            { "TrophyDraugrFem", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyDraugrFem) },
            { "TrophyEikthyr", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyEikthyr) },
            { "TrophyFenring", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyFenring) },
            { "TrophyForestTroll", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyForestTroll) },
            { "TrophyFrostTroll", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyFrostTroll) },
            { "TrophyGoblin", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGoblin) },
            { "TrophyGoblinBrute", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGoblinBrute) },
            { "TrophyGoblinKing", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGoblinKing) },
            { "TrophyGoblinShaman", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGoblinShaman) },
            { "TrophyGreydwarf", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGreydwarf) },
            { "TrophyGreydwarfBrute", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGreydwarfBrute) },
            { "TrophyGreydwarfShaman", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGreydwarfShaman) },
            { "TrophyGrowth", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyGrowth) },
            { "TrophyHatchling", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyHatchling) },
            { "TrophyLeech", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyLeech) },
            { "TrophyLox", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyLox) },
            { "TrophyNeck", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyNeck) },
            { "TrophySerpent", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophySerpent) },
            { "TrophySGolem", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophySGolem) },
            { "TrophySkeleton", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophySkeleton) },
            { "TrophySkeletonPoison", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophySkeletonPoison) },
            { "TrophySurtling", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophySurtling) },
            { "TrophyTheElder", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyTheElder) },
            { "TrophyWolf", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyWolf) },
            { "TrophyWraith", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TrophyWraith) },
            { "Turnip", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Turnip) },
            { "TurnipSeeds", new GameObjectItemProperties(MaxStackSize: 100, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.TurnipSeeds) },
            { "TurnipStew", new GameObjectItemProperties(MaxStackSize: 10, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: true, DisplayName: ValheimCharacterEditor.Strings.Resources.TurnipStew) },
            { "VegvisirShard_Bonemass", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.VegvisirShard_Bonemass) },
            { "Wishbone", new GameObjectItemProperties(MaxStackSize: 1, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Wishbone) },
            { "WitheredBone", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.WitheredBone) },
            { "WolfFang", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.WolfFang) },
            { "WolfJerky", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.WolfJerky) },
            { "WolfMeat", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.WolfMeat) },
            { "WolfMeatSkewer", new GameObjectItemProperties(MaxStackSize: 20, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.WolfMeatSkewer) },
            { "WolfPelt", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.WolfPelt) },
            { "Wood", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.Wood) },
            { "YagluthDrop", new GameObjectItemProperties(MaxStackSize: 30, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.YagluthDrop) },
            { "YmirRemains", new GameObjectItemProperties(MaxStackSize: 50, MaxQuality: 1, MaxVariants: 0, MaxDurability: 100, DurabilityPerLevel: 50, Craftable: false, DisplayName: ValheimCharacterEditor.Strings.Resources.YmirRemains) }
        };


        public class Vector3
        {
            public float X;
            public float Y;
            public float Z;
        }

        public class Character
        {
            public string Beard = "";
            public HashSet<Biome> Biomes;
            public int Builds;
            public int Crafts;
            public int Deaths;
            public List<Food> Foods;    // digesting foods
            public string GuardianPower;
            public float GuardianPowerCooldown;
            public string Hair = "";
            public Vector3 HairColor;
            public float Hp;
            public long Id;
            public List<Item> Inventory;
            public bool IsFirstSpawn;
            public int Kills;
            public HashSet<string> KnownMaterials;
            public float MaxHp;
            public int Gender;  // 0 - male, 1 - female
            public string Name = "";
            public HashSet<string> Recipes;
            public HashSet<string> ShownTutorials;
            public List<Skill> Skills;
            public Vector3 SkinColor;
            public float Stamina;
            public string StartSeed = "";
            public Dictionary<string, int> Stations = new Dictionary<string, int>();
            public Dictionary<string, string> Texts = new Dictionary<string, string>();
            public float TimeSinceDeath;
            public HashSet<string> Trophies;
            public HashSet<string> Uniques;
            public Dictionary<long, World> WorldsData = new Dictionary<long, World>();
            public int DataVersion = 0;
            public int SkillsVersion;
            public int InventoryVersion;
            public int CharacterVersion;

            public enum Biome
            {
                None,
                Meadows,
                Swamp,
                Mountain = 4,
                BlackForest = 8,
                Plains = 16,
                AshLands = 32,
                DeepNorth = 64,
                Ocean = 256,
                Mistlands = 512,
                BiomesMax
            }

            public enum SkillName
            {
                None,
                Swords,
                Knives,
                Clubs,
                Polearms,
                Spears,
                Blocking,
                Axes,
                Bows,
                FireMagic,
                FrostMagic,
                Unarmed,
                Pickaxes,
                WoodCutting,
                Jump = 100,
                Sneak,
                Run,
                Swim,
                All = 999
            }

            public class World
            {
                public Vector3 DeathPoint = new Vector3();
                public bool HasCustomSpawnPoint;
                public bool HasDeathPoint;
                public bool HasLogoutPoint;
                public Vector3 HomePoint = new Vector3();
                public Vector3 LogoutPoint = new Vector3();
                public byte[] MapData;
                public Vector3 SpawnPoint = new Vector3();
            }

            public class Item
            {
                public long CrafterId;
                public string CrafterName;
                public float Durability;
                public bool Equipped;
                public string Name;
                public Tuple<int, int> Pos;
                public int Quality;
                public int Stack;
                public int Variant;
            }

            public class Food
            {
                public float HpLeft;
                public string Name;
                public float StaminaLeft;
                public float TimeEaten;
            }

            public class Skill
            {
                public float Level;
                public SkillName SkillName;
                public float Something;
            }

        }
        public class GameObjectItemProperties
        {
            public GameObjectItemProperties() { }
            public GameObjectItemProperties(int MaxStackSize, int MaxDurability, int DurabilityPerLevel, int MaxQuality, int MaxVariants, bool Craftable, string DisplayName)
            {

                this.MaxStackSize = MaxStackSize;
                this.MaxDurability = MaxDurability;
                this.DurabilityPerLevel = DurabilityPerLevel;
                this.MaxQuality = MaxQuality;
                this.MaxVariants = MaxVariants;
                this.Craftable = Craftable;
                this.DisplayName = DisplayName;
            }

            public int MaxStackSize;
            public int MaxDurability;
            public int DurabilityPerLevel;
            public int MaxQuality;
            public int MaxVariants;
            public bool Craftable;
            public string DisplayName;
        }
    }
}
