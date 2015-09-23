using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessagePanel : MonoBehaviour {

	private GameObject MessagePanelObj;

	// Use this for initialization
	void Start () {
	
		MessagePanelObj = GameObject.Find ("MessagePanel");
		MessagePanelObj.SetActiveRecursively (false);
	}

	void OnTriggerStay(Collider coll){

		if (coll.gameObject.name == "Player") {
			MessagePanelObj.SetActiveRecursively (true);
		}
	}

	void OnTriggerExit(Collider coll){
		
		if (coll.gameObject.name == "Player") {
			MessagePanelObj.SetActiveRecursively (false);
		}
	}
}
