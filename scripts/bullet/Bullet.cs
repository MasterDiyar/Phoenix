using Dorozhniyi.scripts.unit;
using Godot;

namespace Dorozhniyi.scripts.bullet;

public partial class Bullet : Area2D
{
    [Export] public BulletResource SelfResource;
    [Export] public Sprite2D SelfTexture;
    [Export] public Timer SelfTimer;
    
    public float Speed, Damage, Acceleration;
    public Entity Shooter;
    public bool selfDamage = false;

    public override void _Ready()
    {
        Speed = SelfResource.Speed;
        Acceleration = SelfResource.Acceleration;
        SelfTexture.Texture = SelfResource.Icon;
        SelfTimer.Start(SelfResource.LifeTime);
        SelfTimer.Timeout += QueueFree;
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Entity ent)
        {
            if (ent == Shooter && !selfDamage)
                return;
            

        }
        
    }

    public override void _Process(double delta)
    {
        Position += Vector2.FromAngle(Rotation) * Speed* (float)delta;
        Speed +=  Acceleration * (float)delta;
        
    }

    public void Init(float damage, Entity shooter)
    {
        Damage = damage * SelfResource.DamageMultiplier;
        Shooter = shooter;
    }
}