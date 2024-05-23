using Godot;
using System;

public partial class projectile_base : Area2D
{
	[Export] protected int damage;
	[Export] protected float speed = 100f;

    
    public override void _PhysicsProcess(double delta){
		Vector2 direction = new Vector2(1, 0).Rotated(Rotation);
		GlobalPosition += speed * direction * (float) delta;
		
	}

	public void destroy() {
		QueueFree();
	}

	private void _on_area_entered() {
		destroy();
	}

	private void _on_body_entered() {
		destroy();
	}
}



