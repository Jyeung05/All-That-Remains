using Godot;
using System;

public partial class player : EntityBase
{

	public override void _PhysicsProcess(double delta){
	
		//movment checks followed by editing the entity base values to give commands
		if(
			Input.IsActionPressed("ui_up")){
			
			this.isJumping = true;
			this.jumpsLeft--;
		}
		if(Input.IsActionPressed("ui_left") ){
		
			this.leftRight = -1;
			
		}
		if(Input.IsActionPressed("ui_right") ){
			this.leftRight = 1;
		}

		if(Input.IsActionPressed("ui_down") ){
			this.upDown = 1;
		}
		
		base._PhysicsProcess(delta);
	}





}




