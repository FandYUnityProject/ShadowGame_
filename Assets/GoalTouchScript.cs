using UnityEngine;
using System.Collections;

public class GoalTouchScript : MonoBehaviour {

	private int NowGetStars;
	public static bool GoalTouch;

	void Start(){
		GoalTouch = false;
	}

	void OnCollisionEnter(Collision coll){
		if (!GoalTouch) {
			if (coll.gameObject.name == "Player") {

				GoalTouch = true;

				// 現在の獲得星を取得
				NowGetStars = int.Parse (PlayerPrefs.GetString ("Stars"));

				Debug.Log ("Stars:" + NowGetStars + ", NowStageNumber" + TimerScript.NowStageNumber);
				Debug.Log ("Three:" + TimerScript.ThreeStarsLimitTime + ", Two" + TimerScript.TwoStarsLimitTime + ", One" + TimerScript.OneStarLimitTime);
				Debug.Log ("Now:" + Mathf.FloorToInt(TimerScript.NowTime));
				Debug.Log ("3Clear:" + PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "ThreeStarsClear"));
				Debug.Log ("2Clear:" + PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear"));
				Debug.Log ("1Clear:" + PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear"));

				if (TimerScript.NowStageNumber >= 1 && TimerScript.NowStageNumber <= 9) {

					// ３星タイムをクリアしたら
					if (TimerScript.ThreeStarsLimitTime >= Mathf.FloorToInt(TimerScript.NowTime)) {
						
						if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "ThreeStarsClear") == 0) {
							
							if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear") == 1
							    && PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear") == 1) {
								// １、２星を既にクリアしていたら、獲得星を１つ増やす
								NowGetStars = NowGetStars + 1;
							} else if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear") == 0
							           && PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear") == 1) {
								// １星のみを既にクリアしていたら、獲得星を２つ増やし、２星クリアのフラグを立てる
								PlayerPrefs.SetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear", 1);
								NowGetStars = NowGetStars + 2;
							} else if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear") == 0
							           && PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear") == 0) {
								// いきなり３星タイムをクリアしたら、１、２星クリアのフラグを立て、獲得星を３つ増やす
								PlayerPrefs.SetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear", 1);
								PlayerPrefs.SetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear", 1);
								NowGetStars = NowGetStars + 3;
							}
						}
						
						// ３星クリアのフラグを立てる
						PlayerPrefs.SetInt ("Stage0" + TimerScript.NowStageNumber + "ThreeStarsClear", 1);
					}
					// ２星タイムをクリアしたら
					if (TimerScript.ThreeStarsLimitTime < Mathf.FloorToInt(TimerScript.NowTime) && Mathf.FloorToInt(TimerScript.NowTime) <= TimerScript.TwoStarsLimitTime) {

						if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear") == 0) {
							// 既に１星クリアをしていたら、獲得星を１つ増やす
							if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear") == 1) {
								NowGetStars = NowGetStars + 1;
							}
							if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear") == 0) {
								// いきなり２星タイムをクリアしたら、１星クリアのフラグを立て、獲得星を２つ増やす
								PlayerPrefs.SetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear", 1);
								NowGetStars = NowGetStars + 2;
							}
							
							// ２星クリアのフラグを立てる
							PlayerPrefs.SetInt ("Stage0" + TimerScript.NowStageNumber + "TwoStarsClear", 1);
						}
					}
					// １星タイムをクリアし、まだ１星クリアをしていなければ１星クリアのフラグを立て、獲得星を１つ増やす
					if (TimerScript.TwoStarsLimitTime < Mathf.FloorToInt(TimerScript.NowTime) && Mathf.FloorToInt(TimerScript.NowTime) <= TimerScript.OneStarLimitTime) {
						if (PlayerPrefs.GetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear") == 0) {
							PlayerPrefs.SetInt ("Stage0" + TimerScript.NowStageNumber + "OneStarClear", 1);
							NowGetStars = NowGetStars + 1;
						}
					}

				} else if (TimerScript.NowStageNumber >= 10 && TimerScript.NowStageNumber <= 30) {

					// ３星タイムをクリアしたら
					if (TimerScript.ThreeStarsLimitTime >= Mathf.FloorToInt(TimerScript.NowTime)) {

						if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "ThreeStarsClear") == 0) {

							if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "TwoStarsClear") == 1
								&& PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear") == 1) {
								// １、２星を既にクリアしていたら、獲得星を１つ増やす
								NowGetStars = NowGetStars + 1;
							} else if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "TwoStarsClear") == 0
								&& PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear") == 1) {
								// １星のみを既にクリアしていたら、獲得星を２つ増やし、２星クリアのフラグを立てる
								PlayerPrefs.SetInt ("Stage" + TimerScript.NowStageNumber + "TwoStarsClear", 1);
								NowGetStars = NowGetStars + 2;
							} else if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "TwoStarsClear") == 0
								&& PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear") == 0) {
								// いきなり３星タイムをクリアしたら、１、２星クリアのフラグを立て、獲得星を３つ増やす
								PlayerPrefs.SetInt ("Stage" + TimerScript.NowStageNumber + "TwoStarsClear", 1);
								PlayerPrefs.SetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear", 1);
								NowGetStars = NowGetStars + 3;
							}
						}
					
						// ３星クリアのフラグを立てる
						PlayerPrefs.SetInt ("Stage" + TimerScript.NowStageNumber + "ThreeStarsClear", 1);
					}
					// ２星タイムをクリアしたら
					if (TimerScript.ThreeStarsLimitTime < Mathf.FloorToInt(TimerScript.NowTime) && Mathf.FloorToInt(TimerScript.NowTime) <= TimerScript.TwoStarsLimitTime) {

						if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "TwoStarsClear") == 0) {
							// 既に１星クリアをしていたら、獲得星を１つ増やす
							if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear") == 1) {
								NowGetStars = NowGetStars + 1;
							} else if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear") == 0) {
								// // いきなり２星タイムをクリアしたら、１星クリアのフラグを立て、獲得星を２つ増やす
								PlayerPrefs.SetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear", 1);
								NowGetStars = NowGetStars + 2;
							}
						
							// ２星クリアのフラグを立てる
							PlayerPrefs.SetInt ("Stage" + TimerScript.NowStageNumber + "TwoStarsClear", 1);
						}
					}
					// １星タイムをクリアし、まだ１星クリアをしていなければ１星クリアのフラグを立て、獲得星を１つ増やす
					if (TimerScript.TwoStarsLimitTime < Mathf.FloorToInt(TimerScript.NowTime) && Mathf.FloorToInt(TimerScript.NowTime) <= TimerScript.OneStarLimitTime) {
						if (PlayerPrefs.GetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear") == 0) {
							PlayerPrefs.SetInt ("Stage" + TimerScript.NowStageNumber + "OneStarClear", 1);
							NowGetStars = NowGetStars + 1;
						}
					}
				}

				// 獲得星数をセーブ
				PlayerPrefs.SetString ("Stars", (NowGetStars).ToString ());
				Debug.Log ("Stars:" + NowGetStars + ", NowStageNumber" + TimerScript.NowStageNumber);

				// コルーチンを実行
				StartCoroutine ("GoToStageSelect");
			}
		}
	}
	
	private IEnumerator GoToStageSelect() {

		// 3秒待つ
		yield return new WaitForSeconds (3.0f);

		// ステージ選択画面に移動
		Application.LoadLevel ("StageSelect");
	}
}
