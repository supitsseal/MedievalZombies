using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

	public NewTile thisTile;

	void Start() {
		MeshRenderer MR = (MeshRenderer)this.GetComponent("MeshRenderer");
		MR.material = thisTile.TileTexture;
	}
}
