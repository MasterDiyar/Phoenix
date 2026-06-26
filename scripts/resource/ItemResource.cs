using Godot;

[GlobalClass]
public partial class ItemResource : Resource
{
    [ExportGroup("Inventory Data"), Export] 
    public string Name;
    [Export] public string Description;
    [Export] public string Type;
    [Export] public int Rarity;
    
    [ExportGroup("Texture"), Export]
    public IconResource Icon;

    [ExportGroup("ItemInfo"), Export]
    public PackedScene[] ItemAction; 
    [Export] public float Damage;
    [Export] public float UseSpeed;
    [Export] public ItemEffect[] initialEffects;
    [ExportSubgroup("Left spawns"),Export] public PackedScene LeftSpawnScene, AdditionalLeft, ThirdLeft;
    [ExportSubgroup("Right spawns"),Export] public PackedScene RightSpawnScene, AdditionalRight, ThirdRight;
    
}