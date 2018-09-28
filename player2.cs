using Godot;
using System;

public class player2 : Area2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    [Export]
    public int Speed = 0;
    private Vector2 _screenSize;
    public void Start(Vector2 pos)
    {
        
        Position = pos;
    }
    public override void _Ready()
    {
        _screenSize = GetViewport().GetSize();
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _Process(float delta)
    {
        var velocity = new Vector2();
        if (Input.IsActionPressed("ui_right")) {
            velocity.x += 1;
        }

        if (Input.IsActionPressed("ui_left")) {
        velocity.x -= 1;
        }

        if (Input.IsActionPressed("ui_down")) {
        velocity.y += 1;
        }

        if (Input.IsActionPressed("ui_up")) {
        velocity.y -= 1;
        }

        var sprite = (Sprite) GetNode("Sprite");
        if (velocity.Length() >0)
        {
            velocity = velocity.Normalized() * Speed;
        }
        Position += velocity * delta;
        Position = new Vector2(Mathf.Clamp(Position.x, 0, _screenSize.x),Mathf.Clamp(Position.y, 0, _screenSize.y));

        // Called every frame. Delta is time since last frame.
        // Update game logic here.
        
    }
}
