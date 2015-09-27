using UnityEngine;
using System.Collections;

public class ReturnStage : MonoBehaviour {
	
	public AudioClip SelectSound;

	public void OnClick() {
		
		GetComponent<AudioSource>().PlayOneShot(SelectSound);
		Application.LoadLevel ("StageSelect");
	}

	void Update(){
		if(Input.GetButtonDown("Cancel")){
			
			GetComponent<AudioSource>().PlayOneShot(SelectSound);
			Application.LoadLevel ("StageSelect");
		}
	}
}
