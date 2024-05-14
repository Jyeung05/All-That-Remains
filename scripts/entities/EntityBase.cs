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
	protected Stats baseStats = new Stats();
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


	
	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{


		Vector2 velocity = Velocity;



		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;                   

		// Handle Jump.
		if (isJumping)
			velocity.Y = JumpVelocity;
 
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = new Vector2(leftRight, upDown);
			Console.Write(direction.X);
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Y = direction.Y * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
/// <summary>
/// edit the entities "lr" variable with this function to define how it moves left to right
/// </summary>
	public abstract void moveLeftRight();
/// <summary>
/// define in this section how the unit moves up and down using the "ud" varaible for up and down
/// </summary>
public abstract void moveUpDown();

public abstract void jump();
}
