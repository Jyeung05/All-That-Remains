using Godot;
using System;

public partial class character_body_2d : MovingEntities
{
	
	public override void _Ready()
	{
			this.Speed = 300f;
			this.JumpVelocity = 400f;
	}
	
	
		// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.yaxis = 0;
		this.xaxis = 0;
		if (Input.IsActionPressed("ui_right")){
			this.xaxis = 1;
		}
		if (Input.IsActionPressed("ui_left")){
			this.xaxis = -1;
		}
		if (Input.IsActionPressed("ui_up")){
			this.yaxis = 1;
		}
		if (Input.IsActionPressed("ui_down")){
			this.yaxis = -1;
		}
	}

	void damaged(int dmg){

	}
}
