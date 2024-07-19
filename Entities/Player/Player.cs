using Godot;
using Microsoft.VisualBasic;
using System;

using static Godot.GD;

public partial class Player : CharacterBody2D
{
	[Export] public int speed = 200;
	private AnimatedSprite2D _animatedSprite;
	private bool isActing = false;
	public Vector2 moveVector = Vector2.Zero;
	
	public bool enemyInattackRange = false;
	public bool enemyAttackCooldown = true;
	public bool attackIp = false;

	public override void _Ready()
	{
		var _sprite2D = GetNode<Godot.Sprite2D>("Sprite2D");
		_animatedSprite = _sprite2D.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_animatedSprite.Play("playerIdle");
	}
	public override void _Process(double delta)
	{
		AnimateCharacter(moveVector);
		Interaction();
		EnemyAttack();
	}
	
	public override void _PhysicsProcess(double delta)
	{
		GetInput();
		MoveAndSlide();
	}
	
	private void GetInput(){
		moveVector = Input.GetVector("ui_left","ui_right","ui_up","ui_down");
		Velocity = moveVector * (float)speed;
	}
	
	public void OnAnimatedSprite2dAnimationFinished()
	{
		isActing = false;
	}

	private void Interaction(){
		if(Input.IsActionJustPressed("buttonA"))
		{
			_animatedSprite.Stop();
			isActing=true;
			Print("Button 1");
			_animatedSprite.Play("playerSkillNoViolence");
			var scene = Load<PackedScene>("res://Levels/TestLevel/Grenade.tscn");
			var instance = scene.Instantiate();
			GetNode<Timer>("DealAttackTimer").Start();
			AddChild(instance);
		}
		if(Input.IsActionJustPressed("buttonB"))
		{
		}
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

	public void EnemyAttack(){
		if(enemyInattackRange && enemyAttackCooldown == true) {
			enemyAttackCooldown = false;
			GetNode<Timer>("AttackCooldown").Start();
		}	
	}
		private void OnDealAttackTimerTimeout()
	{
		GetNode<Timer>("DealAttackTimer").Stop();
		// Globalttcs.player_current_attack = false;
		attackIp = false;
	}


	private void OnAttackCooldownTimeout()
	{
		enemyAttackCooldown = true;
	}


	private void OnPlayerHitboxBodyEntered(Node2D body)
	{
		if(body.HasMethod("enemy")){
			enemyInattackRange = true;
		}
	}


	private void OnPlayerHitboxBodyExited(Node2D body)
	{
		if(body.HasMethod("enemy")){
			enemyInattackRange = false;			
		}
	}
}
