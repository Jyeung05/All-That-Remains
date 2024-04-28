using Godot;
using System;

public partial class Stats : Node
{
	protected int hp;
	protected int regenPercent;
	protected int ar;
	protected int mr;
	protected int arPen;
	protected int mrPen;
	protected int ad;
	protected int ap;
	protected int sizeScaler;
	protected int moveSpeedScaler;
	protected int res;
	private int maxHp;
	private double regenCounter;
	
	public Stats(int hp, int regen, int ar, int mr, int arpen, int mrpen, int ad, int ap, int size, int movespeed, int res) {
		this.hp = hp;
		this.regenPercent = regen;
		this.ar = ar;
		this.mr = mr;
		this.arPen = arpen;
		this.mrPen = mrpen;
		this.ad = ad;
		this.ap = ap;
		this.sizeScaler = size;
		this.moveSpeedScaler = movespeed;
		this.res = res;
		this.maxHp = hp;
	}
	
	public Stats(Stats other) {
		this.hp = other.hp;
		this.regenPercent = other.regenPercent;
		this.ar = other.ar;
		this.mr = other.mr;
		this.arPen = other.arPen;
		this.mrPen = other.mrPen;
		this.ad = other.ad;
		this.ap = other.ap;
		this.sizeScaler = other.sizeScaler;
		this.moveSpeedScaler = other.moveSpeedScaler;
		this.res = other.res;
		this.maxHp = other.maxHp;
	}
	
	public void setHp(int hp) {
		this.hp = hp;
	}
	
	public int getHp() {
		return this.hp;
	}
		
	public void setRegenPercent(int regenPercent) {
		this.regenPercent = regenPercent;
	}
	
	public int getRegenPercent() {
		return this.regenPercent;
	}
		
	public void setAr(int ar) {
		this.ar = ar;
	}
	
	public int getAr() {
		return this.ar;
	}
		
	public void setMr(int mr) {
		this.mr = mr;
	}
	
	public int getMr() {
		return this.mr;
	}
		
	public void setArPen(int arpen) {
		this.arPen = arpen;
	}
	
	public int getArPen() {
		return this.arPen;
	}
		
	public void setMrPen(int mrPen) {
		this.mrPen = mrPen;
	}
	
	public int getMrPen() {
		return this.mrPen;
	}
		
	public void setAd(int ad) {
		this.ad = ad;
	}
	
	public int getAd() {
		return this.ad;
	}
		
	public void setAp(int ap) {
		this.ap = ap;
	}
	
	public int getAp() {
		return this.ap;
	}
		
	public void setSizeScaler(int scaler) {
		this.sizeScaler = scaler;
	}
	
	public int getSizeScaler() {
		return this.sizeScaler;
	}
		
	public void setMoveSpeedScaler(int scaler) {
		this.moveSpeedScaler = scaler;
	}
	
	public int getMoveSpeedScaler() {
		return this.moveSpeedScaler;
	}
		
	public void setRes(int res) {
		this.res = res;
	}
	
	public int getRes() {
		return this.res;
	}
		
	public void setMaxHp(int hp) {
		this.maxHp = hp;
	}
	
	public int getMaxHp() {
		return this.maxHp;
	}
	
	
	
	public void dealDmg(int enemyad, int enemyap, int enemyarpen, int enemymrpen) {
		int adComponent = (int)(Math.Sqrt(15*(this.ar - enemyarpen))*(1/100)*enemyad);
		int apComponent = (int)(Math.Sqrt(15*(this.mr - enemymrpen))*(1/100)*enemyap);
		this.hp = this.hp - 1/100*res*(adComponent + apComponent);
	}
	
	public void heal(int amount) {
		this.hp = this.hp + amount;
	}
	
	public void regen() {
		if (this.hp < this.maxHp) {
			this.hp = this.hp + this.maxHp*this.regenPercent;
		}
	}
	
	public override void _Process(double delta)
	{
		regenCounter = regenCounter + delta;
		if (regenCounter >= 100) {
			regen();
			regenCounter = 0;
		}
		GD.Print(regenCounter);
	}
}

