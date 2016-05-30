using UnityEngine;
using System.Collections;

public class NodeArrayScript : MonoBehaviour {

	//NodeArrayScript is put on a stand-alone prefab which allows the user to change
	// the size of the list of nodes. The user can then drag and drop the nodes into
	// the list in the order that they would like the enemies to move to.
	//Nothing further needs to be done in the inspector for the enemy prefabs, 
	// as their code grabs this on it's own.

	public Transform[] nodesList = new Transform[0];
}
