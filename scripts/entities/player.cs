using Godot;
using System;

public partial class player : EntityBase
{



	// Get the gravity from the project settings to be synced with RigidBody nodes.


	private void _on_hurt_box_area_entered(Area2D hitbox)
{
	GD.Print("gyat");
}
public override void _Ready()
	{
		base._Ready();
		baseStats.setHp(base.Health);
		baseStats.setRegenPercent(base.RegenPercent);
		baseStats.setAr(base.Armour);
		baseStats.setMr(base.MagicResist);
		baseStats.setArPen(base.ArmourPen);
		baseStats.setMrPen(base.MagicPen);
		baseStats.setAd(base.AttackDmg);
		baseStats.setAp(base.AbilityPow);
		baseStats.setSizeScaler(base.Size);
		baseStats.setMoveSpeedScaler(base.MoveSpeed);
		baseStats.setRes(base.Resistance);
		baseStats.SetJumpHeight(base.jumpHeight);
		baseStats.SetNumOfJumps(base.Resistance);

		this.JumpVelocity = baseStats.GetJumpHeight();
		this.numOfJumps = baseStats.GetNumOfJumps();
	}




	public override void _PhysicsProcess(double delta){
		//movment checks followed by editing the entity base values to give commands
		Console.WriteLine("physics process");
		if(
			Input.IsActionJustPressed("ui_up") && this.numOfJumps > 0){
			Console.WriteLine("jumping");
			this.isJumping = true;
			this.jumpsLeft--;
		}
		if(Input.IsActionJustReleased("ui_left") ){
			this.leftRight = -1;
			Console.WriteLine("left");	
		}
		if(Input.IsActionJustReleased("ui_right") ){
			this.leftRight = 1;
			Console.WriteLine("right");	
		}

		
		base._PhysicsProcess(delta);
	}


public override void _Process(double delta)
	{
		// Called every frame. 'delta' is the elapsed time since the previous frame.
		Console.WriteLine("process");

	}


}




