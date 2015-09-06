using UnityEngine;
using System.Collections;

public class ClearBody : MonoBehaviour {

	RaycastHit hit;
	float distanceToWall = 0;
	public float rayLength = 3f;
	Color sColor;
	Renderer pR;

	void Start(){
		pR = GetComponent<Renderer>();
		sColor = pR.material.color;
	}

	void Update(){
		if (Physics.Raycast (transform.position, -transform.forward, out hit, rayLength)) {
			distanceToWall = hit.distance/rayLength;
			pR.material.color = new Color (1,1,1,distanceToWall) * sColor;
		}
	}
}
