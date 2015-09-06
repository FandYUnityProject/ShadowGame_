using UnityEngine;
using System.Collections;

public class LightGardWallMove : MonoBehaviour {

	public float moveDistance = 9.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time, moveDistance));
	}
}
