using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UITransitions : MonoBehaviour {

	void Awake()
	{
		
	}
	public void OnStartGameClicked()
	{
		SceneManager.LoadScene("GameScene");
	}

	public void OnOpenWelpScreenClicked()
	{
		
	}
		
}
