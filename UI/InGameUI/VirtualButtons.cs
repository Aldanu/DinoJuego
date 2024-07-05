using Godot;
using System;
using static Godot.GD;

public partial class VirtualButtons : Control
{
	string ButtonA = "buttonA";
	string ButtonB = "buttonB";
	string action_up = "ui_up";
	string action_down = "ui_down";
	Vector2 output = Vector2.Zero;
	public void TouchScreenButtona(int buttonId)
	{
	}

	public void FirstAbility()
	{
			Input.ActionPress(ButtonA);
			Input.ActionRelease(ButtonA);
	}

	public void SecondAbility()
	{
			Input.ActionRelease(ButtonB);
			Input.ActionPress(ButtonB);
	}

	public void ThirdAbility()
	{
			Input.ActionRelease(action_up);
			Input.ActionPress(action_down, output.Y);
	}

	public void FourthAbility()
	{
			Input.ActionRelease(action_down);
			Input.ActionPress(action_up, -output.Y);
	}
}
