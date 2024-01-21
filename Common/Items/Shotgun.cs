using EndlessEscapade.Common.Items.Components;
using EndlessEscapade.Content.Gores;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EndlessEscapade.Common.Items;

public sealed class Shotgun : GlobalItem
{
    public override bool AppliesToEntity(Item entity, bool lateInstantiation) {
        return entity.type == ItemID.Shotgun;
    }

    public override void SetDefaults(Item entity) {
        if (!entity.TryGetGlobalItem(out ItemBulletCasings component)) {
            return;
        }

        component.Enabled = true;
        component.CasingAmount = 2;
        component.CasingType = ModContent.GoreType<ShellCasing>();
    }
}
