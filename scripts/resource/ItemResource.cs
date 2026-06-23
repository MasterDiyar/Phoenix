using Godot;

public partial class ItemResource : Resource
{
    [Export] public PackedScene ItemIcon;
    [Export] public PackedScene ItemAction; 
    [Export] public float Damage;
}