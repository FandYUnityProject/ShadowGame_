using UnityEngine;
using System.Collections;

public class BoundCamera : MonoBehaviour {

	GameObject player;
	public GameObject sCam;
	Vector3 sPosition;
	public float insmooth = 10;
	public float outsmooth = 10;
	public bool isTouch = false;
	Vector3 target;
	public float targetY;

	void Start(){
		player = GameObject.Find ("face");
	}

	void Update(){
		CameraMove ();
		target = player.transform.position + new Vector3 (0f, targetY, 0f);
		transform.LookAt (target);
	}

	void CameraMove(){
		if (isTouch) {
			transform.position = Vector3.Lerp (transform.position, 
			                                   sCam.transform.position + sCam.transform.forward + sCam.transform.forward + sCam.transform.forward - sCam.transform.up - sCam.transform.up,
			                                   Time.deltaTime * insmooth);
		} else {
			transform.position = Vector3.Lerp (transform.position, 
			                                   sCam.transform.position, 
			                                   Time.deltaTime*outsmooth);
		}
	}

	void OnTriggerStay(Collider coll){
		isTouch = true;
	}

	void OnTriggerExit(Collider coll){
		isTouch = false;
	}
}
