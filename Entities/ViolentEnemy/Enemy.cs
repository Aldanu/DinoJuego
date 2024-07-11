using Godot;
using static Godot.GD;
public partial class Enemy : Node2D
{
	//We'll use either a constant speed or one that is quick at the start and slows down quickly
	[Export]
	bool useConstantSpeed = false;
	[Export]
	float lerpWeight = 5;
	[Export]
	float pushbackSpeed = 350;
	[Export]
	float pushbackCompleteDistance = 1f;

	Vector2 targetPosition = Vector2.Zero;
	bool isBeingPushed = false;
	bool isFigthing = true;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (isBeingPushed && isFigthing){
			if (useConstantSpeed){
				Position += Position.DirectionTo(targetPosition) * (float)(pushbackSpeed * delta);
			}else{
				Position = Lerp(Position, targetPosition, (float)(lerpWeight * delta));
				if (Position.DistanceTo(targetPosition) < pushbackCompleteDistance){
					Position = targetPosition;
					isBeingPushed = false;
					isFigthing = false;
				}
			}

		}
	}

	public void DoPushback(Vector2 grenadePosition, int pushbackStrength){
		Vector2 direction = GlobalPosition - grenadePosition;
		Print("DoPushback: " + direction);
		targetPosition = Position + direction.Normalized() * pushbackStrength;
		Print("targetPosition: " + targetPosition);
		isBeingPushed = true;
	}
	private Vector2 Lerp(Vector2 firstVector, Vector2 secondVector, float by)
	{
		float retX = Lerp(firstVector.X, secondVector.X, by);
		float retY = Lerp(firstVector.Y, secondVector.Y, by);
		Vector2 vector2 = new Vector2(retX, retY);
		return vector2;
	}
	private float Lerp(float firstFloat, float secondFloat, float by)
{
	 return firstFloat * (1 - by) + secondFloat * by;
}
}
