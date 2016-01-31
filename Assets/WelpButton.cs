using UnityEngine;
using System.Collections;

public class WelpButton : MonoBehaviour {

	void OnEnable()
	{
		if (SoundManager.instance)
			SoundManager.instance.PlayWelpNotification ();
	}
		
}
