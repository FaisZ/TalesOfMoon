﻿using UnityEngine;
using System.Collections;

public class Skill_Power_Slash : MonoBehaviour {
	public MainScene mainScene;
	public PlayerOne PlayerOne;
	int SkillDamage;
	// Use this for initialization
	void Start () {
//		SkillDamage = this.PlayerOne.Skill_Power_Slash ();
	}
	
	// Update is called once per frame
	void OnMouseDown() {
		if (this.PlayerOne.special >= 25) 
		{
			SkillDamage = this.PlayerOne.Skill_Power_Slash ();
			this.mainScene.checkSkill (SkillDamage);
		}
//		this.PlayerOne.Skill_Power_Slash (SkillDamage);
	}
}
