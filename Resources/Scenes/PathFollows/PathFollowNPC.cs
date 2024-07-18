using Godot;
using System;
public partial class PathFollowNPC : PathFollow2D
{
    [Export]
    public float Speed = 100.0f;
    
    public bool IsTalking = false;

    public override void _Ready()
    {
        
    }
    
    public override void _PhysicsProcess(double delta)
    {
        if (IsTalking)
        {
            return;
        }
        ProgressRatio += Speed * (float)delta;
    }
}