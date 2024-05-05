using Godot;
using System;
using System.ComponentModel;

public partial class enemy_base : EntityBase
{
	private void _on_hurt_box_area_entered(Area2D area)
{
	GD.Print("blah");
}
}
