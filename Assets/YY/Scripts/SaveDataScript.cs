using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SaveDataScript : MonoBehaviour
{

	public bool isUseDebug = false;
	public bool isAllCrear = false;
	public bool isAllDelete = false;

	// 目標タイムリスト
	public static string[] ThreeStarsTime = 
		new string[] {null, "00:10", "00:50", "00:40", "00:50", "00:50", "00:25", "02:20", "00:45", "00:00"
						  , "01:10", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00"
					      , "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", null
	};
	public static string[] TwoStarsTime = 
		new string[] {null, "00:25", "01:30", "01:20", "02:00", "01:30", "00:40", "03:30", "01:30", "00:00"
						  , "03:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00"
						  , "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", null
	};
	public static string[] OneStarTime = 
		new string[] {null, "60:00", "02:30", "02:00", "04:30", "03:30", "01:00", "05:00", "02:20", "00:00"
						  , "10:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00"
						  , "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "00:00", "88:59", "99:59", null
	};
	public static GameObject[] StageSelectArray = new GameObject[31];
	
	// Use this for initialization
	void Start ()
	{

		// 解禁されたステージオブジェクトを保存する
		for (int i=1; i<=30; i++) {
			if (i >= 1 && i <= 9) {
				StageSelectArray [i] = GameObject.Find ("StageSelect0" + i);
			} else {
				StageSelectArray [i] = GameObject.Find ("StageSelect" + i);
			}
		}
		
		// 【デバッグ用】仮セーブ
		if (isUseDebug) {
			if (isAllCrear) {
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
			if (isAllDelete) {
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
		} else {
			for (int i=1; i<=5; i++){
				// 最初の5面は最初から解禁
				PlayerPrefs.SetInt ("Stage0" + i + "UnLock", 1);
			}
		}



		// typeで指定した型の全てのオブジェクトを配列で取得し,その要素数分繰り返す.
		foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject))) {
			// シーン上に存在するオブジェクトならば処理
			//if (obj.activeInHierarchy){
			for (int i=1; i<=30; i++) {
				if (i >= 1 && i <= 9) { 

					// 目標タイム達成によって表示を変更
					if (obj.name == "Stage0" + i + "OneStarTime") {
						obj.GetComponent<Text> ().text = OneStarTime [i];
						obj.GetComponent<Text> ().fontSize = 22;
					}
					if (obj.name == "Stage0" + i + "TwoStarsTime") {
						obj.GetComponent<Text> ().text = TwoStarsTime [i];
						obj.GetComponent<Text> ().fontSize = 22;
					}
					if (obj.name == "Stage0" + i + "ThreeStarsTime") {
						obj.GetComponent<Text> ().text = ThreeStarsTime [i];
						obj.GetComponent<Text> ().fontSize = 22;
					}

					if (PlayerPrefs.GetInt ("Stage0" + i + "OneStarClear") == 1) {
						if (obj.name == "Stage0" + i + "OneStarTime") {
							obj.GetComponent<Text> ().text = "CLEAR!";
							obj.GetComponent<Text> ().fontSize = 22;
						}
						if (PlayerPrefs.GetInt ("Stage0" + i + "TwoStarsClear") == 1) {
							if (obj.name == "Stage0" + i + "TwoStarsTime") {
								obj.GetComponent<Text> ().text = "CLEAR!";
								obj.GetComponent<Text> ().fontSize = 22;
							}
							if (PlayerPrefs.GetInt ("Stage0" + i + "ThreeStarsClear") == 1) {
								if (obj.name == "Stage0" + i + "ThreeStarsTime") {
									obj.GetComponent<Text> ().text = "CLEAR!";
									obj.GetComponent<Text> ().fontSize = 22;
								}
							} else {
								if (obj.name == "Stage0" + i + "ThreeStarsTime" && PlayerPrefs.GetInt ("Stage0" + i + "TwoStarsClear") == 0) {
									obj.GetComponent<Text> ().text = "??:??";
									obj.GetComponent<Text> ().fontSize = 22;
								}
							}
						} else {
							if (obj.name == "Stage0" + i + "TwoStarsTime" && PlayerPrefs.GetInt ("Stage0" + i + "OneStarClear") == 0) {
								obj.GetComponent<Text> ().text = "??:??";
								obj.GetComponent<Text> ().fontSize = 22;
							}
							if (obj.name == "Stage0" + i + "ThreeStarsTime") {
								obj.GetComponent<Text> ().text = "??:??";
								obj.GetComponent<Text> ().fontSize = 22;
							}
						}
					} else {
						if (obj.name == "Stage0" + i + "TwoStarsTime") {
							obj.GetComponent<Text> ().text = "??:??";
							obj.GetComponent<Text> ().fontSize = 22;
						}
						if (obj.name == "Stage0" + i + "ThreeStarsTime") {
							obj.GetComponent<Text> ().text = "??:??";
							obj.GetComponent<Text> ().fontSize = 22;
						}
					}

					// ステージ解禁の有無によって表示非表示を変更
					if (PlayerPrefs.GetInt ("Stage0" + i + "UnLock") == 1) {
						if (obj.name == "StageLock0" + i) {
							Destroy (obj);
						}
						if (obj.name == "StageSelect0" + i) {
							obj.SetActiveRecursively (true);
						}
					} else {
						if (obj.name == "StageLock0" + i) {
							obj.SetActiveRecursively (true);
						}
						if (obj.name == "StageSelect0" + i) {
							obj.SetActiveRecursively (false);
						}
					}


				} else if (i >= 10 && i <= 30) {

					// 目標タイム達成によって表示を変更
					if (obj.name == "Stage" + i + "OneStarTime") {
						obj.GetComponent<Text> ().text = OneStarTime [i];
						obj.GetComponent<Text> ().fontSize = 22;
					}
					if (obj.name == "Stage" + i + "TwoStarsTime") {
						obj.GetComponent<Text> ().text = TwoStarsTime [i];
						obj.GetComponent<Text> ().fontSize = 22;
					}
					if (obj.name == "Stage" + i + "ThreeStarsTime") {
						obj.GetComponent<Text> ().text = ThreeStarsTime [i];
						obj.GetComponent<Text> ().fontSize = 22;
					}
						
					if (PlayerPrefs.GetInt ("Stage" + i + "OneStarClear") == 1) {
						if (obj.name == "Stage" + i + "OneStarTime") {
							obj.GetComponent<Text> ().text = "CLEAR!";
							obj.GetComponent<Text> ().fontSize = 22;
						}
						if (PlayerPrefs.GetInt ("Stage" + i + "TwoStarsClear") == 1) {
							if (obj.name == "Stage" + i + "TwoStarsTime") {
								obj.GetComponent<Text> ().text = "CLEAR!";
								obj.GetComponent<Text> ().fontSize = 22;
							}
							if (PlayerPrefs.GetInt ("Stage" + i + "ThreeStarsClear") == 1) {
								if (obj.name == "Stage" + i + "ThreeStarsTime") {
									obj.GetComponent<Text> ().text = "CLEAR!";
									obj.GetComponent<Text> ().fontSize = 22;
								}
							} else {
								if (obj.name == "Stage" + i + "ThreeStarsTime" && PlayerPrefs.GetInt ("Stage0" + i + "TwoStarsClear") == 0) {
									obj.GetComponent<Text> ().text = "??:??";
									obj.GetComponent<Text> ().fontSize = 22;
								}
							}
						} else {
							if (obj.name == "Stage" + i + "TwoStarsTime" && PlayerPrefs.GetInt ("Stage0" + i + "OneStarClear") == 0) {
								obj.GetComponent<Text> ().text = "??:??";
								obj.GetComponent<Text> ().fontSize = 22;
							}
							if (obj.name == "Stage" + i + "ThreeStarsTime") {
								obj.GetComponent<Text> ().text = "??:??";
								obj.GetComponent<Text> ().fontSize = 22;
							}
						}
					} else {
						if (obj.name == "Stage" + i + "TwoStarsTime") {
							obj.GetComponent<Text> ().text = "??:??";
							obj.GetComponent<Text> ().fontSize = 22;
						}
						if (obj.name == "Stage" + i + "ThreeStarsTime") {
							obj.GetComponent<Text> ().text = "??:??";
							obj.GetComponent<Text> ().fontSize = 22;
						}
					}

					// ステージ解禁の有無によって表示非表示を変更
					if (PlayerPrefs.GetInt ("Stage" + i + "UnLock") == 1) {
						if (obj.name == "StageLock" + i) {
							Destroy (obj);
						}
						if (obj.name == "StageSelect" + i) {
							obj.SetActiveRecursively (true);
						}
					} else {
						if (obj.name == "StageLock" + i) {
							obj.SetActiveRecursively (true);
						}
						if (obj.name == "StageSelect" + i) {
							obj.SetActiveRecursively (false);
						}
					}
				}
			}

			// ゲットした星の数
			if (obj.name == "StarCount") {
				obj.GetComponent<Text> ().text = PlayerPrefs.GetString ("Stars");
			}
			//}
		}
	}
}