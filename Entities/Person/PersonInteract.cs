using Godot;
using System;

public partial class PersonInteract : CharacterBody2D
{
	
	private bool _playerNearby = false;
	private Label _dialogLabel;
	
	[Export]
	public string DialogText = "Hello, you are not like me?!";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_dialogLabel = GetNode<Label>("../DialogLabel");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.

	public override void _Process(double delta)
	{
		if (_playerNearby && Input.IsActionJustPressed("ui_accept"))
		{
			Interact();
		}
	}

	private void Interact()
	{
		_dialogLabel.Text = DialogText;
		_dialogLabel.Visible = true;
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body is Player)
		{
			_playerNearby = true;
		}
	}

	private void OnBodyExited(Node2D body)
	{
		if (body is Player)
		{
			_playerNearby = false;
			_dialogLabel.Visible = false;
		}
	}
}
