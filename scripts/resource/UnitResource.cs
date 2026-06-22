using Godot;

namespace Dorozhniyi.scripts.resource;

[GlobalClass]
public partial class UnitResource : Resource
{
    [Export] public float MaxHealth;
    [Export] public float MaxSpeed;
    [Export] public float MaxXpRange;
    [Export] public float MinXpRange;
}