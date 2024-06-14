using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public int health = 10;

	public void TakeDamage(int damage) {
		health -= damage;
		if (health<=0) {
			health = 0;
			Debug.Log("Player dead");
			GetComponent<PlayerControls>().speed = 0;
		}
	}
}
