using System;
using System.Reflection;
using UnityModManagerNet;
using HarmonyLib;

namespace SolastaNewMerchantTest2
{
    public class Main
    {
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(string msg)
        {
            if (logger != null) logger.Log(msg);
        }
        public static void Error(Exception ex)
        {
            if (logger != null) logger.Error(ex.ToString());
        }
        public static void Error(string msg)
        {
            if (logger != null) logger.Error(msg);
        }

        public static UnityModManager.ModEntry.ModLogger logger;
        public static bool enabled;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            try
            {
                logger = modEntry.Logger;
                var harmony = new Harmony(modEntry.Info.Id);
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Error(ex);
                throw;
            }
            return true;
        }
        [HarmonyPatch(typeof(MainMenuScreen), "RuntimeLoaded")]
        static class MainMenuScreen_RuntimeLoaded_Patch
        {
            static void Postfix()
            {
                try
                {
                    // Merchants
                    var gorims = DatabaseRepository.GetDatabase<MerchantDefinition>().GetElement("Store_Merchant_Gorim_Ironsoot_Cyflen_GeneralStore");
                    var summers = DatabaseRepository.GetDatabase<MerchantDefinition>().GetElement("Store_Merchant_Antiquarians_Halman_Summer");
                    var hugos = DatabaseRepository.GetDatabase<MerchantDefinition>().GetElement("Store_Merchant_Hugo_Requer_Cyflen_Potions");

                    // Roasry and 1+ and foods and others
                    var rosa = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("EnchantingTool");
                    var GS1p = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Greatsword+1");
                    var LS1p = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Longsword+1");
                    var foodr = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Food_Ration");
                    var hcb = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("HeavyCrossbow");
                    var mauls = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Maul");
                    var rosastock = new StockUnitDescription();
                    var GS1pstock = new StockUnitDescription();
                    var LS1pstock = new StockUnitDescription();
                    var foodrstock = new StockUnitDescription();
                    var hcbstock = new StockUnitDescription();
                    var maulsstock = new StockUnitDescription();

                    // Primed items
                    var pBattleaxe = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Battleaxe");
                    var pBreastplate = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Breastplate");
                    var pChainmail = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed ChainMail");
                    var pChainshirt = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed ChainShirt");
                    var pDagger = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Dagger");
                    var pGreataxe = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Greataxe");
                    var pGreatsword = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Greatsword");
                    var pHalfplate = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed HalfPlate");
                    var pLeatherarmor = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Leather Armor");
                    var pLongbow = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Longbow");
                    var pMace = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Mace");
                    var pMorningstar = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Morningstar");
                    var pPlate = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Plate");
                    var pRapier = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Rapier");
                    var pScalemail = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed ScaleMail");
                    var pScimitar = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Scimitar");
                    var pShortbow = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Shortbow");
                    var pShortsword = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed Shortsword");
                    var pLongsword = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Primed_Longsword");
                    var pBattleaxestock = new StockUnitDescription();
                    var pBreastplatestock = new StockUnitDescription();
                    var pChainmailstock = new StockUnitDescription();
                    var pChainshirtstock = new StockUnitDescription();
                    var pDaggerstock = new StockUnitDescription();
                    var pGreataxestock = new StockUnitDescription();
                    var pGreatswordstock = new StockUnitDescription();
                    var pHalfplatestock = new StockUnitDescription();
                    var pLeatherarmorstock = new StockUnitDescription();
                    var pLongbowstock = new StockUnitDescription();
                    var pMacestock = new StockUnitDescription();
                    var pMorningstarstock = new StockUnitDescription();
                    var pPlatestock = new StockUnitDescription();
                    var pRapierstock = new StockUnitDescription();
                    var pScalemailstock = new StockUnitDescription();
                    var pScimitarstock = new StockUnitDescription();
                    var pShortbowstock = new StockUnitDescription();
                    var pShortswordstock = new StockUnitDescription();
                    var pLongswordstock = new StockUnitDescription();

                    // Crafting Manuals, items
                    var CME_BattleAxe_of_Acuteness = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_BattleAxe_of_Acuteness");
                    var CME_BattleAxe_of_Sharpness = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_BattleAxe_of_Sharpness");
                    var CME_BattleAxe_Punisher = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_BattleAxe_Punisher");
                    var CME_Greataxe_Of_Sharpness = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Greataxe_Of_Sharpness");
                    var CME_Greataxe_Stormblade = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Greataxe_Stormblade");
                    var CME_Longbow_Lightbringer = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Longbow_Lightbringer");
                    var CME_Longbow_Of_Accuracy = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Longbow_Of_Accuracy");
                    var CME_Longbow_Stormbow = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Longbow_Stormbow");
                    var CME_Mace_Of_Acuteness = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Mace_Of_Acuteness");
                    var CME_Mace_Of_Smashing = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Mace_Of_Smashing");
                    var CME_Morningstar_Bearclaw = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Morningstar_Bearclaw");
                    var CME_Morningstar_Of_Power = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Morningstar_Of_Power");
                    var CME_Shortbow_Medusa = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Shortbow_Medusa");
                    var CME_Shortbow_Of_Accuracy = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Shortbow_Of_Accuracy");
                    var CME_Shortbow_Of_Sharpshooting = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Shortbow_Of_Sharpshooting");
                    var CME_Shortsword_Lightbringer = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Shortsword_Lightbringer");
                    var CME_Shortsword_Of_Acuteness = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Shortsword_Of_Acuteness");
                    var CME_Shortsword_Of_Sharpness = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Shortsword_Of_Sharpness");
                    var CME_Shortsword_Whiteburn = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("CraftingManual_Enchant_Shortsword_Whiteburn");
                    var CME_BattleAxe_of_Acutenessstock = new StockUnitDescription();
                    var CME_BattleAxe_of_Sharpnessstock = new StockUnitDescription();
                    var CME_BattleAxe_Punisherstock = new StockUnitDescription();
                    var CME_Greataxe_Of_Sharpnessstock = new StockUnitDescription();
                    var CME_Greataxe_Stormbladestock = new StockUnitDescription();
                    var CME_Longbow_Lightbringerstock = new StockUnitDescription();
                    var CME_Longbow_Of_Accuracystock = new StockUnitDescription();
                    var CME_Longbow_Stormbowstock = new StockUnitDescription();
                    var CME_Mace_Of_Acutenessstock = new StockUnitDescription();
                    var CME_Mace_Of_Smashingstock = new StockUnitDescription();
                    var CME_Morningstar_Bearclawstock = new StockUnitDescription();
                    var CME_Morningstar_Of_Powerstock = new StockUnitDescription();
                    var CME_Shortbow_Medusastock = new StockUnitDescription();
                    var CME_Shortbow_Of_Accuracystock = new StockUnitDescription();
                    var CME_Shortbow_Of_Sharpshootingstock = new StockUnitDescription();
                    var CME_Shortsword_Lightbringerstock = new StockUnitDescription();
                    var CME_Shortsword_Of_Acutenessstock = new StockUnitDescription();
                    var CME_Shortsword_Of_Sharpnessstock = new StockUnitDescription();
                    var CME_Shortsword_Whiteburnstock = new StockUnitDescription();

                    // Crafting ingredients
                    var IE_Blood_Gem = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Blood_Gem");
                    var IE_Blood_Of_Solasta = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Blood_Of_Solasta");
                    var IE_Cloud_Diamond = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Cloud_Diamond");
                    var IE_Crystal_Of_Winter = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Crystal_Of_Winter");
                    var IE_Diamond_Of_Elai = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Diamond_Of_Elai");
                    var IE_Doom_Gem = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Doom_Gem");
                    var IE_Heartstone = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Heartstone");
                    var IE_LifeStone = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_LifeStone");
                    var IE_Medusa_Coral = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Medusa_Coral");
                    var IE_MithralStone = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_MithralStone");
                    var IE_Oil_Of_Acuteness = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Oil_Of_Acuteness");
                    var IE_PurpleAmber = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_PurpleAmber");
                    var IE_Queen_Venom = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Queen_Venom");
                    var IE_Shard_Of_Fire = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Shard_Of_Fire");
                    var IE_Shard_Of_Ice = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Shard_Of_Ice");
                    var IE_Slavestone = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Slavestone");
                    var IE_Soul_Gem = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Soul_Gem");
                    var IE_Stardust = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Ingredient_Enchant_Stardust");
                    var IE_Blood_Gemstock = new StockUnitDescription();
                    var IE_Blood_Of_Solastastock = new StockUnitDescription();
                    var IE_Cloud_Diamondstock = new StockUnitDescription();
                    var IE_Crystal_Of_Winterstock = new StockUnitDescription();
                    var IE_Diamond_Of_Elaistock = new StockUnitDescription();
                    var IE_Doom_Gemstock = new StockUnitDescription();
                    var IE_Heartstonestock = new StockUnitDescription();
                    var IE_LifeStonestock = new StockUnitDescription();
                    var IE_Medusa_Coralstock = new StockUnitDescription();
                    var IE_MithralStonestock = new StockUnitDescription();
                    var IE_Oil_Of_Acutenessstock = new StockUnitDescription();
                    var IE_PurpleAmberstock = new StockUnitDescription();
                    var IE_Queen_Venomstock = new StockUnitDescription();
                    var IE_Shard_Of_Firestock = new StockUnitDescription();
                    var IE_Shard_Of_Icestock = new StockUnitDescription();
                    var IE_Slavestonestock = new StockUnitDescription();
                    var IE_Soul_Gemstock = new StockUnitDescription();
                    var IE_Starduststock = new StockUnitDescription();

                    // Potions
                    var pspd = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("PotionOfSpeed");
                    var phrsm = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("PotionOfHeroism");
                    var pfly = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("PotionOfFlying");
                    var pclmb = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("PotionOfClimbing");
                    var pspdstock = new StockUnitDescription();
                    var phrsmstock = new StockUnitDescription();
                    var pflystock = new StockUnitDescription();
                    var pclmbstock = new StockUnitDescription();

                    // Backpack
                    var hvsack = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Backpack_Handy_Haversack");
                    var hvsackstock = new StockUnitDescription();

                    // Enchanted items
                    var LSDB = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Longsword_Dragonblade");
                    var LSAC = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Longsword_of_Acuteness");
                    var LSFB = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Longsword_Frostburn");
                    var LSSB = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Longsword_Stormblade");
                    var LSW = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Longsword_Warden");
                    var POR = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_PlateOfRobustness");
                    var POS = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_PlateOfSturdiness");
                    var GSDB = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Greatsword_Doomblade");
                    var GSLB = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Greatsword_Lightbringer");
                    var GSAC = DatabaseRepository.GetDatabase<ItemDefinition>().GetElement("Enchanted_Greatsword_of_Acuteness");
                    var LSDBstock = new StockUnitDescription();
                    var LSACstock = new StockUnitDescription();
                    var LSFBstock = new StockUnitDescription();
                    var LSSBstock = new StockUnitDescription();
                    var LSWstock = new StockUnitDescription();
                    var PORstock = new StockUnitDescription();
                    var POSstock = new StockUnitDescription();
                    var GSDBstock = new StockUnitDescription();
                    var GSLBstock = new StockUnitDescription();
                    var GSACstock = new StockUnitDescription();

                    // AccessTools
                    AccessTools.Field(rosastock.GetType(), "itemDefinition").SetValue(rosastock, rosa);
                    AccessTools.Field(GS1pstock.GetType(), "itemDefinition").SetValue(GS1pstock, GS1p);
                    AccessTools.Field(LS1pstock.GetType(), "itemDefinition").SetValue(LS1pstock, LS1p);
                    AccessTools.Field(foodrstock.GetType(), "itemDefinition").SetValue(foodrstock, foodr);
                    AccessTools.Field(foodrstock.GetType(), "initialAmount").SetValue(foodrstock, 100);
                    AccessTools.Field(foodrstock.GetType(), "maxAmount").SetValue(foodrstock, 100);
                    AccessTools.Field(hcbstock.GetType(), "itemDefinition").SetValue(hcbstock, hcb);
                    AccessTools.Field(maulsstock.GetType(), "itemDefinition").SetValue(maulsstock, mauls);

                    // AccessTools, primed weapons
                    AccessTools.Field(pBattleaxestock.GetType(), "itemDefinition").SetValue(pBattleaxestock, pBattleaxe);
                    AccessTools.Field(pBreastplatestock.GetType(), "itemDefinition").SetValue(pBreastplatestock, pBreastplate);
                    AccessTools.Field(pChainmailstock.GetType(), "itemDefinition").SetValue(pChainmailstock, pChainmail);
                    AccessTools.Field(pChainshirtstock.GetType(), "itemDefinition").SetValue(pChainshirtstock, pChainshirt);
                    AccessTools.Field(pDaggerstock.GetType(), "itemDefinition").SetValue(pDaggerstock, pDagger);
                    AccessTools.Field(pGreataxestock.GetType(), "itemDefinition").SetValue(pGreataxestock, pGreataxe);
                    AccessTools.Field(pGreatswordstock.GetType(), "itemDefinition").SetValue(pGreatswordstock, pGreatsword);
                    AccessTools.Field(pHalfplatestock.GetType(), "itemDefinition").SetValue(pHalfplatestock, pHalfplate);
                    AccessTools.Field(pLeatherarmorstock.GetType(), "itemDefinition").SetValue(pLeatherarmorstock, pLeatherarmor);
                    AccessTools.Field(pLongbowstock.GetType(), "itemDefinition").SetValue(pLongbowstock, pLongbow);
                    AccessTools.Field(pMacestock.GetType(), "itemDefinition").SetValue(pMacestock, pMace);
                    AccessTools.Field(pMorningstarstock.GetType(), "itemDefinition").SetValue(pMorningstarstock, pMorningstar);
                    AccessTools.Field(pPlatestock.GetType(), "itemDefinition").SetValue(pPlatestock, pPlate);
                    AccessTools.Field(pRapierstock.GetType(), "itemDefinition").SetValue(pRapierstock, pRapier);
                    AccessTools.Field(pScalemailstock.GetType(), "itemDefinition").SetValue(pScalemailstock, pScalemail);
                    AccessTools.Field(pScimitarstock.GetType(), "itemDefinition").SetValue(pScimitarstock, pScimitar);
                    AccessTools.Field(pShortbowstock.GetType(), "itemDefinition").SetValue(pShortbowstock, pShortbow);
                    AccessTools.Field(pShortswordstock.GetType(), "itemDefinition").SetValue(pShortswordstock, pShortsword);
                    AccessTools.Field(pLongswordstock.GetType(), "itemDefinition").SetValue(pLongswordstock, pLongsword);

                    // AccessTools, craft manuals
                    AccessTools.Field(CME_BattleAxe_of_Acutenessstock.GetType(), "itemDefinition").SetValue(CME_BattleAxe_of_Acutenessstock, CME_BattleAxe_of_Acuteness);
                    AccessTools.Field(CME_BattleAxe_of_Sharpnessstock.GetType(), "itemDefinition").SetValue(CME_BattleAxe_of_Sharpnessstock, CME_BattleAxe_of_Sharpness);
                    AccessTools.Field(CME_BattleAxe_Punisherstock.GetType(), "itemDefinition").SetValue(CME_BattleAxe_Punisherstock, CME_BattleAxe_Punisher);
                    AccessTools.Field(CME_Greataxe_Of_Sharpnessstock.GetType(), "itemDefinition").SetValue(CME_Greataxe_Of_Sharpnessstock, CME_Greataxe_Of_Sharpness);
                    AccessTools.Field(CME_Greataxe_Stormbladestock.GetType(), "itemDefinition").SetValue(CME_Greataxe_Stormbladestock, CME_Greataxe_Stormblade);
                    AccessTools.Field(CME_Longbow_Lightbringerstock.GetType(), "itemDefinition").SetValue(CME_Longbow_Lightbringerstock, CME_Longbow_Lightbringer);
                    AccessTools.Field(CME_Longbow_Of_Accuracystock.GetType(), "itemDefinition").SetValue(CME_Longbow_Of_Accuracystock, CME_Longbow_Of_Accuracy);
                    AccessTools.Field(CME_Longbow_Stormbowstock.GetType(), "itemDefinition").SetValue(CME_Longbow_Stormbowstock, CME_Longbow_Stormbow);
                    AccessTools.Field(CME_Mace_Of_Acutenessstock.GetType(), "itemDefinition").SetValue(CME_Mace_Of_Acutenessstock, CME_Mace_Of_Acuteness);
                    AccessTools.Field(CME_Mace_Of_Smashingstock.GetType(), "itemDefinition").SetValue(CME_Mace_Of_Smashingstock, CME_Mace_Of_Smashing);
                    AccessTools.Field(CME_Morningstar_Bearclawstock.GetType(), "itemDefinition").SetValue(CME_Morningstar_Bearclawstock, CME_Morningstar_Bearclaw);
                    AccessTools.Field(CME_Morningstar_Of_Powerstock.GetType(), "itemDefinition").SetValue(CME_Morningstar_Of_Powerstock, CME_Morningstar_Of_Power);
                    AccessTools.Field(CME_Shortbow_Medusastock.GetType(), "itemDefinition").SetValue(CME_Shortbow_Medusastock, CME_Shortbow_Medusa);
                    AccessTools.Field(CME_Shortbow_Of_Accuracystock.GetType(), "itemDefinition").SetValue(CME_Shortbow_Of_Accuracystock, CME_Shortbow_Of_Accuracy);
                    AccessTools.Field(CME_Shortbow_Of_Sharpshootingstock.GetType(), "itemDefinition").SetValue(CME_Shortbow_Of_Sharpshootingstock, CME_Shortbow_Of_Sharpshooting);
                    AccessTools.Field(CME_Shortsword_Lightbringerstock.GetType(), "itemDefinition").SetValue(CME_Shortsword_Lightbringerstock, CME_Shortsword_Lightbringer);
                    AccessTools.Field(CME_Shortsword_Of_Acutenessstock.GetType(), "itemDefinition").SetValue(CME_Shortsword_Of_Acutenessstock, CME_Shortsword_Of_Acuteness);
                    AccessTools.Field(CME_Shortsword_Of_Sharpnessstock.GetType(), "itemDefinition").SetValue(CME_Shortsword_Of_Sharpnessstock, CME_Shortsword_Of_Sharpness);
                    AccessTools.Field(CME_Shortsword_Whiteburnstock.GetType(), "itemDefinition").SetValue(CME_Shortsword_Whiteburnstock, CME_Shortsword_Whiteburn);

                    // AccessTools, craft ingredients
                    AccessTools.Field(IE_Blood_Gemstock.GetType(), "itemDefinition").SetValue(IE_Blood_Gemstock, IE_Blood_Gem);
                    AccessTools.Field(IE_Blood_Of_Solastastock.GetType(), "itemDefinition").SetValue(IE_Blood_Of_Solastastock, IE_Blood_Of_Solasta);
                    AccessTools.Field(IE_Cloud_Diamondstock.GetType(), "itemDefinition").SetValue(IE_Cloud_Diamondstock, IE_Cloud_Diamond);
                    AccessTools.Field(IE_Crystal_Of_Winterstock.GetType(), "itemDefinition").SetValue(IE_Crystal_Of_Winterstock, IE_Crystal_Of_Winter);
                    AccessTools.Field(IE_Diamond_Of_Elaistock.GetType(), "itemDefinition").SetValue(IE_Diamond_Of_Elaistock, IE_Diamond_Of_Elai);
                    AccessTools.Field(IE_Doom_Gemstock.GetType(), "itemDefinition").SetValue(IE_Doom_Gemstock, IE_Doom_Gem);
                    AccessTools.Field(IE_Heartstonestock.GetType(), "itemDefinition").SetValue(IE_Heartstonestock, IE_Heartstone);
                    AccessTools.Field(IE_LifeStonestock.GetType(), "itemDefinition").SetValue(IE_LifeStonestock, IE_LifeStone);
                    AccessTools.Field(IE_Medusa_Coralstock.GetType(), "itemDefinition").SetValue(IE_Medusa_Coralstock, IE_Medusa_Coral);
                    AccessTools.Field(IE_MithralStonestock.GetType(), "itemDefinition").SetValue(IE_MithralStonestock, IE_MithralStone);
                    AccessTools.Field(IE_Oil_Of_Acutenessstock.GetType(), "itemDefinition").SetValue(IE_Oil_Of_Acutenessstock, IE_Oil_Of_Acuteness);
                    AccessTools.Field(IE_PurpleAmberstock.GetType(), "itemDefinition").SetValue(IE_PurpleAmberstock, IE_PurpleAmber);
                    AccessTools.Field(IE_Queen_Venomstock.GetType(), "itemDefinition").SetValue(IE_Queen_Venomstock, IE_Queen_Venom);
                    AccessTools.Field(IE_Shard_Of_Firestock.GetType(), "itemDefinition").SetValue(IE_Shard_Of_Firestock, IE_Shard_Of_Fire);
                    AccessTools.Field(IE_Shard_Of_Icestock.GetType(), "itemDefinition").SetValue(IE_Shard_Of_Icestock, IE_Shard_Of_Ice);
                    AccessTools.Field(IE_Slavestonestock.GetType(), "itemDefinition").SetValue(IE_Slavestonestock, IE_Slavestone);
                    AccessTools.Field(IE_Soul_Gemstock.GetType(), "itemDefinition").SetValue(IE_Soul_Gemstock, IE_Soul_Gem);
                    AccessTools.Field(IE_Starduststock.GetType(), "itemDefinition").SetValue(IE_Starduststock, IE_Stardust);

                    // AccessTools, potions
                    AccessTools.Field(pspdstock.GetType(), "itemDefinition").SetValue(pspdstock, pspd);
                    AccessTools.Field(pspdstock.GetType(), "factionStatus").SetValue(pspdstock, "Sympathy");
                    // AccessTools.Field(pspdstock.GetType(), "initialAmount").SetValue(pspdstock, 4);
                    // AccessTools.Field(pspdstock.GetType(), "maxAmount").SetValue(pspdstock, 4);
                    AccessTools.Field(phrsmstock.GetType(), "itemDefinition").SetValue(phrsmstock, phrsm);
                    AccessTools.Field(phrsmstock.GetType(), "factionStatus").SetValue(phrsmstock, "Sympathy");
                    // AccessTools.Field(phrsmstock.GetType(), "initialAmount").SetValue(phrsmstock, 4);
                    // AccessTools.Field(phrsmstock.GetType(), "maxAmount").SetValue(phrsmstock, 4);
                    AccessTools.Field(pflystock.GetType(), "itemDefinition").SetValue(pflystock, pfly);
                    AccessTools.Field(pflystock.GetType(), "factionStatus").SetValue(pflystock, "Sympathy");
                    // AccessTools.Field(pflystock.GetType(), "initialAmount").SetValue(pflystock, 4);
                    // AccessTools.Field(pflystock.GetType(), "maxAmount").SetValue(pflystock, 4);
                    AccessTools.Field(pclmbstock.GetType(), "itemDefinition").SetValue(pclmbstock, pclmb);
                    AccessTools.Field(pclmbstock.GetType(), "factionStatus").SetValue(pclmbstock, "Sympathy");
                    // AccessTools.Field(pflystock.GetType(), "initialAmount").SetValue(pflystock, 4);
                    // AccessTools.Field(pflystock.GetType(), "maxAmount").SetValue(pflystock, 4);

                    // AccessTools, hvsack and enchanted items
                    AccessTools.Field(hvsackstock.GetType(), "itemDefinition").SetValue(hvsackstock, hvsack);
                    AccessTools.Field(hvsackstock.GetType(), "factionStatus").SetValue(hvsackstock, "Alliance");
                    AccessTools.Field(LSDBstock.GetType(), "itemDefinition").SetValue(LSDBstock, LSDB);
                    AccessTools.Field(LSDBstock.GetType(), "factionStatus").SetValue(LSDBstock, "Alliance");
                    AccessTools.Field(LSACstock.GetType(), "itemDefinition").SetValue(LSACstock, LSAC);
                    AccessTools.Field(LSACstock.GetType(), "factionStatus").SetValue(LSACstock, "Alliance");
                    AccessTools.Field(LSFBstock.GetType(), "itemDefinition").SetValue(LSFBstock, LSFB);
                    AccessTools.Field(LSFBstock.GetType(), "factionStatus").SetValue(LSFBstock, "Alliance");
                    AccessTools.Field(LSSBstock.GetType(), "itemDefinition").SetValue(LSSBstock, LSSB);
                    AccessTools.Field(LSSBstock.GetType(), "factionStatus").SetValue(LSSBstock, "Alliance");
                    AccessTools.Field(LSWstock.GetType(), "itemDefinition").SetValue(LSWstock, LSW);
                    AccessTools.Field(LSWstock.GetType(), "factionStatus").SetValue(LSWstock, "Alliance");
                    AccessTools.Field(PORstock.GetType(), "itemDefinition").SetValue(PORstock, POR);
                    AccessTools.Field(PORstock.GetType(), "factionStatus").SetValue(PORstock, "Alliance");
                    AccessTools.Field(POSstock.GetType(), "itemDefinition").SetValue(POSstock, POS);
                    AccessTools.Field(POSstock.GetType(), "factionStatus").SetValue(POSstock, "Alliance");
                    AccessTools.Field(GSDBstock.GetType(), "itemDefinition").SetValue(GSDBstock, GSDB);
                    AccessTools.Field(GSDBstock.GetType(), "factionStatus").SetValue(GSDBstock, "Alliance");
                    AccessTools.Field(GSLBstock.GetType(), "itemDefinition").SetValue(GSLBstock, GSLB);
                    AccessTools.Field(GSLBstock.GetType(), "factionStatus").SetValue(GSLBstock, "Alliance");
                    AccessTools.Field(GSACstock.GetType(), "itemDefinition").SetValue(GSACstock, GSAC);
                    AccessTools.Field(GSACstock.GetType(), "factionStatus").SetValue(GSACstock, "Alliance");

                    // Add to Gorim list
                    gorims.StockUnitDescriptions.Add(rosastock);
                    gorims.StockUnitDescriptions.Add(GS1pstock);
                    gorims.StockUnitDescriptions.Add(LS1pstock);
                    gorims.StockUnitDescriptions.Add(foodrstock);
                    gorims.StockUnitDescriptions.Add(hcbstock);
                    gorims.StockUnitDescriptions.Add(maulsstock);
                    gorims.StockUnitDescriptions.Add(pspdstock);
                    gorims.StockUnitDescriptions.Add(phrsmstock);
                    gorims.StockUnitDescriptions.Add(pflystock);
                    gorims.StockUnitDescriptions.Add(pclmbstock);

                    // Add to Gorim list, primed
                    gorims.StockUnitDescriptions.Add(pBattleaxestock);
                    gorims.StockUnitDescriptions.Add(pBreastplatestock);
                    gorims.StockUnitDescriptions.Add(pChainmailstock);
                    gorims.StockUnitDescriptions.Add(pChainshirtstock);
                    gorims.StockUnitDescriptions.Add(pDaggerstock);
                    gorims.StockUnitDescriptions.Add(pGreataxestock);
                    gorims.StockUnitDescriptions.Add(pGreatswordstock);
                    gorims.StockUnitDescriptions.Add(pHalfplatestock);
                    gorims.StockUnitDescriptions.Add(pLeatherarmorstock);
                    gorims.StockUnitDescriptions.Add(pLongbowstock);
                    gorims.StockUnitDescriptions.Add(pMacestock);
                    gorims.StockUnitDescriptions.Add(pMorningstarstock);
                    gorims.StockUnitDescriptions.Add(pPlatestock);
                    gorims.StockUnitDescriptions.Add(pRapierstock);
                    gorims.StockUnitDescriptions.Add(pScalemailstock);
                    gorims.StockUnitDescriptions.Add(pScimitarstock);
                    gorims.StockUnitDescriptions.Add(pShortbowstock);
                    gorims.StockUnitDescriptions.Add(pShortswordstock);
                    gorims.StockUnitDescriptions.Add(pLongswordstock);

                    // Add food and potions to Hugo
                    hugos.StockUnitDescriptions.Add(foodrstock);
                    // hugos.StockUnitDescriptions.Add(pspdstock);
                    // hugos.StockUnitDescriptions.Add(phrsmstock);
                    // hugos.StockUnitDescriptions.Add(pflystock);
                    // hugos.StockUnitDescriptions.Add(pclmbstock);

                    // Add crafting manuals to Hugo
                    hugos.StockUnitDescriptions.Add(CME_BattleAxe_of_Acutenessstock);
                    hugos.StockUnitDescriptions.Add(CME_BattleAxe_of_Sharpnessstock);
                    hugos.StockUnitDescriptions.Add(CME_BattleAxe_Punisherstock);
                    hugos.StockUnitDescriptions.Add(CME_Greataxe_Of_Sharpnessstock);
                    hugos.StockUnitDescriptions.Add(CME_Greataxe_Stormbladestock);
                    hugos.StockUnitDescriptions.Add(CME_Longbow_Lightbringerstock);
                    hugos.StockUnitDescriptions.Add(CME_Longbow_Of_Accuracystock);
                    hugos.StockUnitDescriptions.Add(CME_Longbow_Stormbowstock);
                    hugos.StockUnitDescriptions.Add(CME_Mace_Of_Acutenessstock);
                    hugos.StockUnitDescriptions.Add(CME_Mace_Of_Smashingstock);
                    hugos.StockUnitDescriptions.Add(CME_Morningstar_Bearclawstock);
                    hugos.StockUnitDescriptions.Add(CME_Morningstar_Of_Powerstock);
                    hugos.StockUnitDescriptions.Add(CME_Shortbow_Medusastock);
                    hugos.StockUnitDescriptions.Add(CME_Shortbow_Of_Accuracystock);
                    hugos.StockUnitDescriptions.Add(CME_Shortbow_Of_Sharpshootingstock);
                    hugos.StockUnitDescriptions.Add(CME_Shortsword_Lightbringerstock);
                    hugos.StockUnitDescriptions.Add(CME_Shortsword_Of_Acutenessstock);
                    hugos.StockUnitDescriptions.Add(CME_Shortsword_Of_Sharpnessstock);
                    hugos.StockUnitDescriptions.Add(CME_Shortsword_Whiteburnstock);

                    // Add crafting ingredients to Hugo
                    hugos.StockUnitDescriptions.Add(IE_Blood_Gemstock);
                    hugos.StockUnitDescriptions.Add(IE_Blood_Of_Solastastock);
                    hugos.StockUnitDescriptions.Add(IE_Cloud_Diamondstock);
                    hugos.StockUnitDescriptions.Add(IE_Crystal_Of_Winterstock);
                    hugos.StockUnitDescriptions.Add(IE_Diamond_Of_Elaistock);
                    hugos.StockUnitDescriptions.Add(IE_Doom_Gemstock);
                    hugos.StockUnitDescriptions.Add(IE_Heartstonestock);
                    hugos.StockUnitDescriptions.Add(IE_LifeStonestock);
                    hugos.StockUnitDescriptions.Add(IE_Medusa_Coralstock);
                    hugos.StockUnitDescriptions.Add(IE_MithralStonestock);
                    hugos.StockUnitDescriptions.Add(IE_Oil_Of_Acutenessstock);
                    hugos.StockUnitDescriptions.Add(IE_PurpleAmberstock);
                    hugos.StockUnitDescriptions.Add(IE_Queen_Venomstock);
                    hugos.StockUnitDescriptions.Add(IE_Shard_Of_Firestock);
                    hugos.StockUnitDescriptions.Add(IE_Shard_Of_Icestock);
                    hugos.StockUnitDescriptions.Add(IE_Slavestonestock);
                    hugos.StockUnitDescriptions.Add(IE_Soul_Gemstock);
                    hugos.StockUnitDescriptions.Add(IE_Starduststock);

                    // Add backpack and enchanted to Summer 
                    summers.StockUnitDescriptions.Add(hvsackstock);
                    summers.StockUnitDescriptions.Add(LSDBstock);
                    summers.StockUnitDescriptions.Add(LSACstock);
                    summers.StockUnitDescriptions.Add(LSFBstock);
                    summers.StockUnitDescriptions.Add(LSSBstock);
                    summers.StockUnitDescriptions.Add(LSWstock);
                    summers.StockUnitDescriptions.Add(PORstock);
                    summers.StockUnitDescriptions.Add(POSstock);
                    summers.StockUnitDescriptions.Add(GSDBstock);
                    summers.StockUnitDescriptions.Add(GSLBstock);
                    summers.StockUnitDescriptions.Add(GSACstock);

                }
                catch (Exception ex)
                {
                    Error(ex);
                    throw;
                }
            }
        }
    }
}