using UnityEngine;
using System.Collections;

public class AIbgHealthScript : MonoBehaviour {

	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		sprite = gameObject.GetComponent<SpriteRenderer> ();
		sprite.color = Color.clear; //only show health if less than max
	}
	
	void AdjustHealth(float damage){
		sprite.color = new Color (1f, 1f, 1f, 0.75f);
	}
}
