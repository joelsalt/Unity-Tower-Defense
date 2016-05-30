using UnityEngine;
using System.Collections;

public class GroundScript : MonoBehaviour {

	public Transform prefab;

	private Color green = Color.green;
	private Color white = Color.white;

	private Object obj;

	private Vector2 pos;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Awake() {
		sprite = GetComponentInChildren<SpriteRenderer>();
	}

	void Start(){
		pos = transform.position;
		sprite.color = white;
		//sprite.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		if(obj){
			sprite.enabled = false; //turret is already placed
		}

		if(obj == null){
			sprite.enabled = true; //turret can be placed
		}
	}

	void OnMouseOver(){
		if(sprite.enabled){
			sprite.color = green; //change color to show that a turret can be placed
		}

		if(Input.GetMouseButtonDown(0) && obj == null){
			LookAtEnemyPath(); //Causes the actual tile itself to rotate, making instantiation more simple
			obj = Instantiate(prefab, transform.position, transform.rotation);
		}
	}

	void OnMouseExit(){
		if(sprite.enabled){
			sprite.color = white; //change color back
		}
	}

	private void ShowSelectionUI(){
		//currently unused
		//This enables the gameobject with the turrest selection circle
	}

	private void LookAtEnemyPath(){
		//Look in a clockwise direction around the turret for the nearest movementNode
		// then point the tile at the node and instantiate the turret with the 
		// tile's rotation
		RaycastHit2D hitLeft = Physics2D.Linecast(pos, 
		                                          new Vector2(pos.x - 1, pos.y), 
		                                          1 << LayerMask.NameToLayer("MovementLayer"));
		RaycastHit2D hitUp = Physics2D.Linecast(pos, 
		                                        new Vector2(pos.x, pos.y + 1), 
		                                        1 << LayerMask.NameToLayer("MovementLayer"));
		RaycastHit2D hitRight = Physics2D.Linecast(pos, 
		                                           new Vector2(pos.x + 1, pos.y), 
		                                           1 << LayerMask.NameToLayer("MovementLayer"));
		RaycastHit2D hitDown = Physics2D.Linecast(pos, 
		                                          new Vector2(pos.x, pos.y - 1), 
		                                          1 << LayerMask.NameToLayer("MovementLayer"));

		if(hitLeft.collider != null){
			transform.rotation = Quaternion.AngleAxis(90f, Vector3.forward);
		}
		else if(hitUp.collider != null){
			return;
		}
		else if(hitRight.collider != null){
			transform.rotation = Quaternion.AngleAxis(-90f, Vector3.forward);
		}
		else if(hitDown.collider != null){
			transform.rotation = Quaternion.AngleAxis(180f, Vector3.forward);
		}
	}
}
