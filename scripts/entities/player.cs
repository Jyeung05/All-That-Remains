using Godot;
using System;

public partial class player : EntityBase{

	float originalGravity;
	float acceleratedGravity;

public override void _Ready(){
	 base._Ready();
	 originalGravity = gravity;
	 acceleratedGravity = gravity * 2;

}



	public override void _PhysicsProcess(double delta){

	
		//movment checks followed by editing the entity base values to give commands
		if(
			Input.IsActionJustPressed("ui_up")){
			
			this.isJumping = true;
			this.jumpsLeft--;
		}
		if(Input.IsActionPressed("ui_left") ){
		
			this.leftRight = -1;
			
		}
		if(Input.IsActionPressed("ui_right") ){
			this.leftRight = 1;
		}

		if(Input.IsActionJustPressed("ui_down") ){
			this.upDown = 1;
		}

		if(this.apexOfJump ){
			this.gravity = this.acceleratedGravity;
		}
		else{
			this.gravity = this.originalGravity;

		}


		base._PhysicsProcess(delta);
	}





}




