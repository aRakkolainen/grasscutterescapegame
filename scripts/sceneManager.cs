using Godot;
using System;
using System.Collections.Generic;

//source: https://www.youtube.com/watch?v=IHvJd8BCRtI
public enum eSceneNames {
    Start = 10,
    Main = 20,
    //Level2 = 30
}

public partial class SceneManager : Node {

    public static SceneManager instance;

    public Dictionary<eSceneNames, SceneData> sceneDictionary = new Dictionary<eSceneNames, SceneData>() {
        {eSceneNames.Main, new SceneData("res://Scenes/start.tscn", "Start", false) },
        {eSceneNames.Main, new SceneData("res://Scenes/main.tscn", "Main", false) },
        // {eSceneNames.Level2, new SceneData("res://Scenes/30_Level2.tscn", "Level Two", true) },
    };

    public override void _Ready() {
        instance = this;
    }

    public void ChangeScene(eSceneNames mySceneName) {
        string myPath = sceneDictionary[mySceneName].path;
        //GameMaster.pauseAllowed = sceneDictionary[mySceneName].pauseAllowed;
        GetTree().ChangeSceneToFile(myPath);
    }

}