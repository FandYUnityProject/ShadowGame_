using UnityEngine;
using System.Collections;

public class PlayerStartPosition : MonoBehaviour {
	
	private GameObject startObj;

	// Use this for initialization
	void Start () {
	
		startObj  = GameObject.Find ("StartObj");
		this.gameObject.transform.position = new Vector3 (startObj.transform.position.x, startObj.transform.position.y, startObj.transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
