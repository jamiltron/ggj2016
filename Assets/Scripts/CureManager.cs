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

	public void MeshObject(GameObject go,string type)
	{
		objectsUsed.Add (type);
		go.transform.SetParent( meshedParent.transform);
		go.GetComponent<Collider2D> ().enabled = false;
	}
}
