using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

	public static float NowTime = 0.0f;
	private float SecTime = 0.0f;
	private int MinTime = 0;
	
	public static int ThreeStarsLimitTime = 60;
	public static int TwoStarsLimitTime   = 90;
	public static int OneStarLimitTime    = 120;

	public Sprite ThreeStarsImage;
	public Sprite TwoStarsImage;
	public Sprite OneStarImage;
	public Sprite NoStarImage;

	public Image ClearGetStarImage;

	public static int NowStageNumber = 0;

	void Start(){

		NowTime = 0.0f;

		for (int i=0; i<=30; i++) {
			if (i >= 1 && i <= 9) {
				// 現在のシーン（ステージ）名を取得
				if (Application.loadedLevelName == "Stage0" + i) {
					// 各星の制限時間を取得(string -> int)
					ThreeStarsLimitTime = (  int.Parse((SaveDataScript.ThreeStarsTime[i][0]).ToString()) * 600 
					                       + int.Parse((SaveDataScript.ThreeStarsTime[i][1]).ToString()) * 60 
					                       + int.Parse((SaveDataScript.ThreeStarsTime[i][3]).ToString()) * 10 
					                       + int.Parse((SaveDataScript.ThreeStarsTime[i][4]).ToString()) * 1) ;
					TwoStarsLimitTime = (  int.Parse((SaveDataScript.TwoStarsTime[i][0]).ToString()) * 600 
					                     + int.Parse((SaveDataScript.TwoStarsTime[i][1]).ToString()) * 60 
					                     + int.Parse((SaveDataScript.TwoStarsTime[i][3]).ToString()) * 10 
					                     + int.Parse((SaveDataScript.TwoStarsTime[i][4]).ToString()) * 1) ;
					OneStarLimitTime = (  int.Parse((SaveDataScript.OneStarTime[i][0]).ToString()) * 600 
					                    + int.Parse((SaveDataScript.OneStarTime[i][1]).ToString()) * 60 
					                    + int.Parse((SaveDataScript.OneStarTime[i][3]).ToString()) * 10 
					                    + int.Parse((SaveDataScript.OneStarTime[i][4]).ToString()) * 1) ;
					NowStageNumber = i;
					
					Debug.Log( ThreeStarsLimitTime );
					Debug.Log( TwoStarsLimitTime );
					Debug.Log( OneStarLimitTime );
				}
			} else if (i >= 10 && i <= 30) {
				// 現在のシーン（ステージ）名を取得
				if (Application.loadedLevelName == "Stage" + i) {
					// 各星の制限時間を取得(string -> int)
					ThreeStarsLimitTime = (  int.Parse((SaveDataScript.ThreeStarsTime[i][0]).ToString()) * 600 
					                       + int.Parse((SaveDataScript.ThreeStarsTime[i][1]).ToString()) * 60 
					                       + int.Parse((SaveDataScript.ThreeStarsTime[i][3]).ToString()) * 10 
					                       + int.Parse((SaveDataScript.ThreeStarsTime[i][4]).ToString()) * 1) ;
					TwoStarsLimitTime = (  int.Parse((SaveDataScript.TwoStarsTime[i][0]).ToString()) * 600 
					                     + int.Parse((SaveDataScript.TwoStarsTime[i][1]).ToString()) * 60 
					                     + int.Parse((SaveDataScript.TwoStarsTime[i][3]).ToString()) * 10 
					                     + int.Parse((SaveDataScript.TwoStarsTime[i][4]).ToString()) * 1) ;
					OneStarLimitTime = (  int.Parse((SaveDataScript.OneStarTime[i][0]).ToString()) * 600 
					                    + int.Parse((SaveDataScript.OneStarTime[i][1]).ToString()) * 60 
					                    + int.Parse((SaveDataScript.OneStarTime[i][3]).ToString()) * 10 
					                    + int.Parse((SaveDataScript.OneStarTime[i][4]).ToString()) * 1) ;
					NowStageNumber = i;
				}
			}
		}
	}
	
	void Update (){

		//1秒に1ずつ増やしていく
		if (!GoalTouchScript.GoalTouch) {
			if( !LightColorChanger.inCircle ){
				NowTime += Time.deltaTime;
				SecTime += Time.deltaTime;
				GetComponent<Text> ().color = new Color(255, 255, 255);
			} else {
				NowTime += Time.deltaTime * 2;
				SecTime += Time.deltaTime * 2;
				GetComponent<Text> ().color = new Color(255, 0, 0);
			}
		}

		if (SecTime >= 60) {
			SecTime = 0;
			MinTime++;
		}

		if (Mathf.FloorToInt(NowTime) < 6000) {
			if (SecTime < 10 && MinTime < 10) {
				GetComponent<Text> ().text = ("0" + MinTime + ":0" + ((int)SecTime).ToString ());
			} else if (SecTime >= 10 && MinTime < 10) {
				GetComponent<Text> ().text = ("0" + MinTime + ":" + ((int)SecTime).ToString ());
			} else if (SecTime < 10 && MinTime >= 10) {
				GetComponent<Text> ().text = ("" + MinTime + ":0" + ((int)SecTime).ToString ());
			} else if (SecTime >= 10 && MinTime >= 10) {
				GetComponent<Text> ().text = ("" + MinTime + ":" + ((int)SecTime).ToString ());
			}
		} else {
			GetComponent<Text> ().text = ("99:59");
		}

		// 獲得星の表示
		if (Mathf.FloorToInt(NowTime) <= ThreeStarsLimitTime) {
			ClearGetStarImage.sprite = ThreeStarsImage;

			if (NowStageNumber >= 1 && NowStageNumber <= 9) {
				if (PlayerPrefs.GetInt ("Stage0" + NowStageNumber + "TwoStarsClear") == 0) {
					// もし2つ星をクリアしてないなら
					ClearGetStarImage.sprite = TwoStarsImage;
				}
				if (PlayerPrefs.GetInt ("Stage0" + NowStageNumber + "OneStarClear") == 0) {
					// もし1つ星をクリアしてないなら
					ClearGetStarImage.sprite = OneStarImage;
				}
			} else if (NowStageNumber >= 10 && NowStageNumber <= 30) {
				if (PlayerPrefs.GetInt ("Stage" + NowStageNumber + "TwoStarsClear") == 0) {
					// もし2つ星をクリアしてないなら
					ClearGetStarImage.sprite = TwoStarsImage;
				}
				if (PlayerPrefs.GetInt ("Stage" + NowStageNumber + "OneStarClear") == 0) {
					// もし1つ星をクリアしてないなら
					ClearGetStarImage.sprite = OneStarImage;
				}
			}
		} else if (ThreeStarsLimitTime < Mathf.FloorToInt(NowTime) && Mathf.FloorToInt(NowTime) <= TwoStarsLimitTime) {
			ClearGetStarImage.sprite = TwoStarsImage;

			if (NowStageNumber >= 1 && NowStageNumber <= 9) {
				if (PlayerPrefs.GetInt ("Stage0" + NowStageNumber + "OneStarClear") == 0) {
					// もし1つ星をクリアしてないなら
					ClearGetStarImage.sprite = OneStarImage;
				}
			} else if (NowStageNumber >= 10 && NowStageNumber <= 30) {
				if (PlayerPrefs.GetInt ("Stage" + NowStageNumber + "OneStarClear") == 0) {
					// もし1つ星をクリアしてないなら
					ClearGetStarImage.sprite = OneStarImage;
				}
			}
		} else if (TwoStarsLimitTime < Mathf.FloorToInt(NowTime) && Mathf.FloorToInt(NowTime) <= OneStarLimitTime) {
			ClearGetStarImage.sprite = OneStarImage;
		} else if (Mathf.FloorToInt(NowTime) > OneStarLimitTime) {
			ClearGetStarImage.sprite = NoStarImage;
		}
	}
}
