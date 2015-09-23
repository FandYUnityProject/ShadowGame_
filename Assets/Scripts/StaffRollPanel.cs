using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StaffRollPanel : MonoBehaviour {

	public GameObject StaffRollPanelObj;
	
	public Sprite StaffRollPanelImage;

	// Use this for initialization
	void Start () {
	
		StaffRollPanelObj.SetActiveRecursively (false);
	}

	void OnTriggerStay(Collider coll){

		if (coll.gameObject.name == "Player") {
			StaffRollPanelObj.SetActiveRecursively (true);

			StaffRollPanelObj.GetComponent<Image>().sprite = StaffRollPanelImage;
		}
	}

	void OnTriggerExit(Collider coll){
		
		if (coll.gameObject.name == "Player") {
			StaffRollPanelObj.SetActiveRecursively (false);
		}
	}
}
