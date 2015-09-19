﻿/*
 * MovingFloorGimmick.cs
 * 
 * 説明：移動する床(乗り物)の処理
 *      Playerが乗ると、乗り物の表情が変わり、プロペラの回転スピードが早くなる
 *      Playerが乗ると、慣性処理でPlayerも床に合わせて動く
 * 
 * --- How To Use ---
 * アタッチ：MovingFloorGimmick(gameObject)
 *
 * 制作：2015/08/15  Guttyon
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovingFloorGimmick : MonoBehaviour {

	public Vector3 moveSpeed    = Vector3.zero; // 移動スピード
	public Vector3 moveDistance = Vector3.zero; // 移動距離
	
	//moveDistanceまで動いた後に反対方向へ折り返して動くか？
	//falseだとmoveDistanceまで動いたらそこで止る
	public bool isTurn = true;
	
	private Vector3 moved            = Vector3.zero;            //移動した距離を保持
	private List<GameObject> rideObj = new List<GameObject>();  //床に乗ってるオブジェクト
	
	private GameObject cameraObject;			// カメラオブジェクト

	// Use this for initialization
	void Start () {

		// カメラオブジェクトを取得
		cameraObject = GameObject.Find ("Main Camera");
	}

	// Update is called once per frame
	void Update() {

		// 床を動かす
		float x = moveSpeed.x;
		float y = moveSpeed.y;
		float z = moveSpeed.z;
		if (moved.x >= moveDistance.x) x = 0;
		else if (moved.x + moveSpeed.x > moveDistance.x) x = moveDistance.x - moved.x;
		if (moved.y >= moveDistance.y) y = 0;
		else if (moved.y + moveSpeed.y > moveDistance.y) y = moveDistance.y - moved.y;
		if (moved.z >= moveDistance.z) z = 0;
		else if (moved.z + moveSpeed.z > moveDistance.z) z = moveDistance.z - moved.z;
		transform.Translate(x, y, z);

		//動いた距離を保存
		moved.x += Mathf.Abs(moveSpeed.x);
		moved.y += Mathf.Abs(moveSpeed.y);
		moved.z += Mathf.Abs(moveSpeed.z);

		//床の上のオブジェクトを床と連動して動かす
		foreach (GameObject gameObj in rideObj) {
			Vector3 v = gameObj.transform.position;
			gameObj.transform.position = new Vector3(v.x + x, v.y + y, v.z + z);
		}

		//折り返すか？
		if (moved.x >= moveDistance.x && moved.y >= moveDistance.y && moved.z >= moveDistance.z && isTurn) {

			moveSpeed *= -1; //逆方向へ動かす
			moved = Vector3.zero;
		}
	}
	
	void OnCollisionEnter(Collision other) {

		Debug.Log (other.gameObject);

		//床の上に乗ったオブジェクトを保存
		rideObj.Add(other.gameObject);

		// カメラを床ブロックの子オブジェクトに設定することで、画面のブレを防ぐ
		if (other.gameObject.name == "Player") {

			cameraObject.transform.parent = this.gameObject.transform;
		}
	}
	
	void OnCollisionExit(Collision other) {

		//床から離れたので削除
		rideObj.Remove(other.gameObject);

		// プロペラのスピードを元に戻し、カメラの子オブジェクト化を解除する
		if (other.gameObject.name == "Player") {

			cameraObject.transform.parent = null;

		}
	}
}
