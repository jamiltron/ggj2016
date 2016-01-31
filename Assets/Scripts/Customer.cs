using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Customer : MonoBehaviour {
  public ProblemType problemType;
  public Problem problem;
  public Text speechTextBox;
  public Sprite customerImg;

  void Awake() {
    if (speechTextBox == null) {
      speechTextBox = GameObject.FindGameObjectWithTag("SpeechBubble").GetComponent<Text>();
    }
	GetComponent<SpriteRenderer> ().sprite = customerImg;
  }

  public void PitchProblem() {
    speechTextBox.text = problem.problemText;
  }

  public void Help() {
    speechTextBox.text = problem.helpAcceptedText;
    problem.accepted = true;
  }

  public void Decline() {
    speechTextBox.text = problem.helpDeclinedText;
    problem.accepted = false;
  }

}
