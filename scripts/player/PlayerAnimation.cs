using Godot;
using System;
using System.Collections.Generic;

public partial class PlayerAnimation : AnimatedSprite2D
{
	public enum AnimationState
	{
		Idle,
		Run,
		Roll
	}

	private Dictionary<AnimationState, string> AnimToName = new()
		{
			{ AnimationState.Idle, "idle" },
			{ AnimationState.Run , "run" },
			{ AnimationState.Roll, "roll" },
		};

	public void SetAnimationState(AnimationState state)
	{
		Play(AnimToName[state]);
	}
}
