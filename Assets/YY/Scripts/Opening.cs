using UnityEngine;
using System.Collections;

public class Opening : MonoBehaviour {

	public Texture2D fadeTexture01;
	public Texture2D fadeTexture02;

	private int NowSceane = 1;

	// Use this for initialization
	void Start () {
		
		//画像(Texture2D)がない場合も必ず必要！
		iTween.CameraFadeAdd(fadeTexture01);
		
		// 表示をだんだん明るくするアニメーション
		iTween.CameraFadeTo(iTween.Hash("amount",1.0f,"time",2.5f, "delay", 1.0f, "oncomplete", "OnComplete01","oncompletetarget",this.gameObject));
	}

	void OnComplete01(){
		iTween.CameraFadeTo(iTween.Hash("amount",0.0f,"time",1.5f, "delay", 0.5f,"oncomplete","OnStart02","oncompletetarget",this.gameObject));
	}
	
	void OnStart02(){
		//画像変更
		iTween.CameraFadeSwap (fadeTexture02);
		NowSceane = 2;
		iTween.CameraFadeTo(iTween.Hash("amount",1.0f,"time",1.5f, "delay", 1.0f,"oncomplete","OnComplete02","oncompletetarget",this.gameObject));
	}

	
	void OnComplete02(){
		iTween.CameraFadeTo(iTween.Hash("amount",0.0f,"time",1.5f, "delay", 0.5f,"oncomplete","GoToStageSelect","oncompletetarget",this.gameObject));
	}

	void GoToStageSelect(){
		Application.LoadLevel("StageSelect");
	}

	void Update(){
		if (Input.GetMouseButton (0)) {
			if(NowSceane == 1){
				iTween.CameraFadeTo(iTween.Hash("amount",0.0f,"time",1.5f, "delay", 0.0f,"oncomplete","OnStart02","oncompletetarget",this.gameObject));
				Debug.Log ("LeftClick01");
			} else{
				iTween.CameraFadeTo(iTween.Hash("amount",0.0f,"time",1.5f, "delay", 0.0f,"oncomplete","GoToStageSelect","oncompletetarget",this.gameObject));
				Debug.Log ("LeftClick02");
			}
		}
		if (Input.GetKeyDown(KeyCode.Return)) {
			if(NowSceane == 1){
				iTween.CameraFadeTo(iTween.Hash("amount",0.0f,"time",1.5f, "delay", 0.0f,"oncomplete","OnStart02","oncompletetarget",this.gameObject));
				Debug.Log ("Enter01");
			} else{
				iTween.CameraFadeTo(iTween.Hash("amount",0.0f,"time",1.5f, "delay", 0.0f,"oncomplete","GoToStageSelect","oncompletetarget",this.gameObject));
				Debug.Log ("Enter02");
			}
		}
	}
}
