﻿// Le Village - Entrée de mine pour humain 1 de large 2 de haut

using Eco.Core.Controller;
using Eco.Core.Items;
using Eco.Gameplay.Components;
using Eco.Gameplay.Components.Auth;
using Eco.Gameplay.Items;
using Eco.Gameplay.Items.Recipes;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Occupancy;
using Eco.Gameplay.Skills;
using Eco.Shared.Items;
using Eco.Shared.Localization;
using Eco.Shared.Math;
using Eco.Shared.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;
namespace Eco.Mods.TechTree
{
    [Serialized]
    [RequireComponent(typeof(PropertyAuthComponent))]
    [RequireComponent(typeof(OccupancyRequirementComponent))]
    [RequireComponent(typeof(ForSaleComponent))]
    [RequireComponent(typeof(PaintableComponent))] //TODO: Fix not all the object have this component
    [Tag("Decoration")] //Mise à jour du Tag
    [Ecopedia("Decoration", "Décoration de mine", subPageName: "Entrée de mine pour humain")]
    public partial class HumanMineGateObject : WorldObject, IRepresentsItem
    {
    public virtual Type RepresentedItemType => typeof(HumanMineGateItem);
        public override LocString DisplayName => Localizer.DoStr("Entrée de mine pour humain");
        public override TableTextureMode TableTexture => TableTextureMode.Stone;
        static HumanMineGateObject()
        {
            var BlockOccupancyList = new List<BlockOccupancy>
            {
                new BlockOccupancy(new Vector3i(0, 0, 0)),
                new BlockOccupancy(new Vector3i(0, 1, 0)),
            };

            AddOccupancy(MethodBase.GetCurrentMethod().DeclaringType, BlockOccupancyList);
        }
        /// <summary>Hook for mods to customize WorldObject before initialization. You can change housing values here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize WorldObject after initialization.</summary>
        partial void ModsPostInitialize();
    }

    [Serialized]
    [LocDisplayName("Entrée de mine pour humain")]
    [LocDescription("Entrée de mine pour humain. Taille : 1 de large et 2 de haut.")]
    [Ecopedia("Decoration", "Décoration de mine", createAsSubPage: true)]
    [Tag("Decoration")] //Mise à jour du Tag
    [Weight(2000)] // Defini le poids de cet objet
    public partial class HumanMineGateItem : WorldObjectItem<HumanMineGateObject>
    {
        protected override OccupancyContext GetOccupancyContext => new SideAttachedContext(0 | DirectionAxisFlags.Down, WorldObject.GetOccupancyInfo(this.WorldObjectType));
    }

/// <summary>
/// <para>Server side recipe definition for "AdornedAshlarShaleTable".</para>
/// <para>More information about RecipeFamily objects can be found at https://docs.play.eco/api/server/eco.gameplay/Eco.Gameplay.Items.RecipeFamily.html</para>
/// </summary>
/// <remarks>
/// This is an auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization. 
/// If you wish to modify this class, please create a new partial class or follow the instructions in the "UserCode" folder to override the entire file.
/// </remarks>
    [RequiresSkill(typeof(CarpentrySkill), 2)]
    [Ecopedia("Decoration", "Décoration de mine", subPageName: "Entrée de mine pour humain")]
    public partial class HumanMineGateRecipe : RecipeFamily
    {
        public HumanMineGateRecipe()
        {
            var recipe = new Recipe();
            recipe.Init(
                name: "Entrée de mine pour humain",  //noloc
                displayName: Localizer.DoStr("Entrée de mine pour humain"),

                ingredients: new List<IngredientElement>
                {
                    new IngredientElement("Wood", 3, typeof(CarpenterSkill), typeof(CarpentryLavishResourcesTalent)),
                },

                items: new List<CraftingElement>
                {
                    new CraftingElement<HumanMineGateItem>()
                });
            this.Recipes = new List<Recipe> { recipe };
            this.ExperienceOnCraft = 2.5f;

            this.LaborInCalories = CreateLaborInCaloriesValue(480, typeof(CarpentrySkill));

            this.CraftMinutes = CreateCraftTimeValue(beneficiary: typeof(HumanMineGateRecipe), start: 8, skillType: typeof(CarpentrySkill), typeof(CarpentryFocusedSpeedTalent), typeof(CarpentryParallelSpeedTalent));

            this.ModsPreInitialize();
            this.Initialize(displayText: Localizer.DoStr("Entrée de mine pour humain"), recipeType: typeof(HumanMineGateRecipe));
            this.ModsPostInitialize();

            CraftingComponent.AddRecipe(tableType: typeof(CarpentryTableObject), recipe: this);
        }
        partial void ModsPreInitialize();
        partial void ModsPostInitialize();
    }
}
