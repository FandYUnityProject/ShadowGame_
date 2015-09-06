using UnityEngine;
using System.Collections;

public class BoundCamera : MonoBehaviour {

	GameObject player;
	public GameObject sCam;
	Vector3 sPosition;
	public float smooth = 10;
	public bool isTouch = false;
	Color sPColor;
	Vector3 target;
	public float targetY;

	void Start(){
		player = GameObject.Find ("face");
		sPColor = player.GetComponent<Renderer> ().material.color;

	}

	void Update(){
		CameraMove ();
		target = player.transform.position + new Vector3 (0f, targetY, 0f);
		transform.LookAt (target);
	}

	void CameraMove(){
		if (isTouch) {
			//ClearBody.Clearing(player);
			transform.position = Vector3.Lerp (transform.position, sCam.transform.position + sCam.transform.forward - sCam.transform.up, Time.deltaTime * smooth);
		} else {
			player.GetComponent<Renderer>().material.color = sPColor;
			transform.position = Vector3.Lerp (transform.position, sCam.transform.position, Time.deltaTime);
		}
	}

	void OnTriggerStay(Collider coll){
		isTouch = true;
	}

	void OnTriggerExit(Collider coll){
		isTouch = false;
	}
}
