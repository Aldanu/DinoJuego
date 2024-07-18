using Godot;
using System;
using static Godot.GD;
public partial class Person : CharacterBody2D
{
	
	private bool playerNearby = false;
	private Label dialogLabel;
	
	[Export]
	public string dialogText = "Hello, you are not like me?!";
	
	private bool isTalking = false;
	private bool playerIsNearby = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// dialogLabel = GetNode<Label>("../DialogLabel");

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void _Process(double delta)
	{
		if (playerNearby && Input.IsActionJustPressed("ui_accept"))
		{
			Interact();
		}
	}

	private void Interact()
	{
		Print(dialogText);
		dialogLabel.Text = dialogText;
		dialogLabel.Visible = true;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			playerNearby = true;
		}
	}

	private void OnBodyExited(Node2D body)
	{
		if (body is Player)
		{
			playerNearby = false;
			dialogLabel.Visible = false;
		}
	}
}
