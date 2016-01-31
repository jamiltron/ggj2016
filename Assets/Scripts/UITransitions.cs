using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UITransitions : MonoBehaviour {

  public GameObject welpUI;

  void Awake() {
		
  }

  void Start() {
    if (welpUI == null) {
      welpUI = GameObject.Find("WelpCanvas");
      if (welpUI != null)
        welpUI.GetComponent<Canvas>().enabled = false;
    }
  }

  public void OnStartGameClicked() {
    SoundManager.instance.PlayButtonClickSfx();
    SoundManager.instance.PlayGameBkgMusic();
    SceneManager.LoadScene("GameScene");
    //SceneManager.LoadScene("JustinScene");
  }

  public void OnOpenWelpScreenClicked() {
    if (welpUI) {
      if (SoundManager.instance)
        SoundManager.instance.PlayButtonClickSfx();
      welpUI.GetComponent<WelpCanvas>().ShowResponseText();
      welpUI.SetActive(true);
    }
  }

	public void RotateCamera(float y)
	{
		Camera.main.transform.Rotate (new Vector3 (0, y, 0));
	}
		
}
