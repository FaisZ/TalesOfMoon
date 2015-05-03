using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

	public PlayerOne playerOne;
	public UFOEnemy UFOenemy;
	public GameObject enemybody; 
	public GameObject playerbody; 
	public GameObject SkillMenu;
	public GameObject question;
	public bool enemyDestroyed;
	public bool playerDestroyed;
	public bool potionDeployed;
	public bool questionAsked;
	private bool isShowing;
	private bool isShowingSkill;

	// Use this for initialization
	void Start () {
		this.enemyDestroyed = false;
		this.potionDeployed = false;
		this.question.SetActive(false);
		this.SkillMenu.SetActive(false);
		this.isShowingSkill = false;
		this.isShowing = false;
	}

	public void addDamage()
	{
		Debug.Log ("1");
		if (this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			Debug.Log ("1");
			this.isShowing = !this.isShowing;
			this.question.SetActive(this.isShowing);
			this.checkAttack();
		}
	}

	public void openSkill()
	{
		Debug.Log ("Skill opened");
		if (this.playerDestroyed == false && this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			Debug.Log ("Skill opened");
			this.isShowingSkill = !this.isShowingSkill;
			this.SkillMenu.SetActive(this.isShowingSkill);
//			this.checkSkill();
		}
	}

	public void checkAttack()
	{
		Debug.Log ("Serang!");
		int Attack;
		if (this.playerDestroyed == false && this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			int attackStart = this.playerOne.attackStart;
			int attackEnd = this.playerOne.attackEnd;
			Attack = Random.Range(attackStart, attackEnd);
			this.UFOenemy.health -= Attack;
			this.UFOenemy.updateSlider();
			this.playerOne.hasAttacked = true;
			this.playerOne.playAttackAnim();
		}
	}
	
//	public void checkSkill_Power_Slash()
	public void checkSkill_Power_Slash(int SkillDamage)
	{
		Debug.Log ("Skill!");
//		SkillDamage *= SkillDamage;
//		if (this.playerDestroyed == false && this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
//		{
			this.UFOenemy.health -= SkillDamage;
			Debug.Log ("Damage: " + SkillDamage);
			this.UFOenemy.updateSlider();
//		}
	}
	
	public void addHealth()
	{
		if (this.playerDestroyed == false && this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			if(this.playerOne.potion > 0)
			{
				if(this.playerOne.health + 50 >= this.playerOne.maxHealth)
					this.playerOne.health = this.playerOne.maxHealth;
				else
					this.playerOne.health += 50;
				this.playerOne.updateSlider();
				this.playerOne.hasAttacked = true;
				this.potionDeployed = true;
				this.playerOne.potion -= 1;

			}
		}
	}

	public void checkAttackEnemy()
	{
		if(this.enemyDestroyed == false && this.playerDestroyed == false)
		{
			int attackStart = this.UFOenemy.attackStart;
			int attackEnd = this.UFOenemy.attackEnd;
			int Attack = Random.Range(attackStart, attackEnd);
			this.playerOne.health -= Attack;
			this.playerOne.burst += (Attack*50)/this.playerOne.maxHealth;
			this.UFOenemy.playAttackAnim();
			this.playerOne.updateSlider();
			if (this.playerOne.burst == 100)
			{
				this.playerOne.burst = 0;
				this.playerOne.updateSlider();
				this.UFOenemy.health -= 200;
				this.playerOne.playAttackAnim();
				this.UFOenemy.updateSlider();
			}
			this.playerOne.hasAttacked = false;
		}

	}

	public void destroyEnemy()
	{
		Destroy(enemybody);
		this.enemyDestroyed = true;
	}
	
	public void destroyPlayer()
	{
		Destroy(playerbody);
		this.playerDestroyed = true;
	}

	public bool playerDead()
	{
		if (this.playerDestroyed == true)
						return false;
				else
						return this.playerOne.slashPlayed();
	}
	
	// Update is called once per frame
	void Update () {
		if (this.playerDestroyed == true || this.enemyDestroyed == true) 
		{
			Application.LoadLevel("GameMenu");
		}

		if((this.playerDead() || this.potionDeployed) && this.playerOne.hasAttacked == true)
		{
			this.checkAttackEnemy();
			this.potionDeployed = false;
		}

		if(this.playerOne.health <= 0)
		{
			this.destroyPlayer();
			Debug.Log("You Lose!");
		}

		else if(this.UFOenemy.health <= 0 && this.enemyDestroyed == false)
		{
			this.destroyEnemy();
			Debug.Log("You Win!");
		}

//		if(this.questionAsked)
//		{
//			this.addDamage();
//		}
	}
}
