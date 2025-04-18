﻿// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated from BlockTemplate.tt/>
// Le Village - suppression de currency

namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Eco.Gameplay.Blocks;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.DynamicValues;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Core.Items;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Shared.SharedTypes;
    using Eco.World;
    using Eco.World.Blocks;
    using Eco.World.Water;
    using Eco.Gameplay.Pipes;
    using Eco.Core.Controller;
    using Eco.Gameplay.Items.Recipes;
    using Eco.Shared.Graphics;
    using Eco.World.Color;

    /// <summary>Auto-generated class. Don't modify it! All your changes will be wiped with next update! Use Mods* partial methods instead for customization.</summary>

    [Serialized]
    [Solid, Wall, Cliff, Minable(2)]
        public partial class LimestoneBlock :
        Block
        , IRepresentsItem
    {
        public virtual Type RepresentedItemType { get { return typeof(LimestoneItem); } }
    }

    [Serialized]
    [LocDisplayName("Limestone")]
    [LocDescription("A hard rock useful for construction and industrial processes. Limestone is sedimentary, forming mostly from the fallen compacted remains of marine organisms.")]
    [MaxStackSize(20)]
    [Weight(6500)]
    [ResourcePile]
    [Ecopedia("Natural Resources", "Stone", createAsSubPage: true)]
    //[Currency][Tag("Currency")]  //Le Village
    [Tag("Rock")]
    [Tag("Excavatable")]
    public partial class LimestoneItem :
 
    BlockItem<LimestoneBlock>
    {
        public override LocString DisplayNamePlural { get { return Localizer.DoStr("Limestone"); } }

        public override bool CanStickToWalls { get { return false; } }

        private static Type[] blockTypes = new Type[] {
            typeof(LimestoneStacked1Block),
            typeof(LimestoneStacked2Block),
            typeof(LimestoneStacked3Block),
            typeof(LimestoneStacked4Block)
        };
        
        public override Type[] BlockTypes { get { return blockTypes; } }
    }

    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class LimestoneStacked1Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class LimestoneStacked2Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.PartialStack)]
    [Serialized, Solid] public class LimestoneStacked3Block : PickupableBlock, IWaterLoggedBlock { }
    [Tag("Rock")]
    [Tag("Excavatable")]
    [Tag(BlockTags.FullStack)]
    [Serialized, Solid,Wall] public class LimestoneStacked4Block : PickupableBlock, IWaterLoggedBlock { } //Only a wall if it's all 4 Limestone
}
