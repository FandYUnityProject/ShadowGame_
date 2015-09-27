using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoUnlock : MonoBehaviour {

	public static string stageObjName;
	public static int stageObjUnlockStar = 0;
	public GameObject starCountObj;
	public GameObject unlockMenu;

	Button lockStageButton;

	private GameObject Chane01;
	private GameObject Chane02;
	private GameObject Lock;
	private GameObject StageLock;
	private GameObject StageLockImage;
	private GameObject StageSelect;
	
	private GameObject ArrowRight;
	private GameObject ArrowLeft;
	private GameObject StageSlider;
	
	public AudioClip SelectSound;

	// Use this for initialization
	void Start () {
		ArrowRight = GameObject.Find ("ArrowRight");
		ArrowLeft = GameObject.Find ("ArrowLeft");
		StageSlider = GameObject.Find ("StageSlider");
	}

	private int resultStarNumber;

	// ボタンをクリックした時の処理
	public void OnClick() {

		// ステージ解禁情報をセーブする
		PlayerPrefs.SetInt (stageObjName, 1);

		// 必要な星の数だけ所持星数を減らす
		resultStarNumber = int.Parse(PlayerPrefs.GetString ("Stars"));
		resultStarNumber = resultStarNumber - stageObjUnlockStar;
		PlayerPrefs.SetString ("Stars", resultStarNumber.ToString());
		starCountObj.GetComponent<Text>().text = PlayerPrefs.GetString ("Stars");

		// 解禁画面を閉じるアニメーションを再生
		iTween.ScaleTo (unlockMenu, iTween.Hash("time", 0.7f, "x", 0, "y", 0, "z", 0,"easeType", "easeInBack"));
		StartCoroutine ("NotPushButton");
	}

	// Joystickでクリックした時の処理
	public void OnClickJoystick(int NeedUnlockStars) {

		Debug.Log ("stageObjName: " + stageObjName);

		// ステージ解禁情報をセーブする
		PlayerPrefs.SetInt (stageObjName, 1);
		
		// 必要な星の数だけ所持星数を減らす
		resultStarNumber = int.Parse(PlayerPrefs.GetString ("Stars"));
		resultStarNumber = resultStarNumber - NeedUnlockStars;
		PlayerPrefs.SetString ("Stars", resultStarNumber.ToString());
		starCountObj.GetComponent<Text>().text = PlayerPrefs.GetString ("Stars");
		
		// 解禁画面を閉じるアニメーションを再生
		iTween.ScaleTo (unlockMenu, iTween.Hash("time", 0.7f, "x", 0, "y", 0, "z", 0,"easeType", "easeInBack"));
		StartCoroutine ("NotPushButton");
	}
	
	// コルーチン
	public IEnumerator NotPushButton() {
		// コルーチンの処理
		
		GetComponent<AudioSource>().PlayOneShot(SelectSound);

		// ボタンを非活性にする
		this.GetComponent<UnityEngine.UI.Button>().enabled = false;
		ArrowRight.SetActiveRecursively(false);
		ArrowLeft.SetActiveRecursively(false);
		StageSlider.SetActiveRecursively(false);
		// 1秒待つ
		yield return new WaitForSeconds (1.0f);
		// ボタンを活性化する
		this.GetComponent<UnityEngine.UI.Button>().enabled = true;
		// 鎖、南京錠が外れるアニメを実行
		UnlockAnimation ();
	}
	
	public void UnlockAnimation(){

		Debug.Log (stageObjName);

		for(int i=1; i<=30; i++){ 
			if( i>=1 && i<=9 ){ 
				if( stageObjName == "Stage0" + i + "UnLock" ){
					Chane01         = GameObject.Find("StageLock0" + i + "Chane01");
					Chane02         = GameObject.Find("StageLock0" + i + "Chane02");
					Lock            = GameObject.Find("StageLock0" + i + "Lock");
					StageLock       = GameObject.Find("StageLock0" + i);

					// 一度ロックを解除したら再びロック解除メニューが表示されないようボタンを非活性にする
					StageLockImage  = GameObject.Find("StageLock0" + i + "/StageImage");
					lockStageButton = StageLockImage.GetComponent<UnityEngine.UI.Button>();
					Debug.Log(lockStageButton);
					lockStageButton.enabled = false;

					StageSelect     = SaveDataScript.StageSelectArray[i];
					PlayerPrefs.SetInt ("Stage0" + i + "UnLock", 1);
				}
			} else {
				if( stageObjName == "Stage" + i + "UnLock" ){
					Chane01     = GameObject.Find("StageLock" + i + "Chane01");
					Chane02     = GameObject.Find("StageLock" + i + "Chane02");
					Lock        = GameObject.Find("StageLock" + i + "Lock");
					StageLock   = GameObject.Find("StageLock" + i);

					// 一度ロックを解除したら再びロック解除メニューが表示されないようボタンを非活性にする
					StageLockImage  = GameObject.Find("StageLock" + i + "/StageImage");
					lockStageButton = StageLockImage.GetComponent<UnityEngine.UI.Button>();
					Debug.Log(lockStageButton);
					lockStageButton.enabled = false;

					StageSelect = SaveDataScript.StageSelectArray[i];
					PlayerPrefs.SetInt ("Stage" + i + "UnLock", 1);
				}
			}
		}
		iTween.ScaleTo (Chane01, iTween.Hash("time", 0.7f, "delay", 0.0f, "x", 0, "y", 0, "z", 0,"easeType", "easeOutQuad"));
		iTween.ScaleTo (Chane02, iTween.Hash("time", 0.7f, "delay", 0.2f, "x", 0, "y", 0, "z", 0,"easeType", "easeOutQuad"));
		iTween.MoveBy  (Lock,    iTween.Hash("time", 1.0f, "delay", 0.2f,         "y", -205,     "easeType", "easeInBack","oncomplete", "CompletedHandler", "oncompletetarget", gameObject));
	}

	private void CompletedHandler()
	{
		lockStageButton.enabled = true;

		// ロックステージ画面を削除する
		Destroy (StageLock);
		// 解除されたステージを表示する
		Debug.Log (StageSelect);
		StageSelect.SetActiveRecursively(true);

		// ボタンを活性化する
		ArrowRight.SetActiveRecursively(true);
		ArrowLeft.SetActiveRecursively(true);
		StageSlider.SetActiveRecursively(true);
		
		
		GoStageScene.isCloseUnlockMenu = false;
		GoStageScene.isSelectLockStage = false;
		Debug.Log("ReturnOK");
	}
}
