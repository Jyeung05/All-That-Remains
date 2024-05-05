using Godot;
using System;

public partial class dirt_enemy : enemy_base
{
	public override void _Ready() {
		GD.Print("dirt enemy: " + baseStats.getHp());
	}
	
}
