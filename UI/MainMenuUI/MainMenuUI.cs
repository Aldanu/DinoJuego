using Godot;
using System;
public partial class MainMenuUI : CanvasLayer
{
	private void StartGame(){
		Global.Instance.goto_scene("res://Levels/TestLevel/TestLevel.tscn");
	}
	private void GotoSettings(){
		Global.Instance.goto_scene("res://Levels/SettingsLevel/SettingsLevel.tscn");
	}
	private void ExitGame(){
		Global.Instance.exitGame();
	}
}
