using Godot;
using System;

public partial class Hand : Sprite2D
{
	[Export] public float maxOffset = 9f;
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		var maxLen = Mathf.Clamp((GetGlobalMousePosition()-GlobalPosition).Length() /  (10 * maxOffset), 0, maxOffset);
		Position = Vector2.FromAngle((GetGlobalMousePosition()-GlobalPosition).Angle())  * maxLen;
	}
}
