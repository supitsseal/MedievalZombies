using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D levels;
	public Texture2D actors;
	public Texture2D gameObjects;

	[Header("Boundries")]
	public Vector4 levelBoundries;
	public Vector4 levelSpawnBoundries;

	[Header("Objects")]
	private List<GameObject> levelObjects = new List<GameObject>();
	private List<GameObject> actorObjects = new List<GameObject>();
	private List<GameObject> gameObjectList = new List<GameObject>();

	[Header("Keys")]
	public LevelColorKey[] levelColorKey;
	public LevelColorKey[] actorColorKey;
	public LevelColorKey[] objectColorKey;

	private Vector2 posMult;

	void Start() {
		posMult = new Vector2 (transform.position.x, transform.position.z);
        LoadLevel();

    }

	public void DeleteLevel() {
		for (int i = 0; i < transform.childCount; i++) {
			if (transform.GetChild (i).name == "Player") {
				return;
			} else {
				Destroy (transform.GetChild (i));
			}
		}
	}

	public void LoadLevel() {
		posMult = new Vector2 (transform.position.x, transform.position.z);
		Texture2D tempLevels = levels;
		Texture2D tempActors = actors;
		Texture2D tempGO = gameObjects;

		for (int x = 0; x < tempLevels.width; x++) {
			for (int y = 0; y < tempLevels.height; y++) {
				
				Vector2 pos = new Vector2 (posMult.x + x, posMult.y + y);
				GenerateTile (pos, tempLevels);
				GenerateActors (pos, tempActors);
				GenerateGameObjects (pos, tempGO);
			}
		}
	}

	// Tile Generator
	void GenerateTile(Vector2 pos, Texture2D map) {
		Color pixelColor = map.GetPixel ((int)pos.x, (int)pos.y);

		if (pixelColor.a == 0) {
			return;
		}

		foreach (LevelColorKey colorCode in levelColorKey) {
			if (colorCode.color.Equals (pixelColor)) {

				Vector3 position = new Vector3 (pos.x, 0, pos.y);
				GameObject tile = Instantiate (colorCode.tile, position, Quaternion.identity, transform);
				levelObjects.Add (tile);
			}
		}


	}

	//Actor Generator
	void GenerateActors(Vector2 pos, Texture2D map) {
		Color pixelColor = map.GetPixel((int)pos.x, (int)pos.y);

		if (pixelColor.a == 0) {
			return;
		}

		foreach (LevelColorKey colorCode in actorColorKey) {
			if (colorCode.color.Equals (pixelColor)) {

				Vector3 position = new Vector3 (pos.x, 0, pos.y);
				if (colorCode.tile.name == "Player") {
					Instantiate (colorCode.tile, position, Quaternion.AngleAxis (90.0000f, Vector3.right), transform);
				} else {
					actorObjects.Add (Instantiate (colorCode.tile, position, Quaternion.AngleAxis (90.0000f, Vector3.right), transform));
				}
			}
		}


	}

	// Game Object Generator
	void GenerateGameObjects(Vector2 pos, Texture2D map) {
		Color pixelColor = map.GetPixel((int)pos.x, (int)pos.y);

		if (pixelColor.a == 0) {
			return;
		}

		foreach (LevelColorKey colorCode in objectColorKey) {
			if (colorCode.color.Equals (pixelColor)) {

				Vector3 position = new Vector3 (pos.x, 0, pos.y);
				gameObjectList.Add(Instantiate (colorCode.tile, position, Quaternion.identity, transform));
			}
		}


	}
}
