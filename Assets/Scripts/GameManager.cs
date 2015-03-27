using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public int score;
	public Text scoreDisplay;
	public bool paused;
	public RoadManager roadManager;
	public PlayerMovement player;

	[Header("Camera")]
	public float cameraTransitionTime;
	public Transform cameraPlayPos;
	public Transform cameraPausePos;
	public Transform mainCamera;

	public void scorePoint( int points ) {
		score += points;
		scoreDisplay.text = score.ToString();
	}

	public void gameOver() {
		Application.LoadLevel( Application.loadedLevel );
	}

	// Use this for initialization
	void Start () {
		pauseGame();
	}
	
	// Update is called once per frame
	void Update () {
		if( Input.GetKeyDown( KeyCode.Space ) ) {
			startGame();
		}
	}

	void startGame() {
		paused = false;
		player.enabled = true;
		roadManager.enabled = true;
		StartCoroutine( "moveCameraToPlayPos" );
	}

	void pauseGame() {
		paused = true;
		player.enabled = false;
		roadManager.enabled = false;
	}

	IEnumerator moveCameraToPlayPos() {
		for( float i = 0f; i < cameraTransitionTime; i += Time.deltaTime ) {
			mainCamera.Translate(  ( cameraPlayPos.position - mainCamera.position ) / 2  );
			mainCamera.Rotate( ( cameraPlayPos.eulerAngles - mainCamera.eulerAngles ) / 2 );
			yield return null;
		}
		mainCamera.position = cameraPlayPos.position;
		mainCamera.rotation = cameraPlayPos.rotation;
	}
}
