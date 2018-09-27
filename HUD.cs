using Godot;
using System;

public class HUD : CanvasLayer
{
    [Signal]
    public delegate void StartGame();
   
    // Member variables here, example:
    // private int a = 2;
    // private string b = "textvar";

    public void ShowMessage(string text)
    {
        var messageTimer = (Timer) GetNode("MessageTimer");
        var messageLabel = (Label) GetNode("MessageLabel");
        messageLabel.Text = text;
        messageLabel.Show();
        messageTimer.Start();
    }
    async public void ShowGameOver()
    {
        var startButton = (Button) GetNode("StartButton");
        var messageTimer = (Timer) GetNode("MessageTimer");
        var messageLabel = (Label) GetNode("MessageLabel");

        ShowMessage("Game Over");
        await ToSignal(messageTimer, "timeout");
        messageLabel.Text = "Dodge the\nCreeps!";
        messageLabel.Show();
        startButton.Show();
    }
    public void UpdateScore(int score)
    {
        var scoreLabel = (Label) GetNode("ScoreLabel");
        scoreLabel.Text = score.ToString();
    }
    public void OnStartButtonPressed()
    {
        var startButton = (Button) GetNode("StartButton");
        startButton.Hide();
        EmitSignal("StartGame");
    }
    public void OnMessageTimerTimeout()
        {
            var messageLabel = (Label) GetNode("MessageLabel");
            messageLabel.Hide();
        }
    
    

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
