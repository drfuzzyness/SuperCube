using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour {

	[Header("Balance")]
	public float maxSpeed;
	public float laneChangeTime;


	[Header("Setup")]
	public GameManager gameManager;
	public float distanceBetweenLanes;
	public int lanes;
	public ParticleSystem coinExplosion;

	private bool control;
	private float currentSpeed;
	private int currentLane;



	// Use this for initialization
	void Start () {
		currentLane = 1;
		control = true;
	}

	void OnCollisionEnter(Collision col) {
		if( col.gameObject.tag == "Coin" ) {
			gameManager.scorePoint( col.gameObject.GetComponent<Coin>().points );
			Instantiate( coinExplosion, col.gameObject.transform.position, col.gameObject.transform.rotation );
			Destroy( col.gameObject );
		} else if ( col.gameObject.tag == "Blockade" ) {
			//gameover
			gameManager.gameOver();
		}

	}
	
	// Update is called once per frame
	void Update () {
		if( control ) {
			if( Input.GetKeyDown( KeyCode.A ) ) {
				if( currentLane > 0 )
					StartCoroutine("moveLeft");
			} else if( Input.GetKeyDown( KeyCode.D ) ) { 
				if( currentLane < lanes - 1 )
					StartCoroutine("moveRight");
			} else if( Input.GetKeyDown( KeyCode.Space ) ) {
				// space?
			}
		}
		// keep player moving. if the player hits a snap, bump the player up
		if( GetComponent<Rigidbody>().velocity.z < 1 ) {
			transform.position += Vector3.up * .1f;
		}
		Vector3 tempVel = GetComponent<Rigidbody>().velocity;
		tempVel.z = maxSpeed;
		GetComponent<Rigidbody>().velocity = tempVel;
	}

	void moveToLane( int targetLane ) {
		if( currentLane < targetLane ) {
			StartCoroutine("moveLeft");
		}
	}

	IEnumerator moveLeft() {
		Vector3 targetPosition = transform.position - Vector3.right * distanceBetweenLanes;
		currentLane--;
		control = false;
		for( float i = 0f; i < laneChangeTime; i += Time.deltaTime ) {
			transform.Translate(  ( targetPosition.x - transform.position.x ) / 2 * Vector3.right  );
			yield return null;
		}
		Vector3 temp =  transform.position;
		temp.x = targetPosition.x;
		transform.position = temp;
		control = true;
	}

	IEnumerator moveRight() {
		Vector3 targetPosition = transform.position + Vector3.right * distanceBetweenLanes;
		currentLane++;
		control = false;
		for( float i = 0f; i < laneChangeTime; i += Time.deltaTime ) {
			transform.Translate(  ( targetPosition.x - transform.position.x ) / 2 * Vector3.right  );
			yield return null;
		}
		Vector3 temp =  transform.position;
		temp.x = targetPosition.x;
		transform.position = temp;
		control = true;
	}
}
