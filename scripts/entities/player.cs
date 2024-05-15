using Godot;
using System;

public partial class player : EntityBase
{
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
		baseStats.SetNumOfJumps(base.numOfJumps);

		this.JumpVelocity = -1000;
		this.numOfJumps = 2;
		this.Speed = baseStats.getMoveSpeedScaler();

		base._Ready();
	}




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




