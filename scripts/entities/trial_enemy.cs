using Godot;
using System;


public partial class trial_enemy : enemy_base
{   
	private const float SPEED = 100f;
	/*private void moveToTarget(double delta)
	{
		if(this.isLeft){
			this.leftRight = -1;
		}
		if(this.isRight){
			this.leftRight = 1;
		}
		base._PhysicsProcess(delta);
	}*/
	
	Area2D detectionArea;
	public override void _Ready()
	{
		
		target = GetNode<player>("../Player");
		detectionArea = GetNode<Area2D>("./Detection Area");
		base._Ready();
	}
	public override void _PhysicsProcess(double delta)
	{   
		this.Speed = SPEED;
		if(inArea){
				moveToTarget(target);
		}
		base._PhysicsProcess(delta);
	}

}

