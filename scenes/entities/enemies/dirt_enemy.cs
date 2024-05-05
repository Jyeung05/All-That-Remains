using Godot;
using System;

public partial class dirt_enemy : enemy_base
{
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
