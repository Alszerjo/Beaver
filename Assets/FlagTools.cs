using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagTools : MonoBehaviour {

	public GameObject Hazard1;
	public GameObject Hazard2;
	public GameObject Hazard3;

	static public int counter = 0;

	public void CreateHazards(){
		Instantiate (Hazard1, LevelTile.TileMatrix [2, 4].transform);
		Instantiate (Hazard2, LevelTile.TileMatrix [5, 1].transform);
		Instantiate (Hazard3, LevelTile.TileMatrix [6, 8].transform);
	}

	void Update(){
		if (counter >= 3) {
			gameObject.GetComponent<DiggingTools> ().enabled = true;
			this.enabled = false;
		}
	}
}
