using UnityEngine;
using System.Collections;

public class InvalidScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		// 指定したコルーチンを呼び出す
		StartCoroutine("InvalidLight");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ライトの有効/無効を繰り返すコルーチン
	IEnumerator InvalidLight(){

		// 点灯
		this.gameObject.GetComponent <Light2D>().enabled = true;
		yield return new WaitForSeconds(3.00f);

		// 明滅を繰り返す
		for (int i=0; i<7; i++) {
			this.gameObject.GetComponent <Light2D> ().enabled = false;
			yield return new WaitForSeconds (0.01f);
			this.gameObject.GetComponent <Light2D> ().enabled = true;
			yield return new WaitForSeconds (0.01f);
		}

		// 消灯
		this.gameObject.GetComponent <Light2D>().enabled = false;
		yield return new WaitForSeconds(1.50f);

		StartCoroutine("InvalidLight");
	}
}
