

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CureManager : MonoBehaviour {

	public GameObject meshedParent;

	public List<string> objectsUsed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void StartTheCure()
	{
		objectsUsed = new List<string> ();


	}

	public void MeshObject(Draggable item)
	{
		objectsUsed.Add (item.type);
		if (item.itemBehavior == ItemBehavior.sticky) {
			item.gameObject.transform.SetParent (meshedParent.transform);
			item.GetComponent<Collider2D> ().enabled = false;
		} else {
			//item.GetComponent<Animation>().Play("Sprinkle");
			item.ReturnToOriginalPlace();
		}
	}
}
