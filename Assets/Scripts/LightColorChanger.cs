using UnityEngine;
using System.Collections;

public class LightColorChanger : MonoBehaviour {

	Renderer rend;
	Color sColor;
	public Color nColor;
	public static bool inCircle = false;

	public float hotSpeed=1f;
	public float coolSpeed=1f;

	void Start(){
		rend = GetComponent<Renderer> ();
		sColor = rend.material.color;
	}

	void Update(){
		if (inCircle) {
			rend.material.color = Color.Lerp ( rend.material.color, nColor,Time.deltaTime*hotSpeed);
			if(rend.material.color == nColor){
				Debug.Log("Bang!!!");
			}
		} else {
			rend.material.color = Color.Lerp ( rend.material.color, sColor,Time.deltaTime*coolSpeed);
		}
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.tag == "Body") {
			inCircle = true;
			Debug.Log(inCircle);
		}
		if (coll.gameObject.tag == "Cube") {
			Debug.Log("IN");
		}
	}

	void OnTriggerStay(Collider coll){
		if (coll.gameObject.tag == "Body") {
			//  ランプが付いているか付いていないかでライトに当たってるか当たっていないかを判定
			if( InvalidLamp.isInvalidLamp ){
				inCircle = false;
			} else {
				inCircle = true;
			}
		}
		if (coll.gameObject.tag == "Cube") {
			Debug.Log("STAY");
		}
	}

	void OnTriggerExit(Collider coll){
		if (coll.gameObject.tag == "Body") {
			inCircle = false;
			Debug.Log(inCircle);
		}
		if (coll.gameObject.tag == "Cube") {
			Debug.Log("OUT");
		}
	}
}
