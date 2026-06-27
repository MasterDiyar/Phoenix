using Godot;

[GlobalClass]
public partial class BulletResource : Resource
{
    [Export] public Texture2D Icon;
    [Export] public int HFrame;
    [Export] public int FPS;
    [Export] public Vector2 Where = Vector2.Right;
    [Export] public bool HasAnimates = false;
    
    [ExportCategory("Attributes")]
    [Export] public float DamageMultiplier = 1;
    [Export] public float Speed;
    [Export] public float Acceleration;
    [Export] public float LifeTime;

}