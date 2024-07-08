using Godot;
using System;

using static Godot.GD;

public partial class Sprite2D : Godot.Sprite2D
{
	[Export]
	public float speed = 100;
	
	public Vector2 moveVector = Vector2.Zero;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Movement using Input functions:
		moveVector = Vector2.Zero;
		moveVector = Input.GetVector("ui_left","ui_right","ui_up","ui_down");
		Position  += moveVector * ((float)speed * (float)delta);
		
		if(Input.IsActionJustPressed("buttonA"))
		{
			Print("Button 1");

			var scene = Load<PackedScene>("res://Levels/TestLevel/Grenade.tscn");
			var instance = scene.Instantiate();
			AddChild(instance);

			//var grenade = new Grenade(); 
			//AddChild(grenade);
		}
		if(Input.IsActionJustPressed("buttonB"))
		{
			Print("Button 2");
		}
	}
}
