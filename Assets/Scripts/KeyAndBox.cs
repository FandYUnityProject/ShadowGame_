using UnityEngine;
using System.Collections;

public class KeyAndBox : MonoBehaviour {

	public AudioClip GetItemSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator GetKeys() {

		GetComponent<AudioSource>().PlayOneShot(GetItemSound);
		yield return new WaitForSeconds (0.4f);
		Destroy(this.gameObject);
	}

	void OnTriggerEnter(Collider coll){

		if (coll.gameObject.name == "Player") {

			StartCoroutine("GetKeys");

			if(this.gameObject.name == "GreenKey"){
				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateBoxGreen" ){
							Destroy(obj);
						}
					}
				}
			}

			if(this.gameObject.name == "BlueKey"){

				StartCoroutine("GetKeys");

				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateBoxBlue" ){
							Destroy(obj);
						}
					}
				}
			}

			if(this.gameObject.name == "YellowKey"){
				
				StartCoroutine("GetKeys");

				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateBoxYellow" ){
							Destroy(obj);
						}
					}
				}
			}

		}
	}
}
