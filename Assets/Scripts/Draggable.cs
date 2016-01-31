using UnityEngine;
using System.Collections;

public enum ItemBehavior
{
  sprinkable,
  sticky
}

public class Draggable : MonoBehaviour
{

  public LayerMask meshMask;
  public LayerMask grabMask;
  public string type;
  public ItemBehavior itemBehavior;
  public float zoomSpeed = 2f;
  public float zoomThreshold = 0.1f;
  private bool zooming = false;

  //for sprinking
  public Color sprinkleColor;
  Vector3 initialPosition;
  public Animation sprinkleAnim;
  bool returnToPos = false;

  bool isMouseDrag;
  Vector3 offset;
  Vector3 objScreenPosition;

  void Start()
  {
    initialPosition = transform.position;
    sprinkleAnim = GetComponent<Animation>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
      {
      
        objScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z));
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z);
        Vector3 vec = Camera.main.ScreenToWorldPoint(currentScreenSpace);

        RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.right, 0.1f, grabMask);
        if (hit.transform != null)
          {
            if (hit.transform.gameObject == this.gameObject)
              {
                isMouseDrag = true;
                returnToPos = false;
              }
          }
      }
    if (Input.GetMouseButtonUp(0))
      {
        if (isMouseDrag)
          {	
            objScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z));
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z);
            Vector3 vec = Camera.main.ScreenToWorldPoint(currentScreenSpace);

            RaycastHit2D hit = Physics2D.Raycast(vec, Vector2.right, 0.1f, meshMask);
            Debug.DrawLine(vec, hit.point);
            if (hit.transform != null)
              {
                hit.transform.gameObject.GetComponent<CureManager>().MeshObject(this);
              }
          }
        isMouseDrag = false;
      }
    if (isMouseDrag)
      {
        //track mouse position.
        Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z);
        //convert screen position to world position with offset changes.
        Vector3 nextPos = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
        //It will update target gameobject's current postion.
        Vector3 newNextPos = new Vector3(nextPos.x, nextPos.y, transform.position.z);

        RaycastHit2D hit = Physics2D.Raycast(nextPos, Vector2.right, 0.1f);
        if (hit.transform != null)
          {
            if (hit.transform.gameObject.tag == "ZoomZone" && !zooming)
              {
                StartCoroutine(ChangeZLevels(hit.transform.gameObject.GetComponent<ZoomZone>().zLevel));
              }
          }

        transform.position = newNextPos;
      } else if (returnToPos)
      {
        if (Vector3.Distance(transform.position, initialPosition) > 0.1f)
          transform.position = Vector3.Lerp(transform.position, initialPosition, Time.deltaTime * 2.5f);
        else
          returnToPos = false;
      }
  }

  public void ReturnToOriginalPlace()
  {
    returnToPos = true;
  }

  public IEnumerator ChangeZLevels(float targetZ)
  {
    zooming = true;
    while (Mathf.Abs(targetZ - transform.position.z) > zoomThreshold)
      {
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
