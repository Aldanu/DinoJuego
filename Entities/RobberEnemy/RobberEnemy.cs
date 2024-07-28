using Godot;
using System;
using System.Threading.Tasks;
using static Godot.GD;

public partial class RobberEnemy : Node2D
{
	[Export] public int speed = 200;
	private AnimatedSprite2D _animatedSprite;
	public Vector2 moveVector = Vector2.Zero;
	
	public override void _Ready()
	{
		var _sprite2D = GetNode<Godot.Sprite2D>("Sprite2D");
		_animatedSprite = _sprite2D.GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		ChangeDirection();
		Print("ChangeDirection: "+moveVector);
		_animatedSprite.Play("BeforeSteal");
	}

	public override void _PhysicsProcess(double delta)
	{
		Position  += moveVector * ((float)speed * (float)delta);
	}
	
	private void ChangeDirection(){
		//(1, 0) Der
		//(-1, 0) Izq
		//(0, 1) Aba
		//(0,-1) Arr
		moveVector = new Vector2(1, 0);
	}
	
	
	private void OnArea2dAreaEntered(Area2D area)
	{
		var node = area.GetParent();
		if(node is Person){
			var stealNPC = Randi() % 3;
			if(stealNPC == 0){
				area.GetParent<Person>().DoSteal();
				_animatedSprite.Play("RobberEnemyRun");
			}
		}
		 if(node is CrossPath){
			Print("cross");
		 	var newDirection = area.GetParent<CrossPath>().ChangeDirection(moveVector);
			DelayMethod(newDirection);
		 }
	}

	
	private async void DelayMethod(Vector2 newDirection)
	{
		var waiting = (Randi() % 380) + 120; // Rango entre 120 - 499
		await Task.Delay(TimeSpan.FromMilliseconds(waiting));
		moveVector = newDirection;
	}
}


