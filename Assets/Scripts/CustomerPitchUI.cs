using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CustomerPitchUI : MonoBehaviour {

  public GameObject helpButton;
  public GameObject dontHelpButton;
  public GameObject continueButton;
  public GameObject nextCustomerButton;
  public GameObject byeButton;

  public void EnableHelpButtons() {
    helpButton.SetActive(true);
    dontHelpButton.SetActive(true);
  }

  public void DisableHelpButtons() {
    helpButton.SetActive(false);
    dontHelpButton.SetActive(false);
  }

	public void EnableByeButton()
	{
		byeButton.SetActive (true);
	}
	public void DisableByeButton()
	{
		byeButton.SetActive (false);
	}

  public void EnableNextCustomerButton() {
    nextCustomerButton.SetActive(true);
  }

  public void DisableNextCustomerButton() {
    nextCustomerButton.SetActive(false);
  }

  public void EnableContinueButton() {
    continueButton.SetActive(true);
  }

  public void DisableContinueButton() {
    continueButton.SetActive(false);
  }


}
