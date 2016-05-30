using UnityEngine;
using System.Collections;

public class FalseGroundScript : MonoBehaviour {
	
	private Color red = Color.red;
	//private Color white = Color.white;
	//private bool canPlaceTurret = false;
	
	private SpriteRenderer sprite;
	
	// Use this for initialization
	void Awake() {
		sprite = GetComponentInChildren<SpriteRenderer>();
	}
	
	void Start(){
		sprite.color = red;
		sprite.enabled = false;
	}
	
	void OnMouseOver(){
		//Show the red sprite
		sprite.enabled = true;
	}
	
	void OnMouseExit(){
		//Hide the red sprite
		sprite.enabled = false;
	}
}
