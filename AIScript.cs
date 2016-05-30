using UnityEngine;
using System.Collections;

public class AIScript : MonoBehaviour {

	// The current pathfinding method only allows for one path with one set of enemies.
	// In order to have multiple paths you will need to create a nodeArray2 tag and a second
	// set of enemies that only use that tag will have to be created.

	public float moveSpeed = 2f;
	public float health = 12f;
	public float maxHealth = 12f;

	private bool flashing = false;
	private float flashTime = 0.5f;
	private float timer = 0f;
	private float flashIntervalTime = 0.1f;
	private float flashIntervalTimer = 0f;

	private SpriteRenderer sprite;

	private int nodeInt = 0; //Variable of the node to head towards
	private Vector3 nextNode;

	private GameObject nodes;
	private NodeArrayScript nodeScript;
	private Transform[] nodeArray;

	void Start(){
		//have a reference to the sprite to flash it on damage
		sprite = gameObject.GetComponent<SpriteRenderer>();

		//This section Is a shorter version of A* code. Instead of having every enemy
		// search through every tile to find the path, the enemies will search for the
		// next node in a predetermined list, and then move towards it. The enemies
		// will automatically destroy themselves upon reaching the last node.
		nodes = GameObject.FindGameObjectWithTag("NodeArray"); // Create a reference for the nodes list
		nodeScript = nodes.GetComponent<NodeArrayScript>(); // Find the script attached to the nodes
		nodeArray = new Transform[nodeScript.nodesList.Length]; // create a list to store info
		for(int i = 0; i < nodeScript.nodesList.Length; i++){
			nodeArray[i] = nodeScript.nodesList[i]; // transfer over the node info
		}

		nextNode = nodeArray[nodeInt].position; // set up the first nextNode
	}

	void Update(){
		if(transform.position == nextNode && nodeInt < nodeArray.Length){
			nextNode = nodeArray[nodeInt].position; // Moves the next node forward
			nodeInt++;
		}
		else if(transform.position == nextNode){
			Destroy(gameObject); // Destroys the gameObject if there are no more nodes in the list to go to
		}

		if(flashing){
			Flash(); //Pretty straightforward, I'd say
		}

		if(health <= 0){
			Destroy(gameObject);
		}

		transform.position = Vector3.MoveTowards(transform.position, nextNode, moveSpeed * Time.deltaTime);
	}

	void OnMouseOver(){
		if(Input.GetMouseButtonDown(0)){
			Destroy(gameObject); //destroy enemy if clicked on
		}
	}

	public void Hit(float damage){
		flashing = true;
		health -= damage;
		BroadcastMessage ("AdjustHealth", damage); //Tells AiHeathScript to lower enemy health
	}

	private void Flash(){ //Flash enemy every flashIntervalTimer
		if(timer < flashTime){
			if(flashIntervalTimer > flashIntervalTime){
				sprite.enabled = !sprite.enabled;
				flashIntervalTimer = 0f;
			}
			else{
				flashIntervalTimer += Time.deltaTime;
			}

			timer += Time.deltaTime;
		}
		else if(timer > flashTime){
			sprite.enabled = true;
			flashing = false;
			timer = 0f;
			flashIntervalTimer = 0f;
		}
	}
}
