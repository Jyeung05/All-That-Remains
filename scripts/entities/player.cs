using Godot;
using System;

public partial class player : EntityBase{

	float originalGravity;
	float acceleratedGravity;

	
private CollisionShape2D hitboxShape;
	private Timer attackTimer;

	public override void _Ready()
	{
		originalGravity = gravity;
	 	acceleratedGravity = gravity * 2;
		hitboxShape = GetNode<CollisionShape2D>("HitBox/CollisionShape2D");

		// Create and configure a timer for the attack duration
		attackTimer = new Timer();
		attackTimer.WaitTime = 0.1f; // Adjust the duration of the hitbox being enabled
		attackTimer.OneShot = true;
		AddChild(attackTimer);
		attackTimer.Timeout += OnAttackTimeout;
		GD.Print(hitboxShape);
		base._Ready();
	}

	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)

			Attack();
	}
	

	private void Attack()
	{
		hitboxShape.Disabled = false;
		attackTimer.Start();
	}

	private void OnAttackTimeout()
	{
		hitboxShape.Disabled = true;
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




