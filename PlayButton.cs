using Godot;
using System;

public partial class PlayButton : Godot.Button
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ResourceLoader.Load<PackedScene>("res://scenes/world.tscn").Instantiate();
	}

	private void ButtonPressed()
	{
		GD.Print("Hello world!");
		GetTree().ChangeSceneToFile("res://scenes/world.tscn");
		GetNode("scenes/titleScreen.tscn").Free();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}


