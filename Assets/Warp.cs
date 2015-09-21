using UnityEngine;
using System.Collections;

public class Warp : MonoBehaviour {

	public GameObject toPoint;
	public GameObject player;

	void Start(){

	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Body") {
			coll.gameObject.transform.position = toPoint.transform.position;
		}
	}
}
