using UnityEngine;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour {

  public Customer customer;

  // new problems represent all problems that have yet to be handled
  public List<Problem> newProblems;

  // problems that have either been accepted or declined
  public List<Problem> completedProblems;

  void Start() {
    if (customer == null) {
      customer = GameObject.FindGameObjectWithTag("Customer").GetComponent<Customer>();
    }

    GenerateNewCustomer();
  }

  public void GenerateNewCustomer() {
    int i = UnityEngine.Random.Range(0, newProblems.Count);
    customer.problem = newProblems[i];
    newProblems.RemoveAt(i);

    customer.PitchProblem();
  }
}
