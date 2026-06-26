
using Godot;

[GlobalClass]
public partial class IconResource : Resource
{
    [Export]public Texture2D ItemIcon;
    [Export] public bool HFlip = false;   
    [Export] public bool VFlip = false;
    [Export] public int HFrames;
    [Export] public Vector2 Offset;
    [Export(PropertyHint.Max, "10")] public int FPS;
}