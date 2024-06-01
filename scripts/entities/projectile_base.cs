using Godot;
using System;
using System.Numerics;

public partial class projectile_base : Area2D
{
	[Export] protected int damage;
	[Export] protected float speed = 100f;

	private Godot.Vector2 direction;

    public Godot.Vector2 Direction {
        get { return direction; }
        set { direction = value.Normalized(); }
    }
    
    public override void _PhysicsProcess(double delta){
		
		GlobalPosition += speed * direction * (float) delta;
		
	}

	public void destroy() {
		QueueFree();
	}

	public void _on_area_entered(Area2D area) {
		destroy();
	}

	public void _on_body_entered(Area2D body) {
		destroy();
	}

	private void _on_visible_on_screen_notifier_2d_screen_exited() {
		destroy();
	}
}



