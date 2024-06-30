using Godot;
using System;
public partial class MainMenuUI : CanvasLayer
{
	private void StartGame(){
		Global.Instance.goto_scene("res://Levels/TestLevel/TestLevel.tscn");
	}
}
