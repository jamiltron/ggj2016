using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour {

  public Customer currentCustomer;

  public List<GameObject> customerPrefabs;
  public List<Customer> completedCustomers;

  // new problems represent all problems that have yet to be handled
  public List<Problem> newProblems;

  // problems that have either been accepted or declined
  public List<Problem> completedProblems;

  public Text speechTextBox;

  void Awake() {
    Object.DontDestroyOnLoad(gameObject);
  }

  void Start() {

    newProblems.Shuffle();
    customerPrefabs.Shuffle();

    GenerateNewCustomer();
  }

  public void GenerateNewCustomer() {
    if (currentCustomer != null) {
      completedCustomers.Add(currentCustomer);
      currentCustomer.gameObject.SetActive(false);
    }

    // TODO: handle when we are out of customers
    GameObject customerObject = GameObject.Instantiate(customerPrefabs[0]);
    currentCustomer = customerObject.GetComponent<Customer>();
    if (speechTextBox == null) {
      speechTextBox = GameObject.FindGameObjectWithTag("SpeechBubble").GetComponent<Text>();
    }
    currentCustomer.speechTextBox = speechTextBox;
    customerPrefabs.RemoveAt(0);

    for (int i = 0; i < newProblems.Count; i++) {
      Problem problem = newProblems[i];
      if (problem.problemType == currentCustomer.problemType) {
        currentCustomer.problem = problem;
        newProblems.RemoveAt(i);
        currentCustomer.PitchProblem();
        return;
      }
    }
    throw new UnityException("Unable to find problem for customer with problemType: " + currentCustomer.problemType);
  }

  public void HelpCustomer() {
    currentCustomer.Help();
  }

  public void DeclineCustomer() {
    currentCustomer.Decline();
    completedProblems.Add(currentCustomer.problem);
  }
}
