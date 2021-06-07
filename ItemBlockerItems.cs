using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ItemBlocker
{
	public class ItemBlockerItems : ModConfig
	{
		public override ConfigScope Mode => ConfigScope.ClientSide;
		[Label("Items")]
		public List<ItemDefinition> ItemsToBlock { get; set; } = new List<ItemDefinition>();
	}
}
