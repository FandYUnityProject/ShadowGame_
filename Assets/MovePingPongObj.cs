using UnityEngine;
using System.Collections;

public class MovePingPongObj : MonoBehaviour {
	
	public float moveSpeed    =  4.0f;
	float startDistance = 0.0f;

	
	public float moveDistance_X = 40.0f;
	public float moveDistance_Y =  0.0f;
	public float moveDistance_Z =  0.0f;
	
	private float startPosition_X;
	private float startPosition_Y;
	private float startPosition_Z;

	void Start(){
		if (moveDistance_X == 0) { moveDistance_X = 0.0000001f;}
		if (moveDistance_Y == 0) { moveDistance_Y = 0.0000001f;}
		if (moveDistance_Z == 0) { moveDistance_Z = 0.0000001f;}
		
		startPosition_X = transform.position.x;
		startPosition_Y = transform.position.y;
		startPosition_Z = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (startPosition_X + Mathf.PingPong (Time.time * moveSpeed, moveDistance_X) - (moveDistance_X / 2.0f)
		                                , startPosition_Y + Mathf.PingPong (Time.time * moveSpeed, moveDistance_Y) - (moveDistance_Y / 2.0f)
		                                , startPosition_Z + Mathf.PingPong (Time.time * moveSpeed, moveDistance_Z) - (moveDistance_Z / 2.0f));

	}
}
