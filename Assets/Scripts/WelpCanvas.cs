using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WelpCanvas : MonoBehaviour {

	public Text welpReviewText;
	Customer currentCustomer;
	void Awake()
	{
		if (currentCustomer == null) {
			currentCustomer = GameObject.FindGameObjectWithTag("Customer").GetComponent<Customer>();
		}
	}
	public void ShowResponseText()
	{
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
