using Godot;
using System;

public partial class EntityBase : CharacterBody2D
{
	public Stats baseStats = new Stats();
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
	
	public void die() {
		QueueFree();
	}
	private void _on_hurt_box_area_entered(Area2D hitbox)
{
	Node parentNode = hitbox.GetParent();
	EntityBase parent = (EntityBase) parentNode;
	parent.baseStats.setHp(parent.baseStats.getHp()-1);
	GD.Print(parent.Name + parent.baseStats.getHp());
	
}
}
