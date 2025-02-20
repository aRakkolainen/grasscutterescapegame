using System;
using Godot;


public partial class Player : CharacterBody2D
{
	[Export]
    public int speed { get; set; } = 400;
    public int currentLevel {get; set;}  = 1;
    private AnimatedSprite2D _animatedSprite;

    public Boolean playerIsAlive;

     public override void _Ready()
    {
        _animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        playerIsAlive = true;
    }

    public void GetInput()
    {
        Vector2 inputDirection = Input.GetVector("left", "right", "up", "down");
        Velocity = inputDirection * speed;
    }

    public override void _PhysicsProcess(double delta)
    {
        if(!playerIsAlive){
            return;
        }

        GetInput();

        if(Input.IsActionPressed("left")) {
            _animatedSprite.Play("move_left");
        } else if(Input.IsActionPressed("right")){
            _animatedSprite.Play("move_right");
        } else if(Input.IsActionPressed("up")){
            _animatedSprite.Play("jump");
        } 
        else {
            _animatedSprite.Play("default");
        }
        


        var collision = MoveAndCollide(Velocity * (float)delta);
        if (collision != null){
            Node collisionObject = (Node) collision.GetCollider();
            GD.Print("I collided with ", collisionObject.Name);
            if (collisionObject.Name != null){
                if (collisionObject.Name == "Level_Finish"){
                    SwitchLevelScene();
                }
            }
        }

    }

    public void Die(){
        GD.Print("YOU DIED!");
        playerIsAlive = false;
        _animatedSprite.Stop();

    }

    public void SwitchLevelScene(){
        currentLevel++;
        String sceneName = "res://scenes/level_";
        sceneName += currentLevel;
        sceneName += ".tscn";
        GetTree().ChangeSceneToFile(sceneName);
    }
	
}
