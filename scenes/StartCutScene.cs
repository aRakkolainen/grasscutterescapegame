using Godot;
using System;

public partial class StartCutScene : Node2D
{
	// Called when the node enters the scene tree for the first time.

	private AnimatedSprite2D animation ;
	public override void _Ready()
	{
		animation = GetNode<AnimatedSprite2D>("animation");
		animation.Play("default");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
