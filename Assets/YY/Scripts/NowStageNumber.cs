using UnityEngine;
using System.Collections;

public class NowStageNumber : MonoBehaviour {

	private static bool isSaveControllObject = false;

	public static int StageNumber = 1;
	
	// saveContoroll(Object)が重複作成されるのを防ぐ
	void Awake (){
		if (!isSaveControllObject) {
			
			// シーン遷移しても削除させない
			DontDestroyOnLoad (this);
			isSaveControllObject = true;
		} else {
			
			Destroy(this.gameObject);
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
