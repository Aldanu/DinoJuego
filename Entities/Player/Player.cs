using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export] public int Speed = 200;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsActionPressed("ui_right"))
		{
			velocity.X += 1;
		}
		if (Input.IsActionPressed("ui_left"))
		{
			velocity.X -= 1;
		}
		if (Input.IsActionPressed("ui_down"))
		{
			velocity.Y += 1;
		}
		if (Input.IsActionPressed("ui_up"))
		{
			velocity.Y -= 1;
		}

		velocity = velocity.Normalized() * Speed;
		Velocity = velocity;
		MoveAndSlide();
	}
}
