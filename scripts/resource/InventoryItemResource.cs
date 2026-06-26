
using Godot;

[GlobalClass]
public partial class InventoryItemResource : Resource
{
    [Export] public ItemResource ItemResource;
    [Export] public int Amount;
    [Export] public int MaxAmount;
}