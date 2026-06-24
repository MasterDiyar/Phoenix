
using Dorozhniyi.scripts.item;
using Dorozhniyi.scripts.weapon;
using Godot;

[GlobalClass]
public partial class MultiSpawn : ItemEffect
{
    [Export] private int _count = 1;
    [Export] private float _spawnOffset = 0, _rotationOffset = 0, _betweenRotation = 0, _spawnTimeOffset = 0;
    public override void Apply(ItemAction effect)
    {
        if (effect is SpawnAction sa)
        {
            sa.SpawnCount =  _count;
            sa.SpawnOffset = _spawnOffset;
            sa.RotationOffset = _rotationOffset;
            sa.BetweenRotation = _betweenRotation;
            sa.SpawnTimeOffset = _spawnTimeOffset;
        }
    }
}