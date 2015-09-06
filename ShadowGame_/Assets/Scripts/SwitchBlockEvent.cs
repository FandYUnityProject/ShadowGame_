using UnityEngine;
using System.Collections;

public class SwitchBlockEvent : MonoBehaviour {

	private GameObject[] objects;

	// Use this for initialization
	void Start () {
		
		//FindGameObjectsWithTagメソッド指定のタグのインスタンスを配列で取得
		objects = GameObject.FindGameObjectsWithTag("LightPointSwitchWall");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll){

		Debug.Log ("OK");

		if (coll.gameObject.name == "Player") {

			Debug.Log("OKOK");

			//配列内のオブジェクトの数だけループ
			foreach (GameObject destroyObj in objects) {
				//オブジェクトを削除
				Destroy(destroyObj);
			}
		}
	}
}
