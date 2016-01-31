using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {

  public LayerMask grabMask;
  public float zoomSpeed = 2f;
  public float zoomThreshold = 0.1f;
  private bool zooming = false;

  bool isMouseDrag;
  Vector3 offset;
  Vector3 objScreenPosition;

  // Update is called once per frame
  void Update() {
    if (Input.GetMouseButtonDown(0)) {
      objScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
      offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z));
      Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z);
      Vector3 vec = Camera.main.ScreenToWorldPoint(currentScreenSpace);

      RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.right, 0.1f, grabMask);
      if (hit.transform != null) {
        if (hit.transform.gameObject == this.gameObject) {
          isMouseDrag = true;
        }
      }
    }
    if (Input.GetMouseButtonUp(0)) {
      isMouseDrag = false;
    }
    if (isMouseDrag) {
      //track mouse position.
      Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z);
      //convert screen position to world position with offset changes.
      Vector3 nextPos = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
      //It will update target gameobject's current postion.
      Vector3 newNextPos = new Vector3(nextPos.x, nextPos.y, transform.position.z);

      RaycastHit2D hit = Physics2D.Raycast(nextPos, Vector2.right, 0.1f);
      if (hit.transform != null) {
        if (hit.transform.gameObject.tag == "ZoomZone" && !zooming) {
          StartCoroutine(ChangeZLevels(hit.transform.gameObject.GetComponent<ZoomZone>().zLevel));
        }
      }

      transform.position = newNextPos;
    }
  }

  public IEnumerator ChangeZLevels(float targetZ) {
    zooming = true;
    while (Mathf.Abs(targetZ - transform.position.z) > zoomThreshold) {
      Vector3 target = transform.position;
      target.z = targetZ;
      transform.position = Vector3.Lerp(transform.position, target, zoomSpeed * Time.deltaTime);
      yield return null;
    }

    Vector3 vec = transform.position;
    vec.z = targetZ;
    transform.position = vec;
    zooming = false;
  }
}
