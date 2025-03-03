using Godot;
using System;

public partial class Level1 : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PackedScene enemyScene = (PackedScene) ResourceLoader.Load("res://characters/lawn_mower_enemy.tscn");
		Node enemyInstance = enemyScene.Instantiate();
		LawnMower mower = (LawnMower) enemyInstance;
		mower.SetCurrentScene("Level1");
		AddChild(enemyInstance);

		PackedScene playerScene = (PackedScene) ResourceLoader.Load("res://characters/player.tscn");
		Player player = (Player) playerScene.Instantiate();
		player.SetCurrentScene("Level1");
		AddChild(player);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
