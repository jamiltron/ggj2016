using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WelpCanvas : MonoBehaviour {

	public Text welpReviewText;

	public void ShowResponseText()
	{
		Customer currentCustomer = GameObject.Find("GameManager").GetComponent<CustomerManager>().currentCustomer;

		if (currentCustomer.problem)
		{
			if (welpReviewText==null) {
				Debug.Log ("review text is empty");
			}
			welpReviewText.text = currentCustomer.problem.GetResponse ();
			GetComponent<Canvas> ().enabled = true;
		}
	}
}
