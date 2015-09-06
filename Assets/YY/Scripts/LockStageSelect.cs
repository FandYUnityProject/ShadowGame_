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

	// Use this for initialization
	void Start () {
		//stageName = 
		//stageNeedUnlockStar = 
	}
	
	// ボタンをクリックした時の処理
	public void OnClick() {

		// 解禁するステージ名、必要な星の数を代入。
		DoUnlock.stageObjName = stageName;
		DoUnlock.stageObjUnlockStar = stageNeedUnlockStar;

		// ステージ解禁に必要な星の数が、現在の星の所持数より少ないかチェック
		if (stageNeedUnlockStar <= int.Parse (PlayerPrefs.GetString ("Stars"))) {

			// 必要数以上に星を持っていた場合
			Debug.Log("UnlockScreen");
			iTween.ScaleTo (unlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
			unlockText.GetComponent<Text>().text = "このステージで遊ぶには 　 が" + stageNeedUnlockStar +"つ必要です。";
		} else {

			// 必要数以上に星を持っていなかった場合
			Debug.Log("ReturnUnlockScreen");
			iTween.ScaleTo (returnUnlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
			returnUnlockText.GetComponent<Text>().text = "このステージで遊ぶには 　 があと" + (stageNeedUnlockStar - int.Parse (PlayerPrefs.GetString ("Stars"))) + "つ必要です。";
		}
	}
}
