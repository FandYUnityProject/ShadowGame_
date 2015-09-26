using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoStageScene : MonoBehaviour {

	AsyncOperation async;
	private GameObject loading;
	private bool isStageSelect;

	private GameObject unlockMenu;
	private GameObject returnUnlockMenu;
	private GameObject unlockText;
	private GameObject returnUnlockText;
	
	private GameObject doUnlock;
	private GameObject doNotUnlock;
	private int nowLockMenu = 0; //0...No, 1...DoUnlock, 2...DoNotUnlock
	private bool isUnlock = true;

	public static bool isSelectLockStage;
	public static bool isCloseUnlockMenu;

	// 必要な星の数（体験版）
	public static int[] stageObjUnlockStar = 
	new int[] {-1, 0, 0, 0, 0, 0, 3, 4, 5, 6
		, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0
		, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1
	};

	// 必要な星の数
	/*
	public static int[] stageObjUnlockStar = 
	new int[] {-1, 0, 0, 0, 0, 0, 1, 1, 1, 1
		, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4
		, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 7, -1
	};
	*/

	void Start(){

		loading = GameObject.Find ("Loading");
		//画像(Texture2D)がない場合も必ず必要！
		iTween.CameraFadeAdd();

		isStageSelect = false;
		unlockMenu = GameObject.Find ("UnlockMenu");
		returnUnlockMenu = GameObject.Find ("ReturnUnlockMenu");
		unlockText = GameObject.Find ("UnlockText");
		returnUnlockText = GameObject.Find ("ReturnUnlockText");
		
		doUnlock    = GameObject.Find ("DoUnlockButton");
		doNotUnlock = GameObject.Find ("DoNotUnlockButton");
		isSelectLockStage = false;
		isCloseUnlockMenu = false;
	}

	void CompletedCloseUnlockMenu(){
		isCloseUnlockMenu = false;
		isSelectLockStage = false;
		nowLockMenu = 0;
		Debug.Log("ReturnOK");
	}

	void Update(){

		Debug.Log (nowLockMenu);

		// ロック解除選択画面が出ている時に決定ボタンを押した時の処理
		if( nowLockMenu == 1 ){
			if (Input.GetAxis ("Horizontal") < 0){
				// “使用する”を選択状態にする
				Button doUnlockButton = doUnlock.GetComponent<Button> ();
				doUnlockButton.Select ();
				isUnlock = true;
			}
			if (Input.GetAxis ("Horizontal") > 0){
				// “使用しない”を選択状態にする
				Button doUnlockButton = doNotUnlock.GetComponent<Button> ();
				doUnlockButton.Select ();
				isUnlock = false;
			}
		}

		// ロック解除/解除不可能画面が出ている時に決定ボタンを押した時の処理
		if (Input.GetButtonDown ("Submit")){

			// ロック解除選択画面
			if( nowLockMenu == 1 ){
				Debug.Log ("UNROCK");

				if (ArrowPush.selectStageNumber >= 1 && ArrowPush.selectStageNumber <= 9) { 
					if( isUnlock ){
						DoUnlock.stageObjName = "Stage0" + ArrowPush.selectStageNumber + "UnLock";
						doUnlock.SendMessage("OnClickJoystick", stageObjUnlockStar[ArrowPush.selectStageNumber]);
						nowLockMenu = 0;
					} else {
						isCloseUnlockMenu = true;
						Debug.Log("Return");
						iTween.ScaleTo (unlockMenu, iTween.Hash("time", 0.7f, "x", 0, "y", 0, "z", 0,"easeType", "easeInBack","oncomplete", "CompletedCloseUnlockMenu", "oncompletetarget", gameObject));
					}
				} else {
					if( isUnlock ){
						DoUnlock.stageObjName = "Stage" + ArrowPush.selectStageNumber + "UnLock";
						doUnlock.SendMessage("OnClickJoystick", stageObjUnlockStar[ArrowPush.selectStageNumber]);
						nowLockMenu = 0;
					} else {
						isCloseUnlockMenu = true;
						Debug.Log("Return");
						iTween.ScaleTo (unlockMenu, iTween.Hash("time", 0.7f, "x", 0, "y", 0, "z", 0,"easeType", "easeInBack","oncomplete", "CompletedCloseUnlockMenu", "oncompletetarget", gameObject));
					}
				}
			}

			// ロック解除不可能画面
			if( nowLockMenu == 2 && !isCloseUnlockMenu ){
				isCloseUnlockMenu = true;
				Debug.Log("Return");
				iTween.ScaleTo (returnUnlockMenu, iTween.Hash("time", 0.7f, "x", 0, "y", 0, "z", 0,"easeType", "easeInBack","oncomplete", "CompletedCloseUnlockMenu", "oncompletetarget", gameObject));
			}
		}

		// ステージ選択画面
		if (Input.GetButtonDown ("Submit") && !isStageSelect && !isSelectLockStage && nowLockMenu == 0) {

			if (ArrowPush.selectStageNumber >= 1 && ArrowPush.selectStageNumber <= 9) { 

				// ステージロックを解除していれば各ステージに移動
				if ((PlayerPrefs.GetInt ("Stage0" + ArrowPush.selectStageNumber + "UnLock") == 1)) {

					// ステージ選択フラグを立てる
					isStageSelect = true;

					iTween.ScaleTo (loading, iTween.Hash ("time", 0.2f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
					iTween.RotateBy (loading, iTween.Hash ("time", 15.0f, "z", -3, "easeType", "easeOutQuad"));
			
					// 各ステージに移動
					StartCoroutine ("GoToStageKey");
				} else {

					// ロック画面表示フラグを立てる
					isSelectLockStage = true;

					// ステージ解禁に必要な星の数が、現在の星の所持数より少ないかチェック
					if (stageObjUnlockStar[ArrowPush.selectStageNumber] <= int.Parse (PlayerPrefs.GetString ("Stars"))) {
						
						// 必要数以上に星を持っていた場合
						Debug.Log("UnlockScreen");

						// “使用しない”を選択状態にする
						Button doUnlockButton = doNotUnlock.GetComponent<Button> ();
						doUnlockButton.Select ();
						isUnlock = false;

						iTween.ScaleTo (unlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
						unlockText.GetComponent<Text>().text = "このステージで遊ぶには 　 が" + stageObjUnlockStar[ArrowPush.selectStageNumber] +"つ必要です。";

						// ロック解除選択画面中
						nowLockMenu = 1;
					} else {
						
						// 必要数以上に星を持っていなかった場合
						Debug.Log("ReturnUnlockScreen");
						iTween.ScaleTo (returnUnlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
						returnUnlockText.GetComponent<Text>().text = "このステージで遊ぶには 　 があと" + (stageObjUnlockStar[ArrowPush.selectStageNumber] - int.Parse (PlayerPrefs.GetString ("Stars"))) + "つ必要です。";

						// ロック解除不可能画面中
						nowLockMenu = 2;
					}
				}
			} else {

				// ステージロックを解除していれば各ステージに移動
				if ((PlayerPrefs.GetInt ("Stage" + ArrowPush.selectStageNumber + "UnLock") == 1)) {
					
					// ステージ選択フラグを立てる
					isStageSelect = true;
					
					iTween.ScaleTo (loading, iTween.Hash ("time", 0.2f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
					iTween.RotateBy (loading, iTween.Hash ("time", 15.0f, "z", -3, "easeType", "easeOutQuad"));
					
					// 各ステージに移動
					StartCoroutine ("GoToStageKey");
				} else {
					
					// ロック画面表示フラグを立てる
					isSelectLockStage = true;
					
					// ステージ解禁に必要な星の数が、現在の星の所持数より少ないかチェック
					if (stageObjUnlockStar[ArrowPush.selectStageNumber] <= int.Parse (PlayerPrefs.GetString ("Stars"))) {
						
						// 必要数以上に星を持っていた場合
						Debug.Log("UnlockScreen");
						
						// “使用しない”を選択状態にする
						Button doUnlockButton = doNotUnlock.GetComponent<Button> ();
						doUnlockButton.Select ();
						isUnlock = false;
						
						iTween.ScaleTo (unlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
						unlockText.GetComponent<Text>().text = "このステージで遊ぶには 　 が" + stageObjUnlockStar[ArrowPush.selectStageNumber] +"つ必要です。";
						
						// ロック解除選択画面中
						nowLockMenu = 1;
					} else {
						
						// 必要数以上に星を持っていなかった場合
						Debug.Log("ReturnUnlockScreen");
						iTween.ScaleTo (returnUnlockMenu, iTween.Hash ("time", 0.5f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
						returnUnlockText.GetComponent<Text>().text = "このステージで遊ぶには 　 があと" + (stageObjUnlockStar[ArrowPush.selectStageNumber] - int.Parse (PlayerPrefs.GetString ("Stars"))) + "つ必要です。";
						
						// ロック解除不可能画面中
						nowLockMenu = 2;
					}
				}
			}
		}
	}

	// ボタンをクリックした時の処理
	public void OnClick() {

		if (!isStageSelect) {
			
			isStageSelect = true;

			iTween.ScaleTo (loading, iTween.Hash ("time", 0.2f, "x", 1, "y", 1, "z", 1, "easeType", "easeOutQuad"));
			iTween.RotateBy (loading, iTween.Hash ("time", 15.0f, "z", -3, "easeType", "easeOutQuad"));

			// コルーチンを実行
			StartCoroutine ("GoToStage");

			// 表示を真っ暗にしていくアニメーション
			iTween.CameraFadeTo (iTween.Hash ("amount", 1.0f, "time", 1.0f, "ignoretimescale", true, "oncomplete", "OnComplete", "oncompletetarget", gameObject));
		}
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
					NowStageNumber.StageNumber = i;
					async = Application.LoadLevelAsync("Stage0" + i);
				}
			} else {
				if( this.gameObject.name == "StageImage" + i ){
					NowStageNumber.StageNumber = i;
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


	// 各ステージに移動
	private IEnumerator GoToStageKey() {
		
		Debug.Log ("SceneMove:" + this.gameObject.name );

		yield return new WaitForSeconds (1.0f);

		if( ArrowPush.selectStageNumber >=1 && ArrowPush.selectStageNumber<=9 ){ 
			if( this.gameObject.name == "StageImage0" + ArrowPush.selectStageNumber ){
				NowStageNumber.StageNumber = ArrowPush.selectStageNumber;
				Application.LoadLevel("Stage0" + ArrowPush.selectStageNumber);
			}
		} else {
			if( this.gameObject.name == "StageImage" + ArrowPush.selectStageNumber ){
				NowStageNumber.StageNumber = ArrowPush.selectStageNumber;
				Application.LoadLevel("Stage" + ArrowPush.selectStageNumber);
			}
		}
	}

}
