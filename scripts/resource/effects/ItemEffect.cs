
using Dorozhniyi.scripts.item;
using Godot;

[GlobalClass]
public abstract partial class ItemEffect : Resource
{
    public virtual void Init(Item item)
    {
        item.ActionAdded += Apply;
    }
    
    public abstract void Apply(ItemAction effect);
}