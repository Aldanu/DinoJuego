using Godot;
using System;

using static Godot.GD;

[Tool]
public partial class Level :  Godot.PanelContainer
{
	Signal levelSelected;
	[Export] public bool locked;
	[Export] public int levelId;
	public int world;

	TextureRect lockSprite;
	TextureRect labelSprite;
	Label label;

	public override void _Ready(){
		label = GetNode<Label>("TextureLabel/Label");
		lockSprite = GetNode<TextureRect>("MarginContainer/TextureRect");
		labelSprite = GetNode<TextureRect>("TextureLabel");
		SetLocked(locked);
		SetLevel(levelId, 0);
	}
	public async void SetLocked(bool lookedLevel)
	{
		locked = lookedLevel;
		lockSprite.Visible = lookedLevel;
		label.Visible = !lookedLevel;
		labelSprite.Visible = !lookedLevel;
	}
	public void SetLevel(int id, int worldId)
	{
		levelId = id;
		world = worldId;
		label.Text = levelId.ToString();
	}

	public void OnGuiInput(InputEvent @event){
		if(locked){
			return;
		}
		if (@event is InputEventScreenTouch eventKey){
			if (eventKey.Pressed){
				Print("Clicked level " + world + " - " + levelId);
			}
		}
	}
}
