using Godot;
using System;

public class Main : Node
{
    [Export]
    public PackedScene Mob;
    public int Score = 0;
    // we wil use this many times so instattiating it allow our numbers to cinsistenly be random
    private Random rand = new Random();
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }
    private float RandRand(float min, float max)
    {
        return (float) (rand.NextDouble() * (max -min)+ min);
    }
    public void GameOver()
    {
        //timers
        var mobTimer = (Timer) GetNode("MobTimer");
        var scoreTimer = (Timer) GetNode("ScoreTimer");
        var music = (AudioStreamPlayer) GetNode("Music");
        music.Stop();

        var deathSound = (AudioStreamPlayer) GetNode("DeathSound");
        deathSound.Play();
        scoreTimer.Stop();
        mobTimer.Stop();
        var hud = (HUD) GetNode("HUD");
        hud.ShowGameOver();
    }
    public void NewGame()
    {
        var hud = (HUD) GetNode("HUD");
        var music = (AudioStreamPlayer) GetNode("Music");
        music.Play();
        
        Score = 0;
        hud.UpdateScore(Score);
        hud.ShowMessage("Get Ready!");
        var player = (Player) GetNode("Player");
        var startTimer = (Timer) GetNode("StartTimer");
        var startPosition = (Position2D) GetNode("StartPosition");

        player.Start(startPosition.Position);
        startTimer.Start();
    }
    public void OnStartTimerTimeout()
    {
        //timers
        var mobTimer = (Timer) GetNode("MobTimer");
        var scoreTimer = (Timer) GetNode("ScoreTimer");
        mobTimer.Start();
        scoreTimer.Start();
    }
    public void OnScoreTimerTimeout()
    {
        Score +=1;
        var hud = (HUD) GetNode("HUD");
        hud.UpdateScore(Score);
    }

    public void OnMobTimerTimeout()
    {
        //choose a location on path2d
        var mobSpawnLocation = (PathFollow2D) GetNode("MobPath/MobSpawnLocation");
        mobSpawnLocation.SetOffset(rand.Next());

        // create a mob instance and add it to the scene
        var mobInstance = (RigidBody2D) Mob.Instance();
        AddChild(mobInstance);

        // set the mobs direction perpendicular to the path directoin
        var direction = mobSpawnLocation.Rotation + Mathf.Pi /2;

        // set mobs position to random location
        mobInstance.Position = mobSpawnLocation.Position;
        // add some random to the direction
        direction += RandRand(-Mathf.Pi /4, Mathf.Pi /4);
        mobInstance.Rotation = direction;
        // choose the velocity
        mobInstance.SetLinearVelocity(new Vector2(RandRand(150f, 250f), 0).Rotated(direction));

    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
