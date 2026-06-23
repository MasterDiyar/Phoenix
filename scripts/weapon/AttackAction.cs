using Dorozhniyi.scripts.item;
using Dorozhniyi.scripts.unit;
using Godot;

namespace Dorozhniyi.scripts.weapon;

public partial class AttackAction : ItemAction
{
    protected override void ItemOnLeftClick(Vector2 fromPosition, Vector2 toPosition, Entity entity)
    {
        var damage = _item.ItemResource.Damage;
        GD.Print("attack: " + damage);
    }

    protected override void ItemOnRightClick(Vector2 fromPosition, Vector2 toPosition, Entity entity)
    {
        GD.Print("recharge");
    }
}