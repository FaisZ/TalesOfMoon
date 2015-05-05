using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UFOEnemy : MonoBehaviour {

	public int level;
	public int health;
	public int maxHealth;
	public Slider enemyHealthBar;
	public int Atk, Def, MAtk, MDef, Spd;
	public int attackStart;
	public int attackEnd;
	public int MattackStart;
	public int MattackEnd;
	public bool hasAttacked;
	Animator animator;

	// Use this for initialization
	void Start () {
		this.maxHealth = 100 +((level-1)*Random.Range(40,50));
		this.Atk = 10+((level-1)*Random.Range(3,5));
		this.Def = 9+((level-1)*Random.Range(3,5));
		this.MAtk = 6+((level-1)*Random.Range(2,4));
		this.MDef = 9+((level-1)*Random.Range(2,4));
		this.Spd = 8+((level-1)*Random.Range(4,6));
		this.health = maxHealth;
		this.attackStart = Atk-2;
		this.attackEnd = Atk+2;
		this.MattackStart = MAtk-2;
		this.MattackEnd = MAtk+2;
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
