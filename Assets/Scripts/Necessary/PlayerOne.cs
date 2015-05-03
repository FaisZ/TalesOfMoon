﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerOne : MonoBehaviour {

//	public UFOEnemy UFOenemy;
	public int health;
	public int special;
	public int burst;
	public Slider healthBarSlider;
	public Slider specialBarSlider;
	public Slider burstBarSlider;
	public int level;
	public int maxHealth;
	public int maxSpecial;
	public int Atk, Def, MAtk, MDef, Spd;
	public int maxBurst;
	public int attackStart;
	public int attackEnd;
	public int MattackStart;
	public int MattackEnd;
	public bool hasAttacked;
	public int potion;
	public int SkillDamage;
	Animator animator;

	// Use this for initialization
	void Start () {
		this.level = 1;
		this.maxHealth = 92+(level*8);
		this.maxSpecial = 95+(level*5);
	    this.Atk = 10+(level*4);
	    this.Def = 9+(level*3);
		this.MAtk = 6+(level*2);
		this.MDef = 9+(level);
		this.Spd = 8+(level*2);
		this.health = maxHealth;
		this.special = maxSpecial;
		this.burst = 0;
		this.maxBurst = 100;
		this.attackStart = Atk-5;
		this.attackEnd = Atk+5;
		this.MattackStart = MAtk-5;
		this.MattackEnd = MAtk+5;
		this.potion = 10;
		this.hasAttacked = false;
		animator = this.GetComponent<Animator>();
		this.healthBarSlider.value = 1.0f;
		this.specialBarSlider.value = 1.0f;
		this.burstBarSlider.value = 0.0f;
	}

	public int Skill_Power_Slash()
	{
//		int attackStart = this.attackStart;
//		int attackEnd = this.attackEnd;
//		int SkillDamage;
		SkillDamage = (Random.Range(this.attackStart, this.attackEnd))*5;
		this.special -= 20;
		this.updateSlider();
		this.hasAttacked = true;
		this.playAttackAnim();
		return(SkillDamage);
	}
	
	public int Skill_Absorb()
	{
//		int attackStart = this.MattackStart;
//		int attackEnd = this.MattackEnd;
		SkillDamage = (Random.Range(this.MattackStart, MattackEnd))*5;
		this.special -= 30;
		this.updateSlider();
		this.health += SkillDamage;
		if(this.health > this.maxHealth)
			this.health = this.maxHealth;
		this.hasAttacked = true;
		this.playAttackAnim();
		return(SkillDamage);
	}
	
	public void playAttackAnim()
	{
		animator.SetBool("Attack", true); 
	}

	public bool slashPlayed()
	{
		if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("slash"))
			return true;
		else
			return false;
	}

	public void updateSlider()
	{
		if(this.health < 0)
			this.health = 0;
		this.healthBarSlider.value = ((this.health * 1.0f) / (this.maxHealth * 1.0f));
		if(this.special < 0)
			this.special = 0;
		this.specialBarSlider.value = ((this.special * 1.0f) / (this.maxSpecial * 1.0f));
		if(this.burst > 100)
			this.burst = 100;
		this.burstBarSlider.value = ((this.burst * 1.0f) / (this.maxBurst * 1.0f));
	}

	// Update is called once per frame
	void Update () {
		if (slashPlayed())
		{
			animator.SetBool("Attack", false);
		}
		//Debug.Log ("Player: " + this.health);
	}
}
