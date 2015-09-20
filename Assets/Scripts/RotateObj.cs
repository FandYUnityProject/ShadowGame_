using UnityEngine;
using System.Collections;

public class RotateObj : MonoBehaviour {

	public  float rotateSpeed = 2.0f;
	private float nowRotate   = 0.0f; 

	// Use this for initialization
	void Update () {

		nowRotate += rotateSpeed;
		if (nowRotate > 360 || nowRotate < -360) {	nowRotate = 0.0f; }
		this.transform.rotation = Quaternion.Euler(transform.rotation.x, nowRotate, transform.rotation.z);
	}
}
