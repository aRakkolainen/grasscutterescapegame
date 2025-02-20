using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public partial class LawnMower : CharacterBody2D
{
	[Export]
	private NavigationAgent2D _navigationAgent2D ;
	public const float runSpeed = 0.5f;
	private AnimatedSprite2D _animatedSprite2D;
	private CharacterBody2D player;

	private int currentLevel = 1; 

	public override void _Ready()
    {
		_animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		//scenePath = "/root/Level" + currentLevel;
		//scenePath += "/Player";
		player = GetNode<CharacterBody2D>("/root/Level1/Player");
    }

	public override void _PhysicsProcess(double delta)
	{
		//player = GetNode<CharacterBody2D>(scenePath);
		_animatedSprite2D.Play("followPlayer");
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

	
}
