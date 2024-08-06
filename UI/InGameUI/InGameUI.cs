using Godot;
using System;
using static Godot.GD;

public partial class InGameUI : CanvasLayer
{
	bool isPaused = false;
	private Control _pauseControl;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_pauseControl = GetNode<Control>("Control");
	}
	
	private void onPauseButtonPressed()
	{
		isPaused = !isPaused;
		_pauseControl.Visible = isPaused;
		GetTree().Paused = isPaused;
	}
	
	private void onPauseButtonPressed(InputEvent @event)
	{
		if (@event is InputEventScreenTouch eventKey){
			if (eventKey.Pressed){
				isPaused = !isPaused;
				_pauseControl.Visible = isPaused;
				GetTree().Paused = isPaused;
			}
		}
	}
	
	private void onExitButtonPressed(InputEvent @event)
	{
		if (@event is InputEventScreenTouch eventKey){
			if (eventKey.Pressed){
				isPaused = false;
				GetTree().Paused = isPaused;
				Global.Instance.goto_scene($"res://Levels/Main.tscn");
			}
		}
	}
}




