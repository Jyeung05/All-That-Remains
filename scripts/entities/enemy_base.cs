using Godot;
using System;
using System.ComponentModel;

public partial class enemy_base : EntityBase
{	
	protected player target;
	protected bool inArea;
	protected bool isRight;
	protected bool isLeft;
	protected float DetectionRange;
	protected void findPlayer(player target){
		Vector2 distanceToTarget =  target.Position - this.Position;
			
			if (distanceToTarget.X<0){
				isLeft = true;
				isRight = false;
			}
			if (distanceToTarget.X>0){
				isRight = true;
				isLeft =false;
			}
	}
	protected void moveToTarget(player target)
	{
		findPlayer(target);
		if(this.isLeft){
			this.leftRight = -1;
		}
		if(this.isRight){
			this.leftRight = 1;
		}
		GD.Print(target.Position);
	}
protected void _on_detection_area_entered(Area2D area)
{
	this.inArea = true;
	// Replace with function body.
}
protected void _on_detection_area_exited(Area2D area)
{
	this.inArea = false;
	// Replace with function body.
}
}	


