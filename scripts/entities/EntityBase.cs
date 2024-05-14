using Godot;
using System;

public partial class EntityBase : CharacterBody2D
{
	TextureProgressBar hpBar;
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
	hpBar.Value = parent.baseStats.getHp();
	if (parent.baseStats.getHp() < 0) {
		die();
	}
}

public override void _Ready()
	{
		hpBar = GetNode<TextureProgressBar>("EntityHealthBar");
		hpBar.Value = baseStats.getMaxHp();
		hpBar.MaxValue = baseStats.getMaxHp();

		baseStats.setHp(Health);
		baseStats.setRegenPercent(RegenPercent);
		baseStats.setAr(Armour);
		baseStats.setMr(MagicResist);
		baseStats.setArPen(ArmourPen);
		baseStats.setMrPen(MagicPen);
		baseStats.setAd(AttackDmg);
		baseStats.setAp(AbilityPow);
		baseStats.setSizeScaler(Size);
		baseStats.setMoveSpeedScaler(MoveSpeed);
		baseStats.setRes(Resistance);
	}
	

}
