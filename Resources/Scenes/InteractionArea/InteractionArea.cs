using Godot;
using System;

public partial class InteractionArea : Area2D
{
	public String actionName= "Interact";


	public Callable interact()
	{
		return new Callable(this, "Interact");
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
