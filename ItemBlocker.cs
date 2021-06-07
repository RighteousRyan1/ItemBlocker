using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace ItemBlocker
{
	public class ItemBlocker : Mod
	{
        public static ModHotKey HotkeySaveItem { get; set; }
        public static ModHotKey HotkeyRemoveItem { get; set; }
        public override void Load()
        {
            HotkeySaveItem = RegisterHotKey("HotkeySaveItem", "Insert");
            HotkeyRemoveItem = RegisterHotKey("HotkeyRemoveItem", "Delete");

            On.Terraria.Main.DrawInterface_30_Hotbar += Main_DrawInterface_30_Hotbar;
        }
        private void Main_DrawInterface_30_Hotbar(On.Terraria.Main.orig_DrawInterface_30_Hotbar orig, Main self)
        {
            var blItem = ModContent.GetInstance<ItemBlockerItems>().ItemsToBlock;
            bool showStrings = false;
            string shortenedName = "";

            if (Main.HoverItem.type > ItemID.None)
                shortenedName = Main.hoverItemName[Main.hoverItemName.Length - 1] == ')' ?
                $"'{Main.hoverItemName.Remove(Main.hoverItemName.Length - 3, (Main.hoverItemName.Length - 1) - (Main.hoverItemName.Length - 3)).Replace("(", "").Replace(")", "").Trim()}'" : $"'{Main.hoverItemName}'";
            if (Main.playerInventory && Main.HoverItem.type > ItemID.None)
            {
                showStrings = true;
                if (blItem.Contains(new ItemDefinition(Main.HoverItem.type)))
                {
                    Utils.DrawBorderString(Main.spriteBatch, $"{shortenedName} exists in your blocked items.", new Vector2(26, 260), Color.OrangeRed, 0.8f);
                }
                else
                {
                    Utils.DrawBorderString(Main.spriteBatch, $"{shortenedName} isn't in your blocked items.", new Vector2(26, 260), Color.DarkOrange, 0.8f);
                }
                if (HotkeySaveItem.JustPressed)
                {
                    if (blItem.Contains(new ItemDefinition(Main.HoverItem.type)))
                    {
                        Main.PlaySound(SoundID.Unlock);
                        return;
                    }
                    Main.PlaySound(SoundID.MenuTick);
                    blItem.Add(new ItemDefinition(Main.HoverItem.type));
                }
                if (HotkeyRemoveItem.JustPressed)
                {
                    if (!blItem.Contains(new ItemDefinition(Main.HoverItem.type)))
                    {
                        Main.PlaySound(SoundID.Unlock);
                        return;
                    }
                    Main.PlaySound(SoundID.MenuTick);
                    blItem.Remove(new ItemDefinition(Main.HoverItem.type));
                }
            }
            if (Main.playerInventory)
            {
                Utils.DrawBorderString(Main.spriteBatch, $"{AddInfoHelper.InfoString()[0]}", showStrings ? new Vector2(26, 280) : new Vector2(26, 260), Color.LightCoral, 0.8f);
                Utils.DrawBorderString(Main.spriteBatch, $"{AddInfoHelper.InfoString()[1]}", showStrings ? new Vector2(26, 300) : new Vector2(26, 280), Color.Coral, 0.8f);
            }
            orig(self);
        }
    }
}