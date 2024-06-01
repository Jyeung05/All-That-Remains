using Godot;
using System;

public abstract partial class EntityBase : CharacterBody2D
{
	protected int leftRight;
	protected int upDown;
	protected bool isJumping;
	protected float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	protected bool apexOfJump;

	protected int jumpsLeft;
	protected	float JumpVelocity;
	protected float Speed;

// TODO: move fastvalue, jump height and num of jumps ot export. idk how to and its late, and i want to go to bed, and i feel like playing games but its late and i shid.
	protected float fastFallValue =  500f;
	TextureProgressBar hpBar;
	public Stats baseStats = new Stats();
	[ExportGroup("Stats")]
	[Export] protected int Health;
	[Export] protected int RegenPercent;
	[Export] protected int Armour;
	[Export] protected int MagicResist;
	[Export] protected int ArmourPen;
	[Export] protected int MagicPen;
	[Export] protected int AttackDmg;
	[Export] protected int AbilityPow;
	[Export] protected int Size;
	[Export] protected int MoveSpeed;
	[Export] protected int Resistance;
	[Export] protected int jumpHeight;
	[Export] protected int numOfJumps;
	[Export] protected bool knockbackable = false;
	[Export] protected float kbModifier = 0.1f;
	
		public void die() {
		QueueFree();
	}
	private void _on_hurt_box_area_entered(Area2D hitbox)
{
	Node parentNode = hitbox.GetParent();
	EntityBase parent = (EntityBase) parentNode;
	baseStats.setHp(baseStats.getHp() - parent.baseStats.getAd());
	hpBar.Value = baseStats.getHp();
	if (baseStats.getHp() <= 0) {
		die();
	}
}

public override void _Ready()
	{
		Console.WriteLine("ready");
		hpBar = GetNode<TextureProgressBar>("EntityHealthBar");
		hpBar.Value = baseStats.getMaxHp();
		hpBar.MaxValue = baseStats.getMaxHp();
		baseStats.setHp(Health);
		baseStats.setMaxHp(Health);
		baseStats.setRegenPercent(RegenPercent);
		baseStats.setAr(Armour);
		baseStats.setMr(MagicResist);
		baseStats.setArPen(ArmourPen);
		baseStats.setMrPen(MagicPen);
		baseStats.setAd(AttackDmg);
		baseStats.setAp(AbilityPow);
		baseStats.setSizeScaler(Size);
		baseStats.setMoveSpeedScaler(MoveSpeed);
		baseStats.setRes(Resistance);
		baseStats.SetJumpHeight(jumpHeight);
		baseStats.SetNumOfJumps(numOfJumps);
		hpBar = GetNode<TextureProgressBar>("EntityHealthBar");
		hpBar.MaxValue = baseStats.getMaxHp();
		hpBar.Value = baseStats.getMaxHp();
		this.JumpVelocity = -500;
		baseStats.SetNumOfJumps(numOfJumps);
		this.Speed = baseStats.getMoveSpeedScaler();
		
  
	}
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public override void _PhysicsProcess(double delta)
	{

		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor()){
			velocity.Y += gravity * (float)delta;   
			  
		}
			if(velocity.Y >= 0){
				this.apexOfJump = true;
			} else {
				this.apexOfJump = false;
			}
			 
		// Handle Jump.
		if(IsOnFloor()){
			this.apexOfJump = false;

			this.jumpsLeft = this.numOfJumps; ;
		}
		if (isJumping && jumpsLeft > 0){

			velocity.Y = JumpVelocity;
		}	
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = new Vector2(leftRight, upDown);

		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			if(upDown != 0){
				velocity.Y = fastFallValue + velocity.Y;
			}
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		this.leftRight = 0;
		this.upDown = 0;
		this.isJumping = false;
		MoveAndSlide();
	}
/// <summary>
/// edit the entities "lr" variable with this function to define how it moves left to right
/// </summary>
}
