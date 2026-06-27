using Dorozhniyi.scripts.bullet;
using Dorozhniyi.scripts.item;
using Dorozhniyi.scripts.weapon;
using Godot;

[GlobalClass]
public partial class BulletEffect : ItemEffect
{
    [Export] BulletResource resource;
    [Export] float offset = 0;
    
    public override void Apply(ItemAction effect)
    {
        if (effect is not SpawnAction bullet) return; 
        bullet.BulletResource = resource;
        bullet.SpawnOffset= offset;
    }
    
    
}