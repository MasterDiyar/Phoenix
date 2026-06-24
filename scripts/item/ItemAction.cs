using Dorozhniyi.scripts.unit;
using Godot;

namespace Dorozhniyi.scripts.item;

public abstract partial class ItemAction : Node2D
{
    protected Item _parent;
    protected bool _onUse = false;

    public override void _Ready()
    {
        _parent = GetParent<Item>();
        _parent.LeftClick += ParentOnLeftClick;
        _parent.RightClick += ParentOnRightClick;
    }

    public void UnBind()
    {
        _parent.LeftClick -= ParentOnLeftClick;
        _parent.RightClick -= ParentOnRightClick;
    }

    protected abstract void ParentOnLeftClick(Vector2 fromPosition, Vector2 toPosition, Entity entity);
    protected abstract void ParentOnRightClick(Vector2 fromPosition, Vector2 toPosition, Entity entity);
}