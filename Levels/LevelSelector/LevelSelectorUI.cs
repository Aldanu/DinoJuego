using Godot;
using System;
public partial class LevelSelectorUI : CanvasLayer
{
	private readonly string _worldOneRoute = "res://Levels/WorldOneLevels/";
	private readonly string _worldTwoRoute = "res://Levels/WorldTwoLevels/";
	private readonly string _worldThirdRoute = "res://Levels/WorldThreeLevels/";
	private readonly string _worldFourthRoute = "res://Levels/WorldFourLevels/";
	private readonly string _worldFiveRoute = "res://Levels/WorldFiveLevels/";
	
	private void SelectLevel(int world){
		Global.Instance.goto_scene(_worldOneRoute + "TestLevel.tscn");
	}
}
