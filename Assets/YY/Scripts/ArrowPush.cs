﻿using UnityEngine;
using System.Collections;

public class ArrowPush : MonoBehaviour {

	public GameObject stagePanel;
	private Vector2 pos;
	public static bool isStagePanelMove = false;

	public static int selectStageNumber = 1;
	
	public AudioClip SelectSound;

	void Start(){
		// uGUI用のpositionを取得
		pos = stagePanel.GetComponent<RectTransform> ().anchoredPosition;

		Debug.Log ("StageNumber: " + NowStageNumber.StageNumber);
		selectStageNumber = NowStageNumber.StageNumber;

		pos.x = -(selectStageNumber) * 648;
		stagePanel.GetComponent<RectTransform> ().anchoredPosition = pos;
	}
	
	void Update(){

		// *** JoyStick & Keyboard *** //
		// ロック画面解除/不可能画面表示中でなければ
		if (!GoStageScene.isSelectLockStage && !GoStageScene.isCloseUnlockMenu) {

			if (Input.GetAxis ("Horizontal") < 0 && selectStageNumber != 1 && isStagePanelMove == false) {
				
				GetComponent<AudioSource>().PlayOneShot(SelectSound);
				
				Debug.Log("selectStageNumber Before" + selectStageNumber);

				selectStageNumber--;
				StagePanelSlider.slider.value = Mathf.RoundToInt (StagePanelSlider.slider.value - 1);
				isStagePanelMove = true;
			
				pos = stagePanel.GetComponent<RectTransform> ().anchoredPosition;
				MoveStagePanel (-(selectStageNumber - 1) * 648);
				
				Debug.Log("selectStageNumber After" + selectStageNumber);
			}

			// 体験版
			if (Input.GetAxis ("Horizontal") > 0 && selectStageNumber != 10 && isStagePanelMove == false) {
				
				GetComponent<AudioSource>().PlayOneShot(SelectSound);
				
				Debug.Log("selectStageNumber Before" + selectStageNumber);

				selectStageNumber++;
				StagePanelSlider.slider.value = Mathf.RoundToInt (StagePanelSlider.slider.value + 1);
				isStagePanelMove = true;
			
				pos = stagePanel.GetComponent<RectTransform> ().anchoredPosition;
				MoveStagePanel (-(selectStageNumber - 1) * 648);

				Debug.Log("selectStageNumber After" + selectStageNumber);
			}

		}
	}

	// ボタンをクリックした時の処理
	public void OnClick() {

		// ステージ選択画面がスライド中でない、かつロック画面解除/不可能画面表示中でなければ
		if (!isStagePanelMove && !GoStageScene.isSelectLockStage && !Input.GetButtonDown ("Submit")) {
			if (this.gameObject.name == "ArrowLeft" && selectStageNumber != 1) {
				
				GetComponent<AudioSource>().PlayOneShot(SelectSound);

				selectStageNumber--;
				StagePanelSlider.slider.value = Mathf.RoundToInt(StagePanelSlider.slider.value-1);
				isStagePanelMove = true;
				
				pos = stagePanel.GetComponent<RectTransform> ().anchoredPosition;
				MoveStagePanel (-(selectStageNumber-1) * 648);
			}

			// 体験版
			if (this.gameObject.name == "ArrowRight" && selectStageNumber != 10) {
				
				GetComponent<AudioSource>().PlayOneShot(SelectSound);

				selectStageNumber++;
				StagePanelSlider.slider.value = Mathf.RoundToInt(StagePanelSlider.slider.value+1);
				isStagePanelMove = true;
				
				pos = stagePanel.GetComponent<RectTransform> ().anchoredPosition;
				MoveStagePanel (-(selectStageNumber-1) * 648);
			}

			/*
			// 製品版
			if (this.gameObject.name == "ArrowRight" && selectStageNumber != 30) {

				selectStageNumber++;
				StagePanelSlider.slider.value = Mathf.RoundToInt(StagePanelSlider.slider.value+1);
				isStagePanelMove = true;
				
				pos = stagePanel.GetComponent<RectTransform> ().anchoredPosition;
				MoveStagePanel (-(selectStageNumber-1) * 648);
			}
			*/
		}
	}

	private void MoveStagePanel(int moveStagePanel){
		// Stage画像を移動させる
		iTween.ValueTo(gameObject, iTween.Hash("from", pos.x, "to", moveStagePanel, "time", 0.6f,"easeType", "easeInOutQuad", "onupdate", "UpdateHandler", "oncomplete", "CompletedHandler", "oncompletetarget", gameObject));
	}
	
	private void UpdateHandler(float value)
	{
		// Stage画像を移動させる
		pos.x = value;
		stagePanel.GetComponent<RectTransform> ().anchoredPosition = pos;
	}

	private void CompletedHandler()
	{
		// Stage画像が動いているフラグを下げる
		isStagePanelMove = false;
	}
}
