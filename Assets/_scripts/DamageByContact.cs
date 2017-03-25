using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	public int scoreValue;
	private GameController gameController;
	private HealthBar healthBar;

	public int damageAmount;

	void Start() {
		healthBar = GetComponent<HealthBar> ();

		GameObject gameControllerObj = GameObject.FindWithTag ("GameController");

		if (gameControllerObj != null) {
			gameController = gameControllerObj.GetComponent<GameController> ();
		}

		if (gameController == null) {
			Debug.Log ("cannot find GameController lol");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Boundary") {
			return;
		}

		if (other.tag == "Bolt") {
			healthBar.damage (damageAmount);

			if (healthBar.gone ()) {
				Instantiate (explosion, transform.position, transform.rotation);
				gameController.addScore (scoreValue);
				Destroy (gameObject);
			}
		}


		if (other.tag == "Player") {
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		Destroy(other.gameObject);
	}
}
