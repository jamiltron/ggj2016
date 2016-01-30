using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UITransitions : MonoBehaviour {

	public GameObject welpUI;

	void Awake()
	{
		
	}
	void Start()
	{
		if (welpUI == null) {
			welpUI = GameObject.Find ("WelpCanvas");
			if(welpUI!= null)
				welpUI.GetComponent<Canvas>().enabled =  false;
		}
	}
	public void OnStartGameClicked()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void OnOpenWelpScreenClicked()
	{
		if(welpUI)
			welpUI.GetComponent<WelpCanvas>().ShowResponseText();
	}
		
}
