using UnityEngine;
using System.Collections;

public class MainScene2 : MonoBehaviour {

	public PlayerOne playerOne;
	public UFOEnemy UFOenemy;
	public GameObject other, question;
	public bool enemyDestroyed;
	public bool potionDeployed;
	public bool questionAsked;
	
	// Use this for initialization
	void Start () {
		this.enemyDestroyed = false;
		this.potionDeployed = false;
		this.question.GetComponent<Renderer>().enabled = false;
	}
	
	public void addDamage()
	{
		Debug.Log ("1");
		if (this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			Debug.Log ("1");
			this.question.GetComponent<Renderer>().enabled = !this.question.GetComponent<Renderer>().enabled;
			this.checkAttack();
		}
	}
	
	public void checkAttack()
	{
		Debug.Log ("Serang!");
		int Attack;
		if (this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
		{
			int attackStart = this.playerOne.attackStart;
			int attackEnd = this.playerOne.attackEnd;
			Attack = Random.Range(attackStart, attackEnd);
			this.UFOenemy.health -= Attack;
			this.playerOne.hasAttacked = true;
			this.playerOne.playAttackAnim();
		}
	}
	
	public void addHealth()
	{
		if (this.playerOne.hasAttacked == false && this.UFOenemy.attackPlayed() == false && this.enemyDestroyed == false) 
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
			}
		}
	}
	
	public void checkAttackEnemy()
	{
		if(this.enemyDestroyed == false)
		{
			int attackStart = this.UFOenemy.attackStart;
			int attackEnd = this.UFOenemy.attackEnd;
			int Attack = Random.Range(attackStart, attackEnd);
			this.playerOne.health -= Attack;
			this.UFOenemy.playAttackAnim();
			this.playerOne.updateSlider();
			this.UFOenemy.updateSlider();
			this.playerOne.hasAttacked = false;
		}
	}
	
	public void destroyEnemy()
	{
		Destroy(other);
		this.enemyDestroyed = true;
	}
	
	// Update is called once per frame
	void Update () {
		if((this.playerOne.slashPlayed() || this.potionDeployed) && this.playerOne.hasAttacked == true)
		{
			this.checkAttackEnemy();
			this.potionDeployed = false;
		}
		
		if(this.playerOne.health <= 0)
		{
			Debug.Log("You Lose!");
		}
		
		else if(this.UFOenemy.health <= 0 && this.enemyDestroyed == false)
		{
			this.destroyEnemy();
			Debug.Log("You Win!");
		}
	}
}
