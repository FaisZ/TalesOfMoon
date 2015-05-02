using UnityEngine;
using System.Collections;

public class ButtonClick : MonoBehaviour {
	public MainScene mainScene;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown() {
		this.mainScene.checkAttack();
//		this.mainScene.addDamage();
	}
}
