using Godot;
using System;


public partial class trial_enemy : enemy_base
{   

	Area2D detectionArea;
	public override void _Ready()
	{
		
		target = GetNode<player>("../Player");
		
		base._Ready();
	}
	public override void _PhysicsProcess(double delta)
	{   
		
		if(inArea){
			GD.Print("entered");
			moveToTarget(target);
		}
		base._PhysicsProcess(delta);
	}

}

