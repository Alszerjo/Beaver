using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {

	public int color;
	private Vector3 startpos;
	public GameObject flag;
	private int counter = 0;
	// Use this for initialization
	void Start () {
		startpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = startpos + Vector3.up * 1 * Mathf.Sin (Time.time + startpos.x);
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "FlagLaser") {
			if (OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f) {
				Instantiate (flag, transform.parent);
				transform.parent.gameObject.GetComponent<Diggable> ().flagged = true;
				GameObject.Destroy (gameObject);
				FlagTools.counter++;
			}
		}
	}
		
}
