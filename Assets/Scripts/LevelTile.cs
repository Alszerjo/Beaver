using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTile : MonoBehaviour {

	static LevelTile[,] TileMatrix;

	[Header("Init Only")]
	[SerializeField]
	private int MatrixWidth;
	[SerializeField]
	private int MatrixHeight;
	public GameObject BaseTile;
	[HideInInspector]
	public int X, Y;
	public GameObject ReplaceTest;

	void Start () {
		if (TileMatrix == null) {
			TileMatrix = new LevelTile[MatrixHeight, MatrixWidth];
			for (int y = 0; y < MatrixWidth; y++) {
				for (int x = 0; x < MatrixHeight; x++) {
					GameObject t = Instantiate(BaseTile, transform.position + (Vector3.right * y) + (Vector3.forward * x), Quaternion.identity);
					LevelTile lt = t.AddComponent<LevelTile> ();
					lt.X = x;
					lt.Y = y;
					TileMatrix [x, y] = lt;
				}
			}
			TileMatrix [3, 7].ReplaceTile (ReplaceTest);
		}
	}

	void ReplaceTile(GameObject newTile){
		LevelTile lt = newTile.AddComponent<LevelTile> ();
		lt.X = X;
		lt.Y = Y;
		TileMatrix [X, Y] = lt;
		newTile.transform.position = gameObject.transform.position;
		GameObject.Destroy (gameObject);
	}

}
