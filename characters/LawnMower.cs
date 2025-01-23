using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class LawnMower : CharacterBody2D
{
	[Export]
	private NavigationAgent2D _navigationAgent2D ;
	public const float runSpeed = 0.5f;
	private AnimatedSprite2D _animatedSprite2D;
	private CharacterBody2D player;
	public override void _Ready()
    {
        _animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		player = GetNode<CharacterBody2D>("/root/Main/Player");
		_animatedSprite2D.Play("followPlayer"); 
    }

	public override void _PhysicsProcess(double delta)
	{
		Vector2 direction = player.Position - Position;
		Velocity = direction * runSpeed;
        var collisionInfo = MoveAndCollide(Velocity * (float) delta);
		if(collisionInfo != null) {
			Player collisionObject = (Player)collisionInfo.GetCollider();
			collisionObject.Die();
			_animatedSprite2D.Stop();

		}
	}

	
}
