using Dorozhniyi.interfaces;
using Dorozhniyi.scripts.resource;
using Godot;

namespace Dorozhniyi.scripts.unit;

public partial class Entity : CharacterBody2D, IDamagable
{
    [Export] public UnitResource EntityResource;

    protected float MaxSpeed = 0, Speed = 0;
    protected float MaxHp = 0, Hp = 0;

    public override void _Ready()
    {
        MaxSpeed = EntityResource.MaxSpeed;
        MaxHp = EntityResource.MaxHealth;
        Hp = MaxHp;
    }

    public virtual void TakeDamage(float damage)
    {
        Hp -= damage;
        if (Hp <= 0)
            OnDeath();
    }
    
    public virtual void OnDeath() => QueueFree();
}