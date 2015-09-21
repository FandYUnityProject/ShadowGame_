using UnityEngine;
using System.Collections;

public class KeyAndBox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll){

		if (coll.gameObject.name == "Player") {

			if(this.gameObject.name == "GreenKey"){
				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateBoxGreen" ){
							Destroy(obj);
						}
						Destroy(this.gameObject);
					}
				}
			}

			if(this.gameObject.name == "BlueKey"){
				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateBoxBlue" ){
							Destroy(obj);
						}
						Destroy(this.gameObject);
					}
				}
			}

			if(this.gameObject.name == "YellowKey"){
				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateBoxYellow" ){
							Destroy(obj);
						}
						Destroy(this.gameObject);
					}
				}
			}

		}
	}
}
