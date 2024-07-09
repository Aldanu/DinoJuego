using Godot;
using System;

public partial class enemytcs : CharacterBody2D
{
	public int speed = 40;
	public bool player_chase = false;
	public object player = null;

	public int health = 120;
	public bool player_inattack_zone = false;
	public bool can_take_damage = true;

	public override void _PhysicsProcess(double delta)
	{
		DealWithDamage();

		// if(	player_chase ){
		// 	// Vector2 position
		// 	Position += (player.Position - Position)/ speed;
		// 	GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("walk");

		// 	if(player.Position.X - Position.X < 0 ){
		// 		GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
		// 	}
		// 	else{
		// 		GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;				
		// 	}
		// }
		// else{
		// 	GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("walk");
		// }
		// MoveAndSlide();
	}

	private void _on_detection_area_body_entered(Node2D body)
	{
		player = body;
		player_chase = true;

	}

	private void _on_detection_area_body_exited(Node2D body)
	{
		player = null;
		player_chase = false;
	}

	public void enemy(){

	}

	private void _on_enemy_hitbox_body_entered(Node2D body)
	{
		if(body.HasMethod("player")){
			player_inattack_zone = false;
		}
	}

	private void _on_enemy_hitbox_body_exited(Node2D body)
	{
		if(body.HasMethod("player")){
			player_inattack_zone = false;
		}
	}

	public void DealWithDamage(){

		// if( player_inattack_zone && Globall.player_current_attack == true){
		if( player_inattack_zone ){
			if( can_take_damage == true){
				health = health -20;
				GetNode<Timer>("enemy_take_damage_cooldown").Start();
				can_take_damage = false;
				GD.Print("slime health ", health);
				if( health <= 0){
					this.QueueFree();
					// Self.QueueFree();					
					// self.queue_free()					
				}
			}

		}

	}

	public void _on_enemy_take_damage_cooldown_timeout(){
		can_take_damage = true;
	}
}
