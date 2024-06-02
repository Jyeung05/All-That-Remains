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

	protected int numOfJumps;

// put in a positive, code will invert it
	protected int jumpHeight;
	private int maxHp;
	private double regenCounter;
	
	public Stats(int hp, int regen, int ar, int mr, int arpen, int mrpen, int ad, int ap, int size, int movespeed, int res, int jumps, int jumpH) {
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
		this.numOfJumps = jumps;
		this.jumpHeight =  -1 * jumpH;
		
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
		this.jumpHeight = other.jumpHeight;
		this.numOfJumps = other.numOfJumps;


	}

	public Stats() {
		this.hp = 0;
		this.regenPercent = 0;
		this.ar = 0;
		this.mr = 0;
		this.arPen = 0;
		this.mrPen = 0;
		this.ad = 0;
		this.ap = 0;
		this.sizeScaler = 0;
		this.moveSpeedScaler = 0;
		this.res = 0;
		this.maxHp = 0;
		this.numOfJumps = 0;
		this.jumpHeight = 0;
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
	
	   public int GetJumpHeight()
	{
		return this.jumpHeight;
	}

	// Setter for JumpHeight
	public void SetJumpHeight(int value)
	{
		// You can add validation logic here if needed
		jumpHeight = -1 * value;
	}

	// Getter for NumOfJumps
	public int GetNumOfJumps()
	{
		return this.numOfJumps;
	}

	// Setter for NumOfJumps
	public void SetNumOfJumps(int value)
	{
		// You can add validation logic here if needed
		numOfJumps = value;
	}
	
	
	public int dealDmg(int enemyad, int enemyap, int enemyarpen, int enemymrpen) {
		int adComponent = (int)(Math.Sqrt(15*(this.ar - enemyarpen))*(1/100)*enemyad);
		int apComponent = (int)(Math.Sqrt(15*(this.mr - enemymrpen))*(1/100)*enemyap);
		return 1/100*res*(adComponent + apComponent);
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

