using Dorozhniyi.scripts.bullet;
using Dorozhniyi.scripts.item;
using Dorozhniyi.scripts.weapon;
using Godot;

[GlobalClass]
public partial class BulletEffect : ItemEffect
{
    [Export] BulletResource resource;
    public override void Apply(ItemAction effect)
    {
        if (effect is SpawnAction bullet)
            bullet.BulletResource = resource;
    }
}