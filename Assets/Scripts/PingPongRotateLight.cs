using UnityEngine;
using System.Collections;

public class PingPongRotateLight : MonoBehaviour {
	
	public float speed   = 2.0f;
	public float offset  = 30.0f;
	public float startRotate = 1.0f;	// 6.29f = 1往復

	private Vector3 prevObjRotation;

	// Use this for initialization
	void Start () {
	
		// ゲーム開始時の回転角度を保存しておく
		prevObjRotation = new Vector3(this.transform.localEulerAngles.x
		                            , this.transform.localEulerAngles.y
		                            , this.transform.localEulerAngles.z);
	}
	
	// Update is called once per frame
	void Update () {
		// 往復回転
		this.transform.rotation = Quaternion.Euler(prevObjRotation.x + Mathf.Sin( ( Time.time + startRotate ) * speed ) * offset, 
		                                           prevObjRotation.y, //+ Mathf.Sin( ( Time.time + startRotate ) * speed ) * offset, 
		                                           prevObjRotation.z);
	}
}
