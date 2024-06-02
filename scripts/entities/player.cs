using Godot;
using System;
using System.Numerics;
using System.Runtime.CompilerServices;
public partial class player : EntityBase{

	float originalGravity;
	float acceleratedGravity;
	[Export] public PackedScene DaggerScene { get; set; }
	
	private CollisionShape2D hitboxShape;
	private Timer attackTimer;

	public override void _Ready()
	{
		originalGravity = gravity;
	 	acceleratedGravity = gravity * 2;
		hitboxShape = GetNode<CollisionShape2D>("HitBox/CollisionShape2D");
		DaggerScene = (PackedScene)ResourceLoader.Load("res://scenes/entities/projectiles/test_projectile.tscn");

		// Create and configure a timer for the attack duration
		attackTimer = new Timer();
		attackTimer.WaitTime = 0.1f; // Adjust the duration of the hitbox being enabled
		attackTimer.OneShot = true;
		AddChild(attackTimer);
		attackTimer.Timeout += OnAttackTimeout;
		GD.Print(hitboxShape);
		base._Ready();
	}

	/*public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton mouseEvent && mouseEvent.Pressed && mouseEvent.ButtonIndex == MouseButton.Left)

			Attack();
	}*/
	

	private void Attack()
	{
		hitboxShape.Disabled = false;
		attackTimer.Start();
	}

	private void OnAttackTimeout()
	{
		hitboxShape.Disabled = true;
	}

	private void ranged(Godot.Vector2 dir) {
		projectile_base daggerInstance = DaggerScene.Instantiate<projectile_base>();
		AddChild(daggerInstance);   
		daggerInstance.GlobalPosition = this.GlobalPosition;
		daggerInstance.Direction = dir;
		float angle = daggerInstance.Direction.Angle();
		daggerInstance.Rotation = angle;
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

		if (Input.IsActionJustPressed("attack")) {
			Godot.Vector2 daggerDirection = GlobalPosition.DirectionTo(GetGlobalMousePosition());
			ranged(daggerDirection);
			GD.Print(daggerDirection);
			
		}


		base._PhysicsProcess(delta);
	}

}




