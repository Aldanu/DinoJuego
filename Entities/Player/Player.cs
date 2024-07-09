using Godot;
using System;

using static Godot.GD;

public partial class Player : CharacterBody2D
{
	[Export] public int speed = 200;
	private AnimatedSprite2D _animatedSprite;
	private bool isActing = false;
	public Vector2 moveVector = Vector2.Zero;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		var _sprite2D = GetNode<Godot.Sprite2D>("Sprite2D");
		_animatedSprite = _sprite2D.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animatedSprite.Play("playerIdle");
	}
	public override void _Process(double delta)
	{
		moveVector = Vector2.Zero;
		moveVector = Input.GetVector("ui_left","ui_right","ui_up","ui_down");
		AnimateCharacter(moveVector);
		Position  += moveVector * ((float)speed * (float)delta);
		
		if(Input.IsActionJustPressed("buttonA"))
		{
			_animatedSprite.Stop();
			isActing=true;
			Print("Button 1");
			_animatedSprite.Play("playerSkillNoViolence");
			var scene = Load<PackedScene>("res://Levels/TestLevel/Grenade.tscn");
			var instance = scene.Instantiate();
			AddChild(instance);
		}
		if(Input.IsActionJustPressed("buttonB"))
		{
		}
	}
	public void OnAnimatedSprite2dAnimationFinished()
	{
		isActing = false;
	}

	private void AnimateCharacter(Vector2 moveVector){
		if(moveVector.X < 0){
			_animatedSprite.FlipH = true;
		}
		if(moveVector.X > 0){
			_animatedSprite.FlipH = false;
		}
		if(!isActing){
			if(moveVector != Vector2.Zero ){
				_animatedSprite.Play("playerRun");
			}else{
				_animatedSprite.Play("playerIdle");
			}
		}
	}
}
