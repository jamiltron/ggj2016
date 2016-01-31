using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WelpCanvas : MonoBehaviour {

  public Text welpReviewText;
  public int rating;

  public Image[] stars;

  public void ShowResponseText() {
    CustomerManager customerManager = GameObject.Find("GameManager").GetComponent<CustomerManager>();

    welpReviewText.text = customerManager.GenerateReview();
    rating = customerManager.GetCurrentRating();
    SetStars();
    GetComponent<Canvas>().enabled = true;
  }

  public void SetStars() {
    for (int i = 0; i < rating; i++) {
      stars[i].gameObject.SetActive(true);
    }
  }

  /* if (currentCustomer.problem) {
      if (welpReviewText == null) {
        Debug.Log("review text is empty");
      }
      welpReviewText.text = currentCustomer.problem.GetResponse();
      GetComponent<Canvas>().enabled = true;
    }
  }*/
}
