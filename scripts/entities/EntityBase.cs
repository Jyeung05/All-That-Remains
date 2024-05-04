using Godot;
using System;

public partial class EntityBase : CharacterBody2D
{
	protected Stats baseStats = new Stats();
	
	
	
	public override void _Ready()
	{
		GD.Print(baseStats.getHp());
	}
}
