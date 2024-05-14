using Godot;
using System;

public abstract partial class EntityBase : CharacterBody2D
{

protected int leftRight;
protected int upDown;

	protected bool isJumping;
	protected int jumpsLeft;
	protected	float JumpVelocity;
	protected float Speed;

	protected float fastFallValue = 0.2f;
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
	
		public void die() {
		QueueFree();
	}
	private void _on_hurt_box_area_entered(Area2D hitbox)
{
	Node parentNode = hitbox.GetParent();
	EntityBase parent = (EntityBase) parentNode;
	parent.baseStats.setHp(parent.baseStats.getHp()-1);
	hpBar.Value = parent.baseStats.getHp();
	if (parent.baseStats.getHp() < 0) {
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

	}




	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{


		Vector2 velocity = Velocity;



		// Add the gravity.
		if (!IsOnFloor()){
			velocity.Y += gravity * (float)delta;                   
		}
		// Handle Jump.
		if(IsOnFloor()){
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
				velocity.Y = fastFallValue * direction.Y * Speed + velocity.Y;
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



public override void _Process(double delta)
	{
		// Called every frame. 'delta' is the elapsed time since the previous frame.
		Console.WriteLine("process");

	}

}
	


