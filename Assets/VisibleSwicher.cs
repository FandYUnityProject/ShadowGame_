using UnityEngine;
using System.Collections;

public class VisibleSwicher : MonoBehaviour {

	Renderer rend;

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Cube") {
			rend = coll.gameObject.GetComponent<Renderer> ();
			rend.enabled = false;
		}
	}
	
	void OnTriggerStay(Collider coll){
		if (coll.gameObject.tag == "Cube") {
			rend = coll.gameObject.GetComponent<Renderer> ();
			rend.enabled = false;
		}
	}
	
	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Cube") {
			rend = coll.gameObject.GetComponent<Renderer> ();
			rend.enabled = true;
		}
	}
}
