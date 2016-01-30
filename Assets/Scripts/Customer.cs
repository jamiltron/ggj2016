using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Customer : MonoBehaviour {

  public string problemStatement;
  public string helpResponse;
  public string declineResponse;

  public Text speechTextBox;

  void Start() {
    if (speechTextBox == null) {
      speechTextBox = GameObject.FindGameObjectWithTag("SpeechBubble").GetComponent<Text>();
    }

    PitchProblem();
  }

  public void PitchProblem() {
    speechTextBox.text = problemStatement;
  }

  public void Help() {
    speechTextBox.text = helpResponse;
  }

  public void Decline() {
    speechTextBox.text = declineResponse;
  }

}
