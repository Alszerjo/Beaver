using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diggable : MonoBehaviour {

	static public GameObject DugGround;
	private int DigHealth = 2;
	public bool flagged = false;

	static public List<Diggable> MarkedTiles;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Shovel") {
			DigHealth--;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Shovel") {
			if (DigHealth <= 0) {
				gameObject.GetComponent<LevelTile> ().ReplaceTile (Instantiate (DugGround));
			}
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "Laser") {
			if (OVRInput.Get (OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f) {
				MarkForScoop ();
			} else if (OVRInput.Get (OVRInput.Axis1D.SecondaryHandTrigger) > 0.5f) {
				UnmarkForScoop ();
			}
		}
	}

	void MarkForScoop(){
		Vector3 pos = transform.position;
		pos.y = 0.7f;
		transform.position = pos;
		MarkedTiles.Add (this);
	}

	void UnmarkForScoop(){
		Vector3 pos = transform.position;
		pos.y = 0f;
		transform.position = pos;
		MarkedTiles.Remove (this);
	}

	static public void Scoop(){
		foreach (Diggable d in MarkedTiles) {
			//if (d.flagged) {
			//	SceneManager.LoadScene ("Loose");
			//}
			d.gameObject.transform.Translate (0f, -0.7f, 0f);
			d.gameObject.GetComponent<LevelTile> ().ReplaceTile (Instantiate (DugGround));
		}
		MarkedTiles.Clear ();
	}
}
