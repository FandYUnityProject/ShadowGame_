using UnityEngine;
using System.Collections;

public class SpringAddForce : MonoBehaviour {

	public float springPower = 5.0f;
	public AudioClip BoundSound;

	private GameObject playerObj;

	void Start(){
		playerObj = GameObject.Find ("Player");
	}

	void OnTriggerEnter(Collider coll){

		if (coll.gameObject.name == "Player") {
			Debug.Log("Spring!");
			GetComponent<AudioSource>().PlayOneShot(BoundSound);
			playerObj.GetComponent<Rigidbody>().velocity = new Vector3(playerObj.GetComponent<Rigidbody>().velocity.x, 0 ,playerObj.GetComponent<Rigidbody>().velocity.z);
			playerObj.GetComponent<Rigidbody> ().AddForce (transform.up * springPower);
		}
	}
}
