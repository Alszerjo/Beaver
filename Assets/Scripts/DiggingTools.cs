using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiggingTools : MonoBehaviour {

	[SerializeField] GameObject Shovel;
	[SerializeField] GameObject LaserPointer;
	[SerializeField] GameObject FlagPointer;

	void Start(){
		Shovel.SetActive (true);
		LaserPointer.SetActive (false);
		FlagPointer.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown (OVRInput.Button.One)) {
			Shovel.SetActive (LaserPointer.activeSelf);
			LaserPointer.SetActive (!LaserPointer.activeSelf);
		} else if (OVRInput.GetDown (OVRInput.Button.Two)) {
			Diggable.Scoop ();
		}
	}
}
