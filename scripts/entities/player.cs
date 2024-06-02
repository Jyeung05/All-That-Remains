using Godot;
using System;

public partial class player : EntityBase{

	float originalGravity;
	float acceleratedGravity;

	bool dashing = false;
	double dashTimer = 0;
	
	float originalSpeed = 500f;
	float acceleratedSpeed = 1000f;

private CollisionShape2D hitboxShape;
	private Timer attackTimer;

	public override void _Ready()
	{
		originalGravity = gravity+500f;
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
			Input.IsActionJustPressed("jump")){
			
			this.isJumping = true;
			this.jumpsLeft--;
		}
		if(Input.IsActionPressed("left") ){
		
			this.leftRight = -1;
			
		}
		if(Input.IsActionPressed("right") ){
			this.leftRight = 1;
		}

		if(Input.IsActionJustPressed("down") ){
			this.upDown = 1;
		}

		if(Input.IsActionJustPressed("up") ){
			this.upDown = -1;
		}
		if(Input.IsActionJustPressed("dash") ){
			if(this.jumpsLeft > 0 && !this.dashing){
				this.dashing = true;
				this.jumpsLeft--;
				
		}

		
		}


		if(this.apexOfJump ){
			this.gravity = this.acceleratedGravity;
		}
		else{
			this.gravity = this.originalGravity;

		}

		if(this.dashing){
			
			this.dashTimer += delta;
			this.Speed =  acceleratedSpeed;
			this.gravity = 0;
			if(this.dashTimer > 0.2){
				this.dashing = false;
				this.dashTimer = 0;
				this.Speed = originalSpeed;
				this.gravity = this.originalGravity;
			}

		}
	
		base._PhysicsProcess(delta);
	}

}




