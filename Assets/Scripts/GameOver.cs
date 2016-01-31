using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

  public int averageRating;
  public Image[] stars;

  public void ShowRating() {
    for (int i = 0; i < averageRating; i++) {
      stars[i].gameObject.SetActive(true);
    }
  }

  public void HideRating() {
    for (int i = 0; i < stars.Length; i++) {
      stars[i].gameObject.SetActive(true);
    }
  }
}
