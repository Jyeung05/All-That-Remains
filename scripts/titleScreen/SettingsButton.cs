using Godot;
using System;

public partial class SettingsButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	private void SettingsButtonPressed()
	{
		ResourceLoader.Load<PackedScene>("res://scenes/titleScreen/settingsScreen.tscn").Instantiate();
		//changes scene and deletes title screen
		GetTree().ChangeSceneToFile("res://scenes/titleScreen/settingsScreen.tscn");
		GetNode("scenes/titleScreen/titleScreen.tscn").Free();

	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
