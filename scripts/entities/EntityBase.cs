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
	baseStats.setHp(baseStats.getHp() - parent.baseStats.getAd());
	hpBar.Value = baseStats.getHp();
	if (baseStats.getHp() <= 0) {
		die();
	}
}

public override void _Ready()
	{
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
		baseStats.setMaxHp(Health);
		hpBar = GetNode<TextureProgressBar>("EntityHealthBar");
		hpBar.MaxValue = baseStats.getMaxHp();
		hpBar.Value = baseStats.getMaxHp();
		GD.Print(hpBar.Value);
	}

}
