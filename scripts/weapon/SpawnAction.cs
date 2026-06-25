using System.Threading.Tasks;
using Dorozhniyi.scripts.bullet;
using Dorozhniyi.scripts.item;
using Dorozhniyi.scripts.unit;
using Godot;

namespace Dorozhniyi.scripts.weapon;

public partial class SpawnAction : ItemAction
{
    public enum WhatToSpawn
    {
        Bullet,
        Entity
    }
    [Export] public WhatToSpawn What;
    
    PackedScene lScene, rScene;
    public BulletResource BulletResource;

    public int SpawnCount = 1;
    public float SpawnOffset = 0, RotationOffset = 0, BetweenRotation = 0, SpawnTimeOffset = 0;

    public override void _Ready()
    {
        base._Ready();
        lScene = _parent.ItemResource.LeftSpawnScene;
        rScene = _parent.ItemResource.RightSpawnScene;
    }

    protected override void ParentOnLeftClick(Vector2 fromPosition, Vector2 toPosition, Entity entity)
    {
        if (_onUse) return;
        _onUse = true;
        switch (What)
        {
            case WhatToSpawn.Bullet:
                SpawnBullet(lScene, fromPosition, toPosition, entity);
                break;
        }
    }

    protected override void ParentOnRightClick(Vector2 fromPosition, Vector2 toPosition, Entity entity)
    {
        throw new System.NotImplementedException();
    }

    async Task SpawnBullet(PackedScene scene, Vector2 fromPosition, Vector2 toPosition, Entity entity)
    {
        var initialAngle = (toPosition-fromPosition).Angle();
        for (int i = 0; i < SpawnCount; i++)
        {
            var bullet = scene.Instantiate<Bullet>();
            bullet.SelfResource =  BulletResource;
            bullet.Rotation = initialAngle + RotationOffset +  BetweenRotation * i;
            bullet.Position = fromPosition + Vector2.FromAngle(initialAngle) * SpawnOffset;
            bullet.Init(_parent.ItemResource.Damage, entity);
            GetTree().CurrentScene.AddChild(bullet);
            if (SpawnTimeOffset > 0)
                await ToSignal(GetTree().CreateTimer(SpawnTimeOffset), "timeout");
        }
        _onUse =  false;
    }
}