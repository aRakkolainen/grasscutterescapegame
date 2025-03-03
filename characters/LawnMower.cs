using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

public partial class LawnMower : CharacterBody2D
{
	[Export]
	public float runSpeed = 0.5f;
	private AnimatedSprite2D _animatedSprite2D;
	private CharacterBody2D player;

	private int currentLevel = 1; 

	private string currentScene;


	public override void _Ready()
    {
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		StringBuilder builder = new StringBuilder();
		builder.Append("/root/");
		builder.Append(GetCurrentScene());
		builder.Append("/Player");
		GD.Print(builder.ToString());
		player = GetNode<CharacterBody2D>("../Player");
    }

	public override void _PhysicsProcess(double delta)
	{
		//player = GetNode<CharacterBody2D>(scenePath);
		_animatedSprite2D.Play("followPlayer");
		if(player == null) {
			return;
		}

		Vector2 direction = player.Position - Position;
		Velocity = direction * runSpeed;
        var collisionInfo = MoveAndCollide(Velocity * (float) delta);
		if(collisionInfo != null) {
			Node collisionObject = (Node)collisionInfo.GetCollider();
			 if (collisionObject.Name != null){
				if(collisionObject.Name == "Player") {
					Player player = (Player)collisionObject;
					player.Die();
					_animatedSprite2D.Stop();
					GetTree().ChangeSceneToFile("res://scenes/death_cut_scene.tscn");
				}else if (collisionObject.Name == "Level_Finish"){
					currentLevel++;
				}

		}
		}
	}

    private void OnSceneChanged(Node newScene)
    {
        GD.Print("Scene changed to:" + newScene.Name);
    }

	public void SetCurrentScene(string sceneName){
		currentScene = sceneName;
	}

	public string GetCurrentScene(){
		return currentScene;
	}

}
