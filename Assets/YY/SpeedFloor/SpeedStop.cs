using UnityEngine;
using System.Collections;

public class SpeedStop : MonoBehaviour {

	void OnCollisionEnter (Collision coll){
		if (coll.gameObject.name == "Wall") {
			Debug.Log("Wall");
			this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}
	void OnTriggerEnter (Collider coll){
		if (coll.gameObject.name == "StopArea") {
			Debug.Log("StopArea");
			this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}

	void OnCollisionExit (Collision coll){
		if (coll.gameObject.name == "Wall") {
			Debug.Log("Wall");
			this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		}
	}
	void OnTriggerExit (Collider coll){
		if (coll.gameObject.name == "StopArea") {
			Debug.Log("StopArea");
			this.gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
			//Destroy(coll);
		}
	}
}
