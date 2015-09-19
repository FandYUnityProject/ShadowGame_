using UnityEngine;
using System.Collections;

public class ClearBody : MonoBehaviour {

	RaycastHit hit;
	float distanceToWall = 0;
	public float rayLength = 3f;
	Color sColor;
	Renderer pR;

	public Shader shader1;
	public Shader shader2;
	
	void Start(){
		pR = GetComponent<Renderer>();
		sColor = pR.material.color;

		shader1 = Shader.Find("Transparent/Diffuse");
		shader2 = Shader.Find("Standard");

	}

	void Update(){
		if (Physics.Raycast (transform.position, -transform.forward, out hit, rayLength)) {
			if(hit.collider.tag=="Light" || hit.collider.tag=="MainCamera"){
			}else{
				distanceToWall = hit.distance / rayLength;
				pR.material.color = new Color (1, 1, 1, 0.2f/*distanceToWall*/) * sColor;
				pR.material.shader = shader1;
			}
		} else {
			pR.material.shader = shader2;
		}
	}
}
