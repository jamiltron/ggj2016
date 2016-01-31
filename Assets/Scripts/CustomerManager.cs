using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CustomerManager : MonoBehaviour {

  [Range(1, 5)]
  public int positiveRatingThreshold = 4;

  [Range(1, 5)]
  public int averageRatingThreshold = 3;

  [Range(1, 5)]
  public int negativeRatingThreshold = 2;

  public Customer currentCustomer;

  public List<GameObject> customerPrefabs;
  public List<Customer> completedCustomers;

  // new problems represent all problems that have yet to be handled
  public List<Problem> newProblems;

  // problems that have either been accepted or declined
  public List<Problem> completedProblems;

  public Text speechTextBox;

  public Canvas pitchCanvas;
 
  public GameObject handButton;


  void Awake() {
    Object.DontDestroyOnLoad(gameObject);
  }

  void Start() {

    newProblems.Shuffle();
    customerPrefabs.Shuffle();

    GenerateNewCustomer();
  }

  public void GenerateNewCustomer() {

    // TODO: handle when we are out of customers
    if (customerPrefabs.Count > 0) {
      pitchCanvas.gameObject.transform.parent.gameObject.SetActive(true);
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
          if (pitchCanvas)
            pitchCanvas.enabled = true;
          if (SoundManager.instance)
            SoundManager.instance.PlayNewCustomerArrival();
          return;
        }
      }
      throw new UnityException("Unable to find problem for customer with problemType: " + currentCustomer.problemType);
    }
  }

  public void HelpCustomer() {
    currentCustomer.Help();
    handButton.SetActive(true);
    if (SoundManager.instance)
      SoundManager.instance.PlayButtonClickSfx();

  }

  public void DeclineCustomer() {
    currentCustomer.Decline();
    completedProblems.Add(currentCustomer.problem);
    if (SoundManager.instance) {
      SoundManager.instance.PlayButtonClickSfx();
    }
  }

  public void DismissCustomer() {
    if (currentCustomer != null) {
      completedCustomers.Add(currentCustomer);
      currentCustomer.gameObject.SetActive(false);
    }
  }

  public string GenerateReview() {
    if (currentCustomer.problem.accepted) {
      int r = UnityEngine.Random.Range(1, 5);
      currentCustomer.problem.rating = r;
      Debug.Log("RATING: " + r);
      if (r >= positiveRatingThreshold) {
        return currentCustomer.problem.positiveResponse;
      } else if (r >= averageRatingThreshold) {
        return currentCustomer.problem.averageResponse;
      } else {
        return currentCustomer.problem.negativeResponse;
      }
    } else {
      currentCustomer.problem.rating = UnityEngine.Random.Range(1, 2);
      return currentCustomer.problem.refusalResponse;
    }
  }

  public int GetCurrentRating() {
    return currentCustomer.problem.rating;
  }
}
