using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LockStageSelect : MonoBehaviour {

	public  string stageName;
	public  int    stageNeedUnlockStar = 0;

	public GameObject unlockMenu;
	public GameObject returnUnlockMenu;
	public GameObject unlockText;
	public GameObject returnUnlockText;
	private GameObject StarImage;
	
	public AudioClip SelectSound;

	// Use this for initialization
	void Start () {
		StarImage = GameObject.Find ("StarImage");
	}
	
	// ボタンをクリックした時の処理
	public void OnClick() {
		
		GetComponent<AudioSource>().PlayOneShot(SelectSound);

		if (!Input.GetButtonDown ("Submit")) { 
			// 解禁するステージ名、必要な星の数を代入。
			DoUnlock.stageObjName = stageName;
			DoUnlock.stageObjUnlockStar = stageNeedUnlockStar;

			// ステージ解禁に必要な星の数が、現在の星の所持数より少ないかチェック
			/*
			if (stageNeedUnlockStar <= int.Parse (PlayerPrefs.GetString ("Stars"))) {

				// 必要数以上に星を持っていた場合
				Debug.Log ("UnlockScreen");
				iTween.ScaleTo (unlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
				unlockText.GetComponent<Text> ().text = "このステージで遊ぶには 　 が" + stageNeedUnlockStar + "つ必要です。";
			} else {

				// 必要数以上に星を持っていなかった場合
				Debug.Log ("ReturnUnlockScreen");
				iTween.ScaleTo (returnUnlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
				returnUnlockText.GetComponent<Text> ().text = "このステージで遊ぶには 　 があと" + (stageNeedUnlockStar - int.Parse (PlayerPrefs.GetString ("Stars"))) + "つ必要です。";
			}
			*/

			if (stageNeedUnlockStar <= int.Parse (PlayerPrefs.GetString ("Stars"))) {
				if( stageNeedUnlockStar == 7
				   && PlayerPrefs.GetInt ("Stage01UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage02UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage03UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage04UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage05UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage06UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage07UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage08UnLock") == 1
				   && PlayerPrefs.GetInt ("Stage09UnLock") == 1){

					// 必要数以上に星を持っていた場合
					Debug.Log ("UnlockScreen");
					iTween.ScaleTo (unlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
					unlockText.GetComponent<Text> ().text = "このステージで遊ぶには 　 が" + stageNeedUnlockStar + "つ必要です。";
				} else if(stageNeedUnlockStar == 7
				          && (PlayerPrefs.GetInt ("Stage01UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage02UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage03UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage04UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage05UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage06UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage07UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage08UnLock") != 1
				          || PlayerPrefs.GetInt ("Stage09UnLock") != 1)){
					// 必要数以上に星を持っていなかった場合
					Debug.Log ("ReturnUnlockScreen");
					StarImage.SetActiveRecursively(false);
					iTween.ScaleTo (returnUnlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
					returnUnlockText.GetComponent<Text> ().text = "このステージで遊ぶには、他のステージ全てを\nクリアする必要があります。";
				} else {
					// 必要数以上に星を持っていた場合
					Debug.Log ("UnlockScreen");
					iTween.ScaleTo (unlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
					unlockText.GetComponent<Text> ().text = "このステージで遊ぶには 　 が" + stageNeedUnlockStar + "つ必要です。";
				}
			} else {
				
				// 必要数以上に星を持っていなかった場合
				Debug.Log ("ReturnUnlockScreen");
				StarImage.SetActiveRecursively(true);
				iTween.ScaleTo (returnUnlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
				returnUnlockText.GetComponent<Text> ().text = "このステージで遊ぶには 　 があと" + (stageNeedUnlockStar - int.Parse (PlayerPrefs.GetString ("Stars"))) + "つ必要です。";
			}

		}
	}
}
