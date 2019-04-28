using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTile : MonoBehaviour {

	static public LevelTile[,] TileMatrix;

	[Header("Init Only")]
	[SerializeField]
	private int MatrixWidth;
	[SerializeField]
	private int MatrixHeight;
	public GameObject BaseTile;
	public GameObject DugTile;
	//[HideInInspector]
	public int X, Y;
	static private Transform LevelParent;
	private float pos_scale = 2f;

	void Start () {
		if (TileMatrix == null) {
			LevelParent = transform;
			TileMatrix = new LevelTile[MatrixHeight, MatrixWidth];
			for (int y = 0; y < MatrixWidth; y++) {
				for (int x = 0; x < MatrixHeight; x++) {
					GameObject t = Instantiate(BaseTile, transform.position + (Vector3.right * y * pos_scale) + (Vector3.forward * x * pos_scale), Quaternion.identity, LevelParent);
					LevelTile lt = t.AddComponent<LevelTile> ();
					lt.X = x;
					lt.Y = y;
					TileMatrix [x, y] = lt;
				}
			}
			Diggable.DugGround = DugTile;
			Diggable.MarkedTiles = new List<Diggable> ();
			GameObject.FindObjectOfType<FlagTools> ().CreateHazards ();
		}
	}

	public void ReplaceTile(GameObject newTile){
		newTile.transform.parent = LevelParent;
		LevelTile lt = newTile.AddComponent<LevelTile> ();
		lt.X = X;
		lt.Y = Y;
		TileMatrix [X, Y] = lt;
		newTile.transform.position = gameObject.transform.position;
		GameObject.Destroy (gameObject);
	}

}
