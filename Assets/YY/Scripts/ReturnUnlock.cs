using UnityEngine;
using System.Collections;

public class ReturnUnlock : MonoBehaviour {

	public GameObject unlockMenu;

	// ボタンをクリックした時の処理
	public void OnClick() {

		// 解禁画面を閉じるアニメーションを再生
		iTween.ScaleTo (unlockMenu, iTween.Hash("time", 0.7f, "x", 0, "y", 0, "z", 0,"easeType", "easeInBack"));
	}
}
