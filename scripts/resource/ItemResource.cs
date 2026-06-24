using Godot;

[GlobalClass]
public partial class ItemResource : Resource
{
    [ExportGroup("Texture"), Export]
    public Texture2D ItemIcon;

    [Export] public bool HFlip = false;
    [Export] public bool VFlip = false;
    [Export] public int HFrames;
    [Export(PropertyHint.Max, "10")] public int FPS;

    [ExportGroup("ItemInfo"), Export]
    public PackedScene[] ItemAction; 
    [Export] public float Damage;
}