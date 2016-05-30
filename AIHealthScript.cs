using UnityEngine;
using System.Collections;

public class AIHealthScript : MonoBehaviour {

	public float maxHealth = 12f;
	private float healthX;

	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		healthX = transform.localScale.x;

		sprite = gameObject.GetComponent<SpriteRenderer> ();
		sprite.color = Color.clear;
	}

	void AdjustHealth(float damage){
		//resize health based on damage taken
		sprite.color = new Color (1f, 1f, 1f, 0.75f);
		transform.localScale -= new Vector3((healthX * (damage / maxHealth)), 0, 0);
	}
}
