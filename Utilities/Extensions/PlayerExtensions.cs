﻿using Terraria;

namespace EndlessEscapade.Utilities.Extensions;

public static class PlayerExtensions
{
    public static bool HasItemEquip(this Player player, int type) {
        for (var i = 0; i < 8 + player.extraAccessorySlots; i++) {
            if (player.armor[i].type == type) {
                return true;
            }
        }

        return false;
    }

    public static bool HasItemStack(this Player player, int type, int stack) {
        var count = 0;

        for (var i = 0; i < player.inventory.Length; i++) {
            var item = player.inventory[i];

            if (!item.IsAir && item.type == type) {
                count += item.stack;
            }
        }

        return count >= stack;
    }
    
    public static bool HasItemGroupStack(this Player player, int type, int stack) {
        var group = RecipeGroup.recipeGroups[type];
        
        if (group == null) {
            return false;
        }
        
        var count = 0;

        for (var i = 0; i < player.inventory.Length; i++) {
            var item = player.inventory[i];

            if (!item.IsAir && group.ContainsItem(item.type)) {
                count += item.stack;
            }
        }

        return count >= stack;
    }

    public static bool TryConsumeItemStack(this Player player, int type, int stack) {
        if (!player.HasItemStack(type, stack)) {
            return false;
        }

        var count = stack;

        for (var i = 0; i < player.inventory.Length; i++) {
            var item = player.inventory[i];

            if (count <= 0) {
                break;
            }

            if (!item.IsAir && item.type == type) {
                var previousStack = item.stack;

                item.stack -= count;
                count -= previousStack;
            }
        }

        return true;
    }

    public static bool TryConsumeItemGroupStack(this Player player, int type, int stack) {
        if (!player.HasItemGroupStack(type, stack)) {
            return false;
        }

        var group = RecipeGroup.recipeGroups[type];
        var count = stack;

        for (var i = 0; i < player.inventory.Length; i++) {
            var item = player.inventory[i];

            if (count <= 0) {
                break;
            }

            if (!item.IsAir && group.ContainsItem(item.type)) {
                var previousStack = item.stack;

                item.stack -= count;
                count -= previousStack;
            }
        }

        return true;
    }
}
