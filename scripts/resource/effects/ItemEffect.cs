
using Dorozhniyi.scripts.item;
using Godot;

[GlobalClass]
public abstract partial class ItemEffect : Resource
{
    public bool IsBinded = false;
    public virtual void Init(Item item)
    {
        if (IsBinded) return;
        IsBinded = true;
        item.ActionAdded += Apply;
    }
    
    public abstract void Apply(ItemAction effect);
}