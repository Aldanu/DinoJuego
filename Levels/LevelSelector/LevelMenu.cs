using Godot;
using System;
using static Godot.GD;

public partial class LevelMenu : MarginContainer
{
	HBoxContainer gridbox;
	[Export] public int world;
	int numGrids = 1;
	int currentGrid = 1;
	int gridWidth = 590;

	public override void _Ready()
	{
		gridbox = GetNode<HBoxContainer>("VBoxContainer/HBoxContainer/TextureRect/ClipControl/GridBox");
		numGrids = gridbox.GetChildCount();
		foreach(GridContainer grid in gridbox.GetChildren()){
			int i=0;
			foreach(Level box in grid.GetChildren()){
				var id = i + 1;
				box.SetLevel(id, world+1);
				if(id > 1){
					box.SetLocked(true);
				}else{
					box.SetLocked(false);
				}
				i++;
			}
		}
	}
}
