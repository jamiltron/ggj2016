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
	for (int i = 0; i < rating && i<stars.Length; i++) {
      stars[i].gameObject.SetActive(true);
    }
  }

  public void ClearStars() {
    for (int i = 0; i < stars.Length; i++) {
      stars[i].gameObject.SetActive(false);
    }
  }
}
