﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from ToolTemplate.tt/>
// Le village - Intégration Repair Kit en acier

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Core.Items;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Items.Internal;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.Gameplay.Pipes;
    using Eco.Shared.Math;
    using Eco.Core.Controller;
    using Eco.Gameplay.Interactions.Interactors;
    using Eco.Gameplay.Items.Recipes;


    /// <summary>
    /// <para>Server side recipe definition for "SteelHoe".</para>
    /// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
    /// </summary>
    /// <remarks>
    /// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
    /// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
    /// </remarks>
    [RequiresModule(typeof(BlacksmithTableObject))]
    [RequiresSkill(typeof(BlacksmithSkill), 3)]
    [Ecopedia("Items", "Tools", subPageName: "Steel Hoe Item")]
    public partial class SteelHoeRecipe : RecipeFamily
    {
        public SteelHoeRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "SteelHoe",  //noloc
                displayName: Localizer.DoStr("Steel Hoe"),

                // Defines the ingredients needed to craft this recipe. An ingredient items takes the following inputs
                // type of the item, the amount of the item, the skill required, and the talent used.
                ingredients: new List<IngredientElement>
                {
                    new IngredientElement(typeof(SteelBarItem), 10, typeof(BlacksmithSkill)),
                    new IngredientElement(typeof(LeatherHideItem), 2, typeof(BlacksmithSkill)),
                    new IngredientElement("Lumber", 5, typeof(BlacksmithSkill)), //noloc
                },

                // Define our recipe output items.
                // For every output item there needs to be one CraftingElement entry with the type of the final item and the amount
                // to create.
                items: new List<CraftingElement>
                {
                    new CraftingElement<SteelHoeItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 0.5f; // Defines how much experience is gained when crafted.

            // Defines the amount of labor required and the required skill to add labor
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(BlacksmithSkill));

            // Defines our crafting time for the recipe
            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(SteelHoeRecipe), start: 0.5f, skillType: typeof(BlacksmithSkill));

            // Perform pre/post initialization for user mods and initialize our recipe instance with the display name "Steel Hoe"
            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Steel Hoe"), recipeType: typeof(SteelHoeRecipe));
            this.ModsPostInitialize();

            // Register our RecipeFamily instance with the crafting system so it can be crafted.
            CraftingComponent.AddRecipe(tableType: typeof(PowerHammerObject), recipe: this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();

        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Steel Hoe")]
    [LocDescription("A steel hoe with improved range to help tilling larger areas.")]
    [Tier(3)]
    //[RepairRequiresSkill(typeof(BlacksmithSkill), 0)]
    [Weight(1000)]
    [Category("Tool")]
    [Tag("Tool")]
    [Ecopedia("Items", "Tools", createAsSubPage: true)]
    public partial class SteelHoeItem : HoeItem, IAoeToolItem
    {
                                                                                                                                                                                                                                           // Static values
        private static IDynamicValue caloriesBurn           = new MultiDynamicValue(MultiDynamicOps.Multiply, new TalentModifiedValue(typeof(SteelHoeItem), typeof(ToolEfficiencyTalent)), CreateCalorieValue(20, typeof(FarmingSkill), typeof(SteelHoeItem)));
        private static IDynamicValue exp                    = new ConstantValue(0.1f);
        private static IDynamicValue tier                   = new ConstantValue(3);
        //private static SkillModifiedValue skilledRepairCost = new SkillModifiedValue(8, BlacksmithSkill.MultiplicativeStrategy, typeof(BlacksmithSkill), Localizer.DoStr("repair cost"), DynamicValueType.Efficiency);
        private static IDynamicValue skilledRepairCost = new ConstantValue(1);

        public AreaOfEffectMode AreaOfEffectMode => areaOfEffectMode;
        static readonly AreaOfEffectMode areaOfEffectMode = AOEFactory.Make("MultiBlock", true, "-0,0,0;0,0,1", 0, 0, 0);

        // Tool overrides

        public override IDynamicValue CaloriesBurn      => caloriesBurn;
        public override Type ExperienceSkill            => typeof(FarmingSkill);
        public override IDynamicValue ExperienceRate    => exp;
        public override IDynamicValue Tier              => tier;
        public override IDynamicValue SkilledRepairCost => skilledRepairCost;
        public override float DurabilityRate            => DurabilityMax / 750f;
        //public override Item RepairItem                 => Item.Get<SteelBarItem>();
        public override Item RepairItem                 => Item.Get<SteelRepairKitItem>();
        public override int FullRepairAmount            => 1; //8 to 1
    }
}
