using Godot;

namespace Dorozhniyi.scripts.item;

public partial class FallenItem : Area2D
{
    [Export] public InventoryItemResource IIResource;
    [Export] public Sprite2D Sprite;

    public override void _Ready()
    {
        Sprite.Texture = IIResource.ItemResource.Icon.ItemIcon;
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is not Player player) return;

        if (player.Inventory == null) return;
        
        player.Inventory.AddItem(IIResource);
        QueueFree();
    }
}