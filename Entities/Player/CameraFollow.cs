using Godot;

namespace DinoJuegoBeta.Resources.Scenes.Player;

public partial class CameraFollow : Camera2D
{
    [Export]
    public NodePath PlayerPath;

    private Node2D _player;

    public override void _Ready()
    {
        _player = GetNode<Node2D>(PlayerPath);
    }

    public override void _Process(double delta)
    {
        if (_player != null)
        {
            Position = _player.Position;
        }
    }
}