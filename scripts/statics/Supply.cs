using Godot;
using System;
using Dorozhniyi.interfaces;

public partial class Supply : StaticBody2D, IDamagable
{
	[Export] public float MaxHp;

	private float Hp;
	
	public override void _Ready()
	{
		Hp = MaxHp;
	}

	public void OnDeath()
	{
		QueueFree();
	}

	public void TakeDamage(float damage)
	{
		Hp -= damage;
		if (Hp <= 0) OnDeath();
	}
}
