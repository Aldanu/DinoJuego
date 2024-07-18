using Godot;
using System;
using System.Collections.Generic;


public partial class InteractionManager : Node2D
{
    private Node player;

    private Label label;

    private List<InteractionArea> activeAreas = new List<InteractionArea>();
    
    private bool canInteract = true;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        player = GetTree().GetFirstNodeInGroup("player");
        label = GetNode<Label>("Label");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (activeAreas.Count>0 && canInteract)
        {
            // activeAreas.Sort(sortByDistanceToPlayer);
            label.Text = activeAreas[0].actionName;
            
            label.GlobalPosition = activeAreas[0].GlobalPosition;
            // label.SetGlobalPosition();
            // label.GlobalPosition.Y -= 36;
            //
            // label.GlobalPosition.X -= label.Size.X/2;
            label.Show();
        }
        else
        {
            label.Hide();
        }
    }
    
    // public bool sortByDistanceToPlayer(InteractionArea a, InteractionArea b)
    // {
    //     float area1ToPlayer = player.GlobalPosition.DistanceTo(a.GlobalPosition);
    //     float area2ToPlayer = player.GlobalPosition.DistanceTo(b.GlobalPosition);
    //     return area1ToPlayer < area2ToPlayer;
    // }

    public void input(InputEvent inputEvent)
    {
        if (inputEvent.IsActionPressed("ui_interact") && canInteract)
        {
            if (activeAreas.Count>0)
            {
                canInteract = false;
                label.Hide();
                activeAreas[0].interact().Call();
                canInteract = true;
            }
        }
    }

    public void registerArea(InteractionArea area)
    {
        activeAreas.Add(area);
    }

    public void unregisterArea(InteractionArea area)
    {
        int index = activeAreas.IndexOf(area);
        if (index != -1)
        {
            activeAreas.RemoveAt(index);
        }
    }
    
}