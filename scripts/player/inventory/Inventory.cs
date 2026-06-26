using System.Collections.Generic;
using System.Linq;
using Godot;

namespace Dorozhniyi.scripts.player.inventory;

public partial class Inventory : Control
{
    [Export] public AnimatedIcon[] Icons;
    
    public List<InventoryItemResource> ItemList = [];
    public ItemResource[] HotBar = new ItemResource[9];
    
    public void AddItem(InventoryItemResource item)
    {
        var existingItem = ItemList.FirstOrDefault(i => i.ItemResource.Equals(item.ItemResource));
        if (existingItem != null) existingItem.Amount += item.Amount;
        else ItemList.Add(item);
    }
    public void RemoveItem(ItemResource itemResource)
    {
        var itemToRemove = ItemList.FirstOrDefault(i => i.ItemResource.Equals(itemResource));
        if (itemToRemove == null) return;
        
        ItemList.Remove(itemToRemove);
        for (int i = 0; i < HotBar.Length; i++)
            if (HotBar[i] == itemResource) HotBar[i] = null;
    }

    public void AddToHotBar(int index, int to)
    {
        HotBar[to] = ItemList[index].ItemResource;
        Icons[to].Init(ItemList[index].ItemResource.Icon);
    }
}