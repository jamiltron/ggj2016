using UnityEngine;
using System.Collections;

public class HeightLimiter : MonoBehaviour {

  public float minHeight = -0.5f;

  private Collider2D col;
  private Transform trans;

  void Start() {
    col = GetComponent<Collider2D>();
    trans = GetComponent<Transform>();
  }

  void Update() {

  }

  void LateUpdate() {
    float halfY = col.bounds.size.y / 2;
    Debug.Log(trans.position.y - halfY);
    if (trans.position.y - halfY < minHeight) {
      Debug.Log("LIMITING!");
      Vector3 vec = trans.position;
      vec.y = minHeight + halfY;
      trans.position = vec;
    }
  }
}
