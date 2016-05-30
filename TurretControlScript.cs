using UnityEngine;
using System.Collections;

public class TurretControlScript : MonoBehaviour {

	public float damageAmount = 4f;

	private float atkTimer = 2f; // Start off timer greater than the atk interval so it can attack immeadately
	private float atkTime = 1.6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(atkTimer > atkTime){
			//for testing purposes
//			Debug.DrawLine(transform.position, 
//			               transform.position + (transform.up * 50), 
//			               Color.cyan);

			//Searches for enemies with a range of 50 units
			RaycastHit2D hit = Physics2D.Linecast(transform.position, 
			                                  transform.position + (transform.up * 50), 
		                                      1 << LayerMask.NameToLayer("EnemyLayer"));
			if(hit.collider != null){
				//Tell the enemy it was hit
				hit.collider.SendMessage("Hit", damageAmount);

				atkTimer = 0f;
			}
		}
		else{
			atkTimer += Time.deltaTime;
		}
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Destroy(gameObject); //Ruin that turret's day
		}
	}
}
