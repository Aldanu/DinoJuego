using Godot;
using static Godot.GD;

public partial class CrossPath : Node2D
{
	[Export] public bool left;
	[Export] public bool right;
	[Export] public bool up;
	[Export] public bool down;
	
	public Vector2 ChangeDirection(Vector2 directionComing){
		//(1, 0) Der
		//(-1, 0) Izq
		//(0, 1) Aba
		//(0,-1) Arr
		if(directionComing.X > 0.5){
			right = false;
		}
		if(directionComing.X < -0.5){
			left = false;
		}
		if(directionComing.Y > 0.5){
			down = false;
		}
		if(directionComing.Y < -0.5){
			up = false;
		}
		bool isValid = false;
		var direction = (Randi() % 4);
		while(!isValid){
			direction = (Randi() % 4);
			if(left && direction == 0){
				isValid = true;
			}
			if(up && direction == 1){
				isValid = true;
			}
			if(right && direction == 2){
				isValid = true;
			}
			if(down && direction == 3){
				isValid = true;
			}
		}
		Vector2 newdirection = new Vector2(0, 0);
		switch(direction){
			case 0:
				newdirection =new Vector2(-1, 0);
				break;
			case 1:
				newdirection =new Vector2(0,-1);
				break;
			case 2:
				newdirection =new Vector2(1, 0);
				break;
			case 3:
				newdirection =new Vector2(0, 1);
				break;
			default:
				Print("oh no");
				break;
		}
		return newdirection;
	}
}
