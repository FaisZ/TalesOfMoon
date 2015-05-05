using UnityEngine;
using System.Collections;

public class MainScene : MonoBehaviour {

	public PlayerOne playerOne;
	public UFOEnemy UFOenemy;
	public GameObject enemybody; 
	public GameObject playerbody; 
	public GameObject BurstButton;
	public GameObject SkillMenu;
	public GameObject ItemMenu;
	public GameObject question;
	public bool enemyDestroyed;
	public bool playerDestroyed;
	public bool potionDeployed;
	public bool questionAsked;
	private bool isShowing;
	private bool isShowingSkill;
	private bool isShowingItem;
//	private bool isShowingBurst;

	// Use this for initialization
	void Start () {
		this.enemyDestroyed = false;
		this.potionDeployed = false;
		this.question.SetActive(false);
		this.BurstButton.SetActive(false);
		this.SkillMenu.SetActive(false);
		this.ItemMenu.SetActive(false);
		this.isShowingSkill = false;
//		this.isShowingBurst = false;
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
			if (this.isShowingItem == true)
			{
				this.isShowingItem = false;
				this.ItemMenu.SetActive(this.isShowingItem);
			}
			this.isShowingSkill = !this.isShowingSkill;
			this.SkillMenu.SetActive(this.isShowingSkill);
				//			this.checkSkill();
		}
	}
	
	public void openItem()
	{
		Debug.Log ("Item opened");
		if (this.playerDestroyed == false && this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			Debug.Log ("Item opened");
			if (this.isShowingSkill == true)
			{
				this.isShowingSkill = false;
				this.SkillMenu.SetActive(this.isShowingSkill);
			}
			this.isShowingItem = !this.isShowingItem;
			this.ItemMenu.SetActive(this.isShowingItem);
			//			this.checkSkill();
		}
	}
	
	public void checkAttack()
	{
		Debug.Log ("Serang!");
		int Attack;
		if (this.isShowingItem == true)
		{
			this.isShowingItem = false;
			this.ItemMenu.SetActive(this.isShowingItem);
		}
		else if (this.isShowingSkill == true)
		{
			this.isShowingSkill = false;
			this.SkillMenu.SetActive(this.isShowingSkill);
		}

		if (this.playerDestroyed == false && this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			int attackStart = this.playerOne.attackStart;
			int attackEnd = this.playerOne.attackEnd;
			Attack = (Random.Range(attackStart, attackEnd)+10) - (this.UFOenemy.Def);
			if (Attack <= 0)
				Attack = 1;
			this.UFOenemy.health -= Attack;
			this.playerOne.hasAttacked = true;
			this.playerOne.playAttackAnim();
			this.UFOenemy.updateSlider();
		}
	}
	
//	public void checkSkill_Power_Slash()
	public void checkSkill(int SkillDamage)
	{
		Debug.Log ("Skill!");
//		SkillDamage *= SkillDamage;
//		if (this.playerDestroyed == false && this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
//		{
			this.UFOenemy.health -= SkillDamage;
//			Debug.Log ("Damage: " + SkillDamage);
			this.isShowingSkill = !this.isShowingSkill;
			this.SkillMenu.SetActive(this.isShowingSkill);
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
				this.isShowingItem = !this.isShowingItem;
				this.ItemMenu.SetActive(this.isShowingItem);

			}
		}
	}

	public void checkAttackEnemy()
	{
		if(this.enemyDestroyed == false && this.playerDestroyed == false)
		{
			int attackStart = this.UFOenemy.attackStart;
			int attackEnd = this.UFOenemy.attackEnd;
			int Attack = (Random.Range(attackStart, attackEnd)+10) - (this.playerOne.Def);
			if (Attack <= 0)
				Attack = 1;
			this.playerOne.health -= Attack;
			if (Attack >= this.playerOne.maxHealth) //kondisi jika damage > max health
				this.playerOne.burst += 50;
			else
				this.playerOne.burst += (Attack*50)/this.playerOne.maxHealth;
//			this.playerOne.burst += 100;
			this.UFOenemy.playAttackAnim();
			this.playerOne.updateSlider();
			if (this.playerOne.burst == 100)
			{
//				this.isShowingBurst = true;
//				this.BurstButton.SetActive(this.isShowingBurst);
				this.BurstButton.SetActive(true);
			}
			this.playerOne.hasAttacked = false;
		}

	}

	public void BurstMode()
	{
		Debug.Log ("Burst Show");
		if (this.isShowingItem == true)
		{
			this.isShowingItem = false;
			this.ItemMenu.SetActive(this.isShowingItem);
		}
		else if (this.isShowingSkill == true)
		{
			this.isShowingSkill = false;
			this.SkillMenu.SetActive(this.isShowingSkill);
		}
		
		if (this.playerDestroyed == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			this.BurstButton.SetActive(false);
			this.playerOne.burst = 0;
			this.playerOne.updateSlider();
			this.UFOenemy.health -= 100;
			this.playerOne.playAttackAnim();
			this.UFOenemy.updateSlider();
			//			Debug.Log ("Burst Show");
//			if (this.isShowingBurst == true)
//			{
//				this.isShowingBurst = false;
//				this.BurstButton.SetActive(this.isShowingBurst);
//			}
//			this.isShowingItem = !this.isShowingItem;
//			this.ItemMenu.SetActive(this.isShowingItem);
			//			this.checkSkill();
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
//		if (this.playerDestroyed == true || this.enemyDestroyed == true) 
//		{
//			AutoFade.LoadLevel("GameMenu", 3,1,Color.black);
//			Application.LoadLevel("GameOver");
//		}

		if((this.playerDead() || this.potionDeployed) && this.playerOne.hasAttacked == true)
		{
			this.checkAttackEnemy();
			this.potionDeployed = false;
		}

		if(this.playerOne.health <= 0 && this.playerDestroyed == false)
		{
			this.destroyPlayer();
			Debug.Log("You Lose!");
			Application.LoadLevel("GameOver");
		}

		else if(this.UFOenemy.health <= 0 && this.enemyDestroyed == false)
		{
			this.destroyEnemy();
			Debug.Log("You Win!");
			Application.LoadLevel("GameMap");
		}

//		if(this.questionAsked)
//		{
//			this.addDamage();
//		}
	}
}
