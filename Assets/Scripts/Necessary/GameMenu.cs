using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {
	public GUISkin GUISkins;
	[System.Serializable]
	public class CToggleButton{
	
		public bool isSpeakerOff;
		public int left;
		public int top;
		public int width;
		public int height;
	
	}

	[System.Serializable]
	public class CMenuButton{
		public string caption;
		public int left;
		public int top;
		public int width;
		public int height;
		public string LoadLevel;
	}

	public GUITexture myguitexture;
	public CToggleButton togglebutt;
	public CMenuButton[] menubutt;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<AudioSource>().mute = togglebutt.isSpeakerOff;
	}

	void OnGUI(){
		GUI.skin = GUISkins;
		myguitexture.pixelInset = new Rect (0, 0, Screen.width, Screen.height);
		togglebutt.isSpeakerOff = GUI.Toggle (new Rect (togglebutt.left, togglebutt.top, togglebutt.width, togglebutt.height), togglebutt.isSpeakerOff, "");
		for (int i=0; i<menubutt.Length; i++)
		{
			if(GUI.Button(new Rect(Screen.width/2 + menubutt[i].left, Screen.height/2 + menubutt[i].top, menubutt[i].width, menubutt[i].height),menubutt[i].caption))
			{
				if (menubutt[i].LoadLevel == "quit")
				{
					Application.Quit();
				}
				else
				{
//					AutoFade.LoadLevel(menubutt[i].LoadLevel, 1,1,Color.black);
					Application.LoadLevel(menubutt[i].LoadLevel);
				}
			}
		}
	}
}
