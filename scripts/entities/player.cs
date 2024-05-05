using Godot;
using System;

public partial class player : EntityBase
{

	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y += gravity * (float)delta;

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
			velocity.Y = JumpVelocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
	private void _on_hurt_box_area_entered(Area2D hitbox)
{
	if (baseStats.getHp() == 1) {
		die();
	} else {
		baseStats.setHp(baseStats.getHp() - 1);
	}
	GD.Print(baseStats.getHp());
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
	}
	

}



