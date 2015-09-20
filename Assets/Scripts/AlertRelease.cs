using UnityEngine;
using System.Collections;

public class AlertRelease : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll){

		if (coll.gameObject.name == "Player") {

			if( AlertScreen.isAlertScreen ) {
				AlertScreen.isAlertScreen = false;
				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateWall" ){
							iTween.MoveBy(obj, iTween.Hash("y", 12.5, "easeType", "easeInOutExpo", "time", .5));
						}
					}
				}
			}
		}
	}
}
