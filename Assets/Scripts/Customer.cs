using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Customer : MonoBehaviour {
  public ProblemType problemType;
  public Problem problem;
  public Text speechTextBox;

  void Awake() {
    if (speechTextBox == null) {
      speechTextBox = GameObject.FindGameObjectWithTag("SpeechBubble").GetComponent<Text>();
    }
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
