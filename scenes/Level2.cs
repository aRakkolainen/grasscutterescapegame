using Godot;
using System;

public partial class Level2 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PackedScene enemyScene = (PackedScene) ResourceLoader.Load("res://characters/lawn_mower_enemy.tscn");
		Node enemyInstance = enemyScene.Instantiate();
		LawnMower mower = (LawnMower) enemyInstance;
		mower.SetCurrentScene("Level2");
		AddChild(mower);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
