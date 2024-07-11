using Godot;
using System;

public partial class playertcs : CharacterBody2D
{
	public bool enemy_inattack_range = false;
	public bool enemy_attack_coldown = true;
	public int health = 160;
	public bool player_alive = true;
	
	public bool attack_ip = false;
	public int speed = 100;
	public String current_dir = "none";
	
	public override void _Ready()
	{
		GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("front_idle");
		
	}

	public override void _PhysicsProcess(double Delta)
	{
		PlayerMovement();
		EnemyAttack();
		Attack();
		
		
		
		if (health <= 0)
		{
			player_alive = false;
			health = 0;
			GD.Print("Player has been killed");	
			this.QueueFree();			
			// Self.QueueFree();
			// self.queue_free();
		}
		
		MoveAndSlide();
	}
	
	

	public void PlayAnim( int Movement )
	{
		AnimatedSprite2D Anim = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		String Dir = current_dir;
		
		if ( Dir == "right")
		{
			Anim.FlipH = false;
			if (Movement == 1)
			{
				Anim.Play("side_walk");	
			}
			else{
				if( Movement == 0 )
				{
					if( attack_ip == false )
					{
						Anim.Play("side_idle");
					}			
					
				}
			}
		}
		
		if(Dir == "left")
		{
			Anim.FlipH = true;
			if (Movement == 1)
			{
				Anim.Play("side_walk");	
			}
			else
			{
				if( Movement == 0 )
				{
					if( attack_ip == false )
					{
						Anim.Play("side_idle");
					}			
					
				}
			}
		}
		
		if(Dir == "down")
		{
			Anim.FlipH = true;
			if (Movement == 1)
			{
				Anim.Play("front_walk");
			}
			else
			{
				if( Movement == 0 )
				{
					if( attack_ip == false )
					{
						Anim.Play("front_idle");
					}			
					
				}
			}
		}
		
		if(Dir == "up")
		{
			Anim.FlipH = true;
			if (Movement == 1)
			{
				Anim.Play("back_walk");	
			}
			else
			{
				if( Movement == 0 )
				{
					if( attack_ip == false )
					{
						Anim.Play("back_idle");
					}			
					
				}
			}
		}
		
	}
	
	public void PlayerMovement()
	{
		Vector2 velocity = Velocity;
		if (Input.IsActionPressed("ui_right")){
			current_dir = "right";
			velocity.X = speed;
			velocity.Y = 0;
			PlayAnim(1);
		}
		else{
			if(Input.IsActionPressed("ui_left")){
				current_dir = "left";
				PlayAnim(1);
				velocity.X = -speed;
				velocity.Y = 0;		
			}
			else{
				if(Input.IsActionPressed("ui_down")){
					current_dir = "down";
					PlayAnim(1);
					velocity.X = 0;
					velocity.Y = speed;
				}
				else{
					if(Input.IsActionPressed("ui_up")){
						current_dir = "up";
						PlayAnim(1);
						velocity.X = 0;
						velocity.Y = -speed;
					}
					else{
						PlayAnim(0);
						velocity.X = 0;
						velocity.Y = 0;
					}
				}
			}
		}
		
		MoveAndSlide();
	}
	
	public void EnemyAttack(){
		if(enemy_inattack_range && enemy_attack_coldown == true) {
			health = health - 20;
			enemy_attack_coldown = false;
			GetNode<Timer>("attack_cooldown").Start();
			GD.Print(health);	
		}	
	}
	
	public void Attack(){
		String dir = current_dir;
	
		if(Input.IsActionPressed("buttonA")){
			// Globalttcs.player_current_attack = true;
			attack_ip = true;
			if(dir == "right"){
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = false;
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("side_attack");
				GetNode<Timer>("deal_attack_timer").Start();				
			}
			if(dir == "left"){
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").FlipH = true;
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("side_attack");
				GetNode<Timer>("deal_attack_timer").Start();				
			}
			if(dir == "down"){
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("front_attack");
				GetNode<Timer>("deal_attack_timer").Start();				
			}
			if(dir == "up"){
				GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("back_attack");
				GetNode<Timer>("deal_attack_timer").Start();				
			}
		}


	}
		
	
	
	private void _on_deal_attack_timer_timeout()
	{
		GetNode<Timer>("deal_attack_timer").Stop();
		// Globalttcs.player_current_attack = false;
		attack_ip = false;
	}


	private void _on_attack_cooldown_timeout()
	{
		enemy_attack_coldown = true;
	}


	private void _on_player_hitbox_body_entered(Node2D body)
	{
		if(body.HasMethod("enemy")){
			enemy_inattack_range = true;
		}
	}


	private void _on_player_hitbox_body_exited(Node2D body)
	{
		if(body.HasMethod("enemy")){
			enemy_inattack_range = false;			
		}
	}
}


// private void _on_deal_attack_timer_timeout()
// {
	// Replace with function body.
// }


// private void _on_attack_cooldown_timeout()
// {
	// Replace with function body.
// }


// private void _on_player_hitbox_body_entered(Node2D body)
// {
	// Replace with function body.
// }


// private void _on_player_hitbox_body_exited(Node2D body)
// {
	// Replace with function body.
// }
