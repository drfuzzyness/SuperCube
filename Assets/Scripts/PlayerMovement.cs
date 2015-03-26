using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	[Header("Balance")]
	public float maxSpeed;

	[Header("Setup")]
	public float distanceBetweenLanes;

	private float currentSpeed;
	private int currentLane;



	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter(Collision col) {
		// gameover
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown( KeyCode.A ) ) {
			// move left
		} else if( Input.GetKeyDown( KeyCode.D ) ) { 
			// move right
		}	else if( Input.GetKeyDown( KeyCode.Space ) ) {
			// space?
		}
	}
}
