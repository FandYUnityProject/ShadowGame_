using UnityEngine;
using System.Collections;

public class ReturnStage : MonoBehaviour {

	void Start(){
	
	}

	public void OnClick() {
		Application.LoadLevel ("StageSelect");
	}
}
