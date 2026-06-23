using Godot;
using System;
using Dorozhniyi.scripts.unit;

public partial class Item : Node2D
{
	[Export] public ItemResource ItemResource;
	
	[Signal] public delegate void LeftClickEventHandler(Vector2 fromPosition, Vector2 toPosition, Entity entity);
	[Signal] public delegate void RightClickEventHandler(Vector2 fromPosition, Vector2 toPosition, Entity entity);

	public override void _Ready()
	{
		AddChild(ItemResource.ItemAction.Instantiate());
		//AddChild(ItemResource.ItemIcon.Instantiate());
	}
}
