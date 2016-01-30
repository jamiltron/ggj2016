using UnityEngine;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour {

  public Customer customer;

  void Start() {
    if (customer == null) {
      customer = GameObject.FindGameObjectWithTag("Customer").GetComponent<Customer>();
    }
  }

  void Update() {
	
  }
}
