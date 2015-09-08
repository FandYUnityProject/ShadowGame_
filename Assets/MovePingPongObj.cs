using UnityEngine;
using System.Collections;

public class MovePingPongObj : MonoBehaviour {

	
	public float moveDistance = 40.0f;
	public float moveSpeed    =  4.0f;
	float startDistance = 0.0f;

	void Start(){
		startDistance = moveDistance;
	}
	
	// Update is called once per frame
	void Update () {

		if (startDistance >= 0) {
			transform.position = new Vector3 (Mathf.PingPong (Time.time * moveSpeed, moveDistance) - (moveDistance / 2), transform.position.y, transform.position.z);
		} else {
			transform.position = new Vector3 (Mathf.PingPong (Time.time * moveSpeed, moveDistance) + (-moveDistance * 2), transform.position.y, transform.position.z);
		}
	}
}
