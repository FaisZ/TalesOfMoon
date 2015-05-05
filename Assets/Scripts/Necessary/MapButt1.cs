using UnityEngine;
using System.Collections;

public class MapButt1 : MonoBehaviour {

//	public UFOEnemy UFOEnemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnMouseDown() 
	{
//		this.UFOEnemy.level = 100;
		Application.LoadLevel("Scene1");
	}
}
