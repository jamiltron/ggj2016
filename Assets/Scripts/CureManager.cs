

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CureManager : MonoBehaviour {

	public GameObject meshedParent;

	public List<string> objectsUsed;

	public void StartTheCure()
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
			if(SoundManager.instance)
				SoundManager.instance.PlayPotionSfx ();
			SpriteRenderer[] sprites = meshedParent.GetComponentsInChildren<SpriteRenderer> ();
			foreach (SpriteRenderer s in sprites) {
				s.color = item.sprinkleColor;
			}
			item.GetComponent<Animation>().Play();
			item.ReturnToOriginalPlace();
		}
	}
}
