using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public Coin coinPrefab;
	public GameObject blockadePrefab;

	public float chanceForCoinInLane;
	public float chanceForBlockade;
	public float distanceBetweenLanes;
	public float heightOfCoin;
//	public float chanceForBuilding;

	// Use this for initialization
	void Start () {
//		StartCoroutine("grow");
		GenerateStuff();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Generates "stuff"
	void GenerateStuff() {
		int numblockades = 0;
		for( int i = 0; i < 3; i++ ) {
			float sample = Random.Range(0f,1f );
			if( sample < chanceForCoinInLane ) {
				Instantiate( coinPrefab,
				            transform.position + Vector3.right * ( distanceBetweenLanes * ( i - 1 ) ) + Vector3.up * heightOfCoin,
				            transform.rotation );
			} else if ( sample < chanceForCoinInLane + chanceForBlockade && numblockades < 2 ) {
				Instantiate( blockadePrefab,
				            transform.position + Vector3.right * ( distanceBetweenLanes * ( i - 1 ) ) + Vector3.up * heightOfCoin,
				            transform.rotation );
				numblockades++;
			}

		}

	}


	IEnumerator grow() {
		Vector3 orig = transform.localScale;
		transform.localScale = new Vector3( 0, 0, 0);
		for( int i = 0; i < 10; i++ ) {
			yield return null;
			transform.localScale += orig / 10;
		}
		transform.localScale = orig;
	}
}
