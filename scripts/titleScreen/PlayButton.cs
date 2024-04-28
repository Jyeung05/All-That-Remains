using Godot;
using System;

public partial class PlayButton : Godot.Button
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	//called when function is pressed
	private void PlayButtonPressed()
	{
		ResourceLoader.Load<PackedScene>("res://scenes/worlds/world.tscn").Instantiate();
		//changes scene and deletes title screen
		GetTree().ChangeSceneToFile("res://scenes/worlds/world.tscn");
		GetNode("scenes/titleScreen/titleScreen.tscn").Free();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}


