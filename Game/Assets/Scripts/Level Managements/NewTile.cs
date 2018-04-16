using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New 3D Tile", menuName = "Custom Scripable Objects/Terrain/3D Tile")]
public class NewTile : ScriptableObject {

	public int TileID;
	public string TileName;

	public int TileType;

	public Material TileTexture;



}
