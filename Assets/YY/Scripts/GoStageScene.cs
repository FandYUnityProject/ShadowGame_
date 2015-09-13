using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoStageScene : MonoBehaviour {

	AsyncOperation async;
	private GameObject loading;

	void Start(){

		loading = GameObject.Find ("Loading");
		//画像(Texture2D)がない場合も必ず必要！
		iTween.CameraFadeAdd();
	}

	// ボタンをクリックした時の処理
	public void OnClick() {

		
		iTween.ScaleTo (loading, iTween.Hash ("time", 0.2f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
		iTween.RotateBy (loading, iTween.Hash ("time", 15.0f, "z", -3, "easeType", "easeOutQuad"));

		// コルーチンを実行
		StartCoroutine ("GoToStage");

		// 表示を真っ暗にしていくアニメーション
		iTween.CameraFadeTo(iTween.Hash("amount",1.0f,"time",1.0f,"ignoretimescale",true,"oncomplete", "OnComplete","oncompletetarget", gameObject));
	}

	// 表示が真っ暗になったら”メインマップ”シーンへ移動する。
	void OnComplete()
	{

	}

	private IEnumerator GoToStage() {

		Debug.Log ("SceneMove:" + this.gameObject.name );
		
		for(int i=1; i<=30; i++){ 
			if( i>=1 && i<=9 ){ 
				if( this.gameObject.name == "StageImage0" + i ){
					async = Application.LoadLevelAsync("Stage0" + i);
				}
			} else {
				if( this.gameObject.name == "StageImage" + i ){
					async = Application.LoadLevelAsync("Stage" + i);
				}
			}
		}


		async.allowSceneActivation = false;    // シーン遷移をしない
		
		while (async.progress < 0.9f) {
			Debug.Log(async.progress);
			//loadingText.text = (async.progress * 100).ToString("F0") + "%";
			//loadingBar.fillAmount = async.progress;
			yield return new WaitForEndOfFrame();
		}
		
		Debug.Log("Scene Loaded");
		Debug.Log(async.progress);

		//loadingText.text = "100%";
		//loadingBar.fillAmount = 1;
		
		yield return new WaitForSeconds(1);
		
		async.allowSceneActivation = true;    // シーン遷移許可
	}

}
