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
	void OnEnabled()
	{
		if (currentCustomer.problem)
		{
			welpReviewText.text = currentCustomer.problem.GetResponse ();
		}
	}
}
