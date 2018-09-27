using Godot;
using System;

public class Mob : RigidBody2D
{
    [Export]
    public int MinSped = 150; // min speed range
    [Export]
    public int MaxSpeed = 250; // max speed range
    public String[] _mobTypes = {"walk", "swim", "fly"};
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        var animatedSprite = (AnimatedSprite) GetNode("AnimatedSprite");
        // c# doesnt implement gdscript random methonds so use random as alternative
        //never do multiple times make a calss and use it for real game 
        //todo:
        var randomMob = new Random();
        animatedSprite.Animation = _mobTypes[randomMob.Next(0, _mobTypes.Length)];

        
    }
    public void OnVisibilityScreenExited() => QueueFree();

    //    public override void _Process(float delta)
    //    {
    //        // Called every frame. Delta is time since last frame.
    //        // Update game logic here.
    //        
    //    }
}
