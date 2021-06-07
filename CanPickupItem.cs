using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace ItemBlocker
{
    public class CanPickupItem : GlobalItem
    {
        public override bool CanPickup(Item item, Player player)
        {
            bool canPickupItem = !ModContent.GetInstance<ItemBlockerItems>().ItemsToBlock.Contains(new ItemDefinition(item.type)) && player.whoAmI == Main.myPlayer;
            return canPickupItem;
        }
    }
}
