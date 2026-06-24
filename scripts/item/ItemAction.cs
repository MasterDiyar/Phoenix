using Dorozhniyi.scripts.unit;
using Godot;

namespace Dorozhniyi.scripts.item;

public abstract partial class ItemAction : Node2D
{
    protected Item _item;

    public override void _Ready()
    {
        _item = GetParent<Item>();
        _item.LeftClick += ItemOnLeftClick;
        _item.RightClick += ItemOnRightClick;
    }

    public void UnBind()
    {
        _item.LeftClick -= ItemOnLeftClick;
        _item.RightClick -= ItemOnRightClick;
    }

    protected abstract void ItemOnLeftClick(Vector2 fromPosition, Vector2 toPosition, Entity entity);
    protected abstract void ItemOnRightClick(Vector2 fromPosition, Vector2 toPosition, Entity entity);
}