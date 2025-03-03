using System;
using Godot;


public partial class Player : CharacterBody2D
{
	[Export]
    public int speed { get; set; } = 400;
    public int currentLevel {get; set;}  = 1;
    private AnimatedSprite2D _animatedSprite;

    private string newSceneName; 
    public bool playerIsAlive;

    public string currentScene;

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
        string currentSceneName = GetTree().CurrentScene.Name;
        string[] currentSceneParts = currentSceneName.Split("_");
        int currentLevel = int.Parse(currentSceneParts[1]);
        
        if(currentLevel == 3) {
            GD.Print("You won!");
            newSceneName = "res://scenes/victory_scene.tscn";
        }
        currentLevel++;
        newSceneName = "res://scenes/level_" + currentLevel + ".tscn";

        GD.Print("You are at scene: " + currentSceneName);
        GD.Print("You are switching to scene: " + newSceneName);
        GetTree().ChangeSceneToFile(newSceneName);
    }

    public int GetCurrentLevel(){
        return currentLevel;
    }

    public void SetCurrentScene(string sceneName){
		currentScene = sceneName;
	}

	public string GetCurrentScene(){
		return currentScene;
	}
	
}
