using Godot;
using System;
using Dorozhniyi.scripts.item;
using Dorozhniyi.scripts.unit;

public partial class Item : Node2D
{
	[Export] public ItemResource ItemResource;
	[Export] public Sprite2D ItemIcon;
	[Signal] public delegate void LeftClickEventHandler(Vector2 fromPosition, Vector2 toPosition, Entity entity);
	[Signal] public delegate void RightClickEventHandler(Vector2 fromPosition, Vector2 toPosition, Entity entity);
	
	[Signal] public delegate void ActionAddedEventHandler(ItemAction action);
	public override void _Ready()
	{
		if (ItemResource == null) return;
		foreach (var effect in ItemResource.initialEffects)
		{
			effect.Init(this);
		}
		
		foreach (var node in ItemResource.ItemAction)
		{
			var act = node.Instantiate<ItemAction>();
			AddChild(act);
			EmitSignal(SignalName.ActionAdded, act);
		}

		var ce = ItemResource.Icon;
		ItemIcon.Texture = ce.ItemIcon;
		ItemIcon.Offset = ce.Offset;
		ItemIcon.FlipH = ce.HFlip;
		ItemIcon.FlipV = ce.VFlip;
	}
	
	public void SetItemResource(ItemResource itemResource)
	{
		foreach (var node in GetChildren()) {
			if (node is not ItemAction act) continue;
			act.UnBind();
			act.QueueFree();
		}
		ItemResource = itemResource;
		_Ready();
	}
}
