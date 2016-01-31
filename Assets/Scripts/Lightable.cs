using UnityEngine;
using System.Collections;

public class Lightable : MonoBehaviour {

  public GameObject flame;
  public LayerMask grabMask;

  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      Debug.Log("mouse down!");
      Vector3 objScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
      Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z);
      Vector3 vec = Camera.main.ScreenToWorldPoint(currentScreenSpace);

      RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.right, 0.1f, grabMask);
      if (hit.transform != null) {
        if (hit.transform.gameObject == this.gameObject) {
          ToggleLight();
        }
      }
    }
  }

  public void ToggleLight() {
    if (flame.activeSelf) {
      flame.SetActive(false);
    } else {
      flame.SetActive(true);
    }
  }
}
