using UnityEngine;
using System.Collections;

public class RotateObj : MonoBehaviour {

	public float rotateTime = 1.0f;
	public int rotateAngle = 45;

	// Use this for initialization
	void Start () {
		
		// コルーチンを実行
		StartCoroutine ("RotateObject");
	}

	
	// コルーチン
	private IEnumerator RotateObject() {

		// コルーチンの処理
		iTween.RotateTo(gameObject, iTween.Hash("y", rotateAngle, "time", rotateTime));
		yield return new WaitForSeconds (6.0f);
		rotateAngle += 90;
		//if( rotateAngle ==
		StartCoroutine ("RotateObject");
	}
}
