using Godot;

public partial class ItemResource : Resource
{
    [ExportGroup("Texture"), Export]
    public Texture2D ItemIcon;
    [Export] public int HFrames;
    [Export(PropertyHint.Max, "10")] public int FPS;

    [ExportGroup("ItemInfo"), Export]
    public PackedScene ItemAction; 
    [Export] public float Damage;
}