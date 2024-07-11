using Godot;
using static Godot.GD;

public partial class Grenade : Node2D
{
	[Export]
	int milisecondsToDisappear = 2000;
	[Export]
	Area2D area2D;
	[Export]
	int pushbackStrength = 100;
	[Export]
	float speed = 200;

	// Called when the node enters the scene tree for the first time.
	public override async void _Ready()
	{
		// var a = GetChildCount();
		// Print("a: "+ a);
		// var b = GetChildren();
		// foreach(Node bb in b){
		// 	Print("bb: "+ bb);
		// }
		// area2D= GetChild<Area2D>(0);
		// Explode();
		
	}

	// private void Explode(){
	// 	Print("Boom!...");
	// 	Print("area! "+ area2D);
	// 	var bodies = area2D.GetOverlappingBodies();
	// 	foreach (var body in bodies){
	// 		Print("body: "+ body.Name);
	// 		if(body.IsInGroup("somegroup")){
	// 			Print("collisions!");
	// 		}
	// 	}
	// }
	private void On2dAreaEntered(Area2D area)
	{
		var node = area.GetParent();
		if(node is Enemy){
			Vector2 oldVect=Vector2.Right.Rotated(Rotation);
			Vector2 newVect=new Vector2(GlobalPosition.X, GlobalPosition.Y);
			Print("old x: "+ oldVect.X +"old y: "+ oldVect.Y);
			Print("new x: "+ GlobalPosition.X +"new y: "+ GlobalPosition.Y);
			area.GetParent<Enemy>().DoPushback(newVect, pushbackStrength);
		}
		QueueFree();
	}

}

