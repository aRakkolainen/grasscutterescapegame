using Godot;
using System;

public partial class StartCutScene : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private bool animationFinished = false;
	private AnimatedSprite2D animation ;
	public override void _Ready()
	{
		animationFinished = false;
		//GetTree().ChangeSceneToFile("res://scenes/level_1.tscn");
	}

    private void OnCutSceneFinished()
    {
        GD.Print("Start cutscene has ended!");
		GetTree().ChangeSceneToFile("res://scenes/level_1.tscn");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		animation = GetNode<AnimatedSprite2D>("animation");
		if(animation.IsPlaying() && animation.Frame == animation.SpriteFrames.GetFrameCount("default")-1){
			if(!animationFinished){
				animationFinished = true;
				OnCutSceneFinished();
			}
		}

	}
}
