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

    newProblems.Shuffle();

    GenerateNewCustomer();
  }

  public void GenerateNewCustomer() {
    for (int i = 0; i < newProblems.Count; i++) {
      Problem problem = newProblems[i];
      if (problem.problemType == customer.problemType) {
        customer.problem = problem;
        newProblems.RemoveAt(i);
        customer.PitchProblem();
        return;
      }
    }
    throw new UnityException("Unable to find problem for customer with problemType: " + customer.problemType);
  }
}
