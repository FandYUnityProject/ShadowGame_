using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerScript : MonoBehaviour {

	private float NowTime = 0.0f;
	private float SecTime = 0.0f;
	private int MinTime = 0;
	
	public int ThreeStarsLimitTime = 60;
	public int TwoStarsLimitTime   = 90;
	public int OneStarLimitTime    = 120;

	public Sprite ThreeStarsImage;
	public Sprite TwoStarsImage;
	public Sprite OneStarImage;
	public Sprite NoStarImage;

	public Image ClearGetStarImage;
	
	void Update (){

		//1秒に1ずつ増やしていく
		NowTime += Time.deltaTime;
		SecTime += Time.deltaTime;

		if (SecTime >= 60) {
			SecTime = 0;
			MinTime++;
		}

		if (NowTime < 6000) {
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
		if (NowTime <= ThreeStarsLimitTime) {
			ClearGetStarImage.sprite = ThreeStarsImage;
		} else if (ThreeStarsLimitTime < NowTime && NowTime <= TwoStarsLimitTime) {
			ClearGetStarImage.sprite = TwoStarsImage;
		} else if (TwoStarsLimitTime < NowTime && NowTime <= OneStarLimitTime) {
			ClearGetStarImage.sprite = OneStarImage;
		} else {
			ClearGetStarImage.sprite = NoStarImage;
		}

	}
}
