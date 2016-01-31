using UnityEngine;
using System.Collections;

public class dilaradragtest : MonoBehaviour {

	bool isMouseDrag;
	Vector3 offset;
	Vector3 objScreenPosition;

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			isMouseDrag = true;
			objScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
			offset = transform.position - Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z));

		}
		if (Input.GetMouseButtonUp(0))
		{
			isMouseDrag = false;
		}
		if (isMouseDrag)
		{
			//track mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objScreenPosition.z);
			//convert screen position to world position with offset changes.
			Vector3 nextPos = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
			//It will update target gameobject's current postion.

			//Trying to update the z
			float deltaZ = nextPos.y -transform.position.y;
			nextPos.z += deltaZ;
			Debug.Log (nextPos);

			transform.position = nextPos;
		}
	}
}
