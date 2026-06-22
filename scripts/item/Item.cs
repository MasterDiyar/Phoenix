using Godot;
using System;
using Dorozhniyi.scripts.unit;

public partial class Item : Node2D
{
	[Export] public Node2D ItemIcon;
	[Export] public PackedScene ItemAction;
	
	[Signal] public delegate void LeftClickEventHandler(Vector2 fromPosition, Vector2 toPosition, Entity entity);
	[Signal] public delegate void RightClickEventHandler(Vector2 fromPosition, Vector2 toPosition, Entity entity);
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
