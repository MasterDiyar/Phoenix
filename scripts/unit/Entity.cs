using Dorozhniyi.scripts.resource;
using Godot;

namespace Dorozhniyi.scripts.unit;

public partial class Entity : CharacterBody2D
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
        
    }
}