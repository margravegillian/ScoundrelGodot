using Godot;
using System;

public class Character : Area2D
{
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    [Signal]
    public delegate void Hit();
    CollisionShape2D collisionShape2D;
   
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";
    [Export]
    public int Speed = 0; //how fast it will move
    private Vector2 _screenSize; // size of gme window
    public override void _Ready()
    {
        _screenSize = GetViewport().GetSize();
        //collisionShape2D = (CollisionShape2D) GetNode("CollisionShape2D");
        collisionShape2D = (CollisionShape2D) GetNode("CollisionShape2D");
       // Hide();
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
    public void Start(Vector2 pos)
    {
        Position = pos;
        Show();
        collisionShape2D.Disabled = false;
    }

    public override void _Process(float delta)
    {
        var velocity = new Vector2(); // The player's movement vector.
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
        if (velocity.Length() > 0) {
            velocity = velocity.Normalized() * Speed;
           // animatedSprite.Play();
        } else {
           // animatedSprite.Stop();
        }
        
        Position += velocity * delta;
        Position = new Vector2(Mathf.Clamp(Position.x, 0, _screenSize.x),Mathf.Clamp(Position.y, 0, _screenSize.y));


        if (velocity.x !=0 )
        {
            //animatedSprite.Animation = "right";
            //animatedSprite.FlipH  = velocity.x <0;
            //animatedSprite.FlipV = false;
        }
        else if (velocity.y != 0)
        {
            //animatedSprite.Animation = "up";
            //animatedSprite.FlipV = velocity.y >0;
        }

   
    }
    public void OnPlayerBodyEntered(Godot.Object body)
    {
        Hide();
        EmitSignal("Hit");
        collisionShape2D.Disabled = true;

    }
}
