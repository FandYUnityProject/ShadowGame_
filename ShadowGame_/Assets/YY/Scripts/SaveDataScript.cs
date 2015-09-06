using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveDataScript : MonoBehaviour {

	public bool isUseDebug  = false;
	public bool isAllCrear  = false;
	public bool isAllDelete = false;

	public static GameObject[] StageSelectArray = new GameObject[31];
	
	// Use this for initialization
	void Start () {

		// 解禁されたステージオブジェクトを保存する
		for( int i=1; i<=30; i++ ){
			if( i>=1 && i<=9 ){
				StageSelectArray[i] = GameObject.Find("StageSelect0" + i);
			} else {
				StageSelectArray[i] = GameObject.Find("StageSelect" + i);
			}
		}
		
		// 【デバッグ用】仮セーブ
		if (isUseDebug) {
			if ( isAllCrear ){
				for (int i=1; i<=30; i++) {
					if (i >= 1 && i <= 9) { 
						PlayerPrefs.SetInt ("Stage0" + i + "UnLock", 1);
						PlayerPrefs.SetInt ("Stage0" + i + "ThreeStarsClear", 1);
						PlayerPrefs.SetInt ("Stage0" + i + "TwoStarsClear", 1);
						PlayerPrefs.SetInt ("Stage0" + i + "OneStarClear", 1);
					} else {
						PlayerPrefs.SetInt ("Stage" + i + "UnLock", 1);
						PlayerPrefs.SetInt ("Stage" + i + "ThreeStarsClear", 1);
						PlayerPrefs.SetInt ("Stage" + i + "TwoStarsClear", 1);
						PlayerPrefs.SetInt ("Stage" + i + "OneStarClear", 1);
					}
				}

				PlayerPrefs.SetString ("Stars", "90");
			}
			if ( isAllDelete ){
				for (int i=1; i<=30; i++) {
					if (i >= 1 && i <= 9) { 
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

				PlayerPrefs.SetString ("Stars", "10");
			}
		}


		// typeで指定した型の全てのオブジェクトを配列で取得し,その要素数分繰り返す.
		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))){
			// シーン上に存在するオブジェクトならば処理
			if (obj.activeInHierarchy){
				for (int i=1; i<=30; i++) {
					if( i >= 1 && i <= 9 ){ 

						// ステージ解禁の有無によって表示非表示を変更
						if(PlayerPrefs.GetInt ("Stage0" + i + "UnLock") == 1){
							if(obj.name == "StageLock0" + i ){
								Destroy(obj);
							}
							if(obj.name == "StageSelect0" + i ){
								obj.SetActiveRecursively(true);
							}
						} else {
							if(obj.name == "StageLock0" + i ){
								obj.SetActiveRecursively(true);
							}
							if(obj.name == "StageSelect0" + i ){
								obj.SetActiveRecursively(false);
							}
						}

						// 目標タイム達成によって表示を変更
						if(PlayerPrefs.GetInt ("Stage0" + i + "ThreeStarsClear") == 1){
							if(obj.name == "Stage0" + i + "ThreeStarsTime" ){
								obj.GetComponent<Text>().text = "CLEAR!";
								obj.GetComponent<Text>().fontSize = 22;
							}
						}
						if(PlayerPrefs.GetInt ("Stage0" + i + "TwoStarsClear") == 1){
							if(obj.name == "Stage0" + i + "TwoStarsTime" ){
								obj.GetComponent<Text>().text = "CLEAR!";
								obj.GetComponent<Text>().fontSize = 22;
							}
						}
						if(PlayerPrefs.GetInt ("Stage0" + i + "OneStarClear") == 1){
							if(obj.name == "Stage0" + i + "OneStarTime" ){
								obj.GetComponent<Text>().text = "CLEAR!";
								obj.GetComponent<Text>().fontSize = 22;
							}
						}

					} else{

						// ステージ解禁の有無によって表示非表示を変更
						if(PlayerPrefs.GetInt ("Stage" + i + "UnLock") == 1){
							if(obj.name == "StageLock" + i ){
								Destroy(obj);
							}
							if(obj.name == "StageSelect" + i ){
								obj.SetActiveRecursively(true);
							}
						} else {
							if(obj.name == "StageLock" + i ){
								obj.SetActiveRecursively(true);
							}
							if(obj.name == "StageSelect" + i ){
								obj.SetActiveRecursively(false);
							}
						}
						
						// 目標タイム達成によって表示を変更
						if(PlayerPrefs.GetInt ("Stage" + i + "ThreeStarsClear") == 1){
							if(obj.name == "Stage" + i + "ThreeStarsTime" ){
								obj.GetComponent<Text>().text = "CLEAR!";
								obj.GetComponent<Text>().fontSize = 22;
							}
						}
						if(PlayerPrefs.GetInt ("Stage" + i + "TwoStarsClear") == 1){
							if(obj.name == "Stage" + i + "TwoStarsTime" ){
								obj.GetComponent<Text>().text = "CLEAR!";
								obj.GetComponent<Text>().fontSize = 22;
							}
						}
						if(PlayerPrefs.GetInt ("Stage" + i + "OneStarClear") == 1){
							if(obj.name == "Stage" + i + "OneStarTime" ){
								obj.GetComponent<Text>().text = "CLEAR!";
								obj.GetComponent<Text>().fontSize = 22;
							}
						}

					}
				}

				// ゲットした星の数
				if(obj.name == "StarCount" ){
					obj.GetComponent<Text>().text = PlayerPrefs.GetString ("Stars");
				}
			}
		}
	}
}