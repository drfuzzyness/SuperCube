using UnityEngine;
using System.Collections;

public class RoadManager : MonoBehaviour {

	public PlayerMovement player;
	[Header("Balance")]
	public float drawDistance;
	public float enemyChance;

	[Header("Assets")]
	public GameObject roadTile;
	public Vector3 roadTileSize;
	public GameObject enemyObject;

	private Vector3 previousPosition;

	// Use this for initialization
	void Start () {
		previousPosition = roadTile.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if( previousPosition.z < player.transform.position.z + drawDistance ) {
			generateTile();
		}
	}

	void generateTile() {
		Instantiate( roadTile, previousPosition + Vector3.forward * roadTileSize.z, roadTile.transform.rotation );
		previousPosition.z += roadTileSize.z;
	}
}
