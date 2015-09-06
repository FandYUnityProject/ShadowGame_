using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoStageScene : MonoBehaviour {

	void Start(){

		//画像(Texture2D)がない場合も必ず必要！
		iTween.CameraFadeAdd();
	}

	// ボタンをクリックした時の処理
	public void OnClick() {

		// 表示を真っ暗にしていくアニメーション
		iTween.CameraFadeTo(iTween.Hash("amount",1.0f,"time",1.0f,"ignoretimescale",true,"oncomplete", "OnComplete","oncompletetarget", gameObject));
	}

	// 表示が真っ暗になったら”メインマップ”シーンへ移動する。
	void OnComplete()
	{
		Debug.Log ("SceneMove:" + this.gameObject.name );

		for(int i=1; i<=30; i++){ 
			if( i>=1 && i<=9 ){ 
				if( this.gameObject.name == "StageImage0" + i ){
					Application.LoadLevel ("Stage0" + i);
				}
			} else {
				if( this.gameObject.name == "StageImage" + i ){
					Application.LoadLevel ("Stage" + i);
				}
			}
		}
	}
}
