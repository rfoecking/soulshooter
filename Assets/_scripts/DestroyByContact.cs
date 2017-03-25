using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start() {
		GameObject gameControllerObj = GameObject.FindWithTag ("GameController");

		if (gameControllerObj != null) {
			gameController = gameControllerObj.GetComponent<GameController> ();
		}

		if (gameController == null) {
			Debug.Log ("cannot find GameController lol");
		}
	}

	void OnTriggerEnter(Collider other) {
		// Destroy everything that leaves the trigger
		//Debug.Log(other.name);

		if (other.tag == "Boundary") {
			return;
		}
		Instantiate(explosion, transform.position, transform.rotation);

		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}
		gameController.addScore (scoreValue);
		Destroy(other.gameObject);
		Destroy (gameObject);
	}
}
