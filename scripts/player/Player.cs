using Godot;
using System;
using Dorozhniyi.scripts.resource;
using Dorozhniyi.scripts.unit;

public partial class Player : Entity
{
	[Export] UnitResource playerResource;

	[Export] public float Acceleration = 300.0f; 
	[Export] public float Friction = 2000.0f;
	
	private float MaxSpeed = 0;
	private float MaxHp = 0;

	public Item OnHandItem = null;
	
	[Export] public PlayerAnimation PlayerAnimation;

	public override void _Ready()
	{
		MaxSpeed = playerResource.MaxSpeed;
	}

	public override void _PhysicsProcess(double delta)
	{
		float dt = (float)delta;
		Move(dt);
		PlayerAnimation.SetAnimationState(Velocity.Length() >= MaxSpeed/3
			? PlayerAnimation.AnimationState.Run
			: PlayerAnimation.AnimationState.Idle);
		MoveAndSlide();
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("lm"))
		{
			OnHandItem.EmitSignal(nameof(OnHandItem.LeftClick));
		}
	}

	public void Move(float move)
	{
		var direction = Input.GetVector("a", "d", "w", "s");
		Velocity = direction != Vector2.Zero ? Velocity.MoveToward(direction * MaxSpeed, Acceleration * move) : Velocity.MoveToward(Vector2.Zero, Friction * move);
	}
}
