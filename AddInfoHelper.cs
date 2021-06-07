using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemBlocker
{
    public class AddInfoHelper
    {
        /// <summary>
        /// text1 = 0, text2 = 1
        /// </summary>
        public static string[] InfoString()
        {
            string key1 = string.Empty;
            string key2 = string.Empty;
            bool hasAssignedKey1 = ItemBlocker.HotkeySaveItem.GetAssignedKeys().Count < 1;
            bool hasAssignedKey2 = ItemBlocker.HotkeyRemoveItem.GetAssignedKeys().Count < 1;
            if (!hasAssignedKey1)
                key1 = ItemBlocker.HotkeySaveItem.GetAssignedKeys()[0];
            if (!hasAssignedKey2)
                key2 = ItemBlocker.HotkeyRemoveItem.GetAssignedKeys()[0];
            string text1 = hasAssignedKey1 ? $"Please assign a hotkey to 'HotkeySaveItem' in your contols panel." : $"Press '{key1}' to block an item from entering your inventory.";
            string text2 = hasAssignedKey2 ? $"Please assign a hotkey to 'HotkeyRemoveItem' in your contols panel." : $"Press '{key2}' to block an item from entering your inventory.";

            return new string[] { text1, text2 };
        }
    }
}
