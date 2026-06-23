using Godot;

namespace Dorozhniyi.scripts.bullet;

public partial class Bullet : Area2D
{
    [Export] public BulletResource SelfResource;
    [Export] public Sprite2D SelfTexture;
    
    public float Speed, Damage, Acceleration;

    public override void _Ready()
    {
        Speed = SelfResource.Speed;
        Acceleration = SelfResource.Acceleration;
    }

    public void Init(float damage)
    {
        Damage = damage * SelfResource.DamageMultiplier;
    }
}