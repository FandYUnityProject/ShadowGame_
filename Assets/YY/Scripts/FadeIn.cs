using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	public Texture2D fadeTexture;
	
	// Use this for initialization
	void Start () {
		
		//画像(Texture2D)がない場合も必ず必要！
		iTween.CameraFadeAdd(fadeTexture);
		
		// 表示をだんだん明るくするアニメーション
		iTween.CameraFadeTo(iTween.Hash("amount",1.0f,"time",2.5f, "oncomplete", "OnComplete", "oncompletetarget",this.gameObject));
	}
	void OnComplete(){
		iTween.CameraFadeTo(iTween.Hash("amount",0.0f,"time",1.5f, "delay", 0.5f,"oncompletetarget",this.gameObject));
	}
}
