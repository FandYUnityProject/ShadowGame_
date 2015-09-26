using UnityEngine;
using System.Collections;

public class ReturnStage : MonoBehaviour {

	void Start(){
	
	}

	public void OnClick() {
		Application.LoadLevel ("StageSelect");
	}

	void Update(){
		if(Input.GetButtonDown("Cancel")){
			Application.LoadLevel ("StageSelect");
		}
	}
}
