using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UFOEnemy : MonoBehaviour {

	public int health;
	public int maxHealth;
	public Slider enemyHealthBar;
	public int attackStart;
	public int attackEnd;
	public bool hasAttacked;
	Animator animator;

	// Use this for initialization
	void Start () {
		this.health = 500;
		this.maxHealth = 500;
		this.attackStart = 10;
		this.attackEnd = 20;
		animator = this.GetComponent<Animator>();
		this.enemyHealthBar.value = 1.0f;
	}

	public void playAttackAnim()
	{
		animator.SetBool("Attack", true);
	}
	
	public bool attackPlayed()
	{
		if(this.animator.GetCurrentAnimatorStateInfo(0).IsName("attackenemy"))
			return true;
		else
			return false;
	}

	public void updateSlider()
	{
		if(this.health < 0)
			this.health = 0;
		this.enemyHealthBar.value = ((this.health * 1.0f) / (this.maxHealth * 1.0f));

	}

	// Update is called once per frame
	void Update () {
		if(attackPlayed())
		{
			animator.SetBool("Attack", false);
		}
		//Debug.Log ("Enemy: " + this.health);
	}
}
