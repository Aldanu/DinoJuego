using Godot;
using System;

public partial class PersonMovement : CharacterBody2D
{
	[Export]
	public float Speed = 100.0f;

	private PathFollow2D _pathFollow;
	private Vector2 _lastPosition;

	public override void _Ready()
	{
		_pathFollow = GetNode<PathFollow2D>("../Path/PathFollow");
		_lastPosition = _pathFollow.Position;
	}

	public override void _PhysicsProcess(double delta)
	{
		_pathFollow.Progress += Speed * (float)delta;
		Vector2 direction = (_pathFollow.Position - _lastPosition).Normalized();
		Velocity = direction * Speed;
		_lastPosition = _pathFollow.Position;
		MoveAndSlide();
	}
}
