using Godot;
using System;

public partial class Global : Node
{  
	private static Global _instance;
  	public static Global Instance => _instance;
	Node current_scene = null;
	
	public override void _Ready()
	{
		var root = GetTree().Root;
		current_scene = root.GetChild(root.GetChildCount() - 1);
	}  
	
	public override void _EnterTree(){
		if(_instance != null){
		   this.QueueFree(); // The Singletone is already loaded, kill this instance
		}
		_instance = this;
	  }
	
	public void goto_scene(string path){
		CallDeferred("DeferredGotoScene", path);
	}
	
	public void DeferredGotoScene(string path){
		// It is now safe to remove the current scene
		current_scene.Free();

		// Load the new scene.
		var s = ResourceLoader.Load<PackedScene>(path);

		// Instance the new scene.
		current_scene = s.Instantiate();

		// Add it to the active scene, as child of root.
		GetTree().Root.AddChild(current_scene);

		// Optionally, to make it compatible with the SceneTree.ChangeSceneToFile() API.
		GetTree().CurrentScene = current_scene;
	}
}



