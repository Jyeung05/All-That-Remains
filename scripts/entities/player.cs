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

	public override void moveLeftRight()
	{
			Console.Write("here");
			if(Input.IsActionPressed("ui_left")){
				this.leftRight = -1;
			}
			if(Input.IsActionPressed("ui_right")){
				this.leftRight = 1;
			}
	}

	public override void moveUpDown()
	{

	}

	public override void jump()
	{
	  if(Input.IsActionPressed("ui_up") && this.numOfJumps > 0){
				this.isJumping= true;
			 }
	}

	public override void _PhysicsProcess(double delta){
			this.moveLeftRight();
	moveUpDown();
	jump();
		base._PhysicsProcess(delta);
	}

}



