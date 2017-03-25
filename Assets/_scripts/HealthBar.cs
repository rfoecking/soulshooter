using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	private int currentHealth;
	public int maxHealth;
	public TextMesh healthText;

	// Use this for initialization
	void Start () {
		currentHealth = maxHealth;
		updateText ();
	}

	public void damage(int damageAmount) {
		currentHealth -= damageAmount;
		updateText ();
	}

	public bool gone() {
		return currentHealth <= 0;
	}

	public int getHealth() {
		return currentHealth;
	}

	void updateText() {
		healthText.text = currentHealth.ToString ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
