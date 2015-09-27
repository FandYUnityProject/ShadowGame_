using UnityEngine;
using System.Collections;

public class SaveDataDelete : MonoBehaviour {
		
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.D)) {
			for (int i=1; i<=30; i++) {
				if (i >= 1 && i <= 5) { 
					PlayerPrefs.SetInt ("Stage0" + i + "UnLock", 1);
					PlayerPrefs.SetInt ("Stage0" + i + "ThreeStarsClear", 0);
					PlayerPrefs.SetInt ("Stage0" + i + "TwoStarsClear", 0);
					PlayerPrefs.SetInt ("Stage0" + i + "OneStarClear", 0);
				}else if (i >= 6 && i <= 9) { 
					PlayerPrefs.SetInt ("Stage0" + i + "UnLock", 0);
					PlayerPrefs.SetInt ("Stage0" + i + "ThreeStarsClear", 0);
					PlayerPrefs.SetInt ("Stage0" + i + "TwoStarsClear", 0);
					PlayerPrefs.SetInt ("Stage0" + i + "OneStarClear", 0);
				} else {
					PlayerPrefs.SetInt ("Stage" + i + "UnLock", 0);
					PlayerPrefs.SetInt ("Stage" + i + "ThreeStarsClear", 0);
					PlayerPrefs.SetInt ("Stage" + i + "TwoStarsClear", 0);
					PlayerPrefs.SetInt ("Stage" + i + "OneStarClear", 0);
				}
			}
			
			PlayerPrefs.SetString ("Stars", "0");
		}
	}
}
