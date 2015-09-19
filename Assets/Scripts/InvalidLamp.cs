using UnityEngine;
using System.Collections;

public class InvalidLamp : MonoBehaviour {

	public float startDilayTime = 0.0f;
	private bool isStartDilay;

	// Use this for initialization
	void Start () {
	
		isStartDilay = true;

		// 指定したコルーチンを呼び出す
		StartCoroutine("InvalidLight");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// ライトの有効/無効を繰り返すコルーチン
	IEnumerator InvalidLight(){

		if (isStartDilay) {
			yield return new WaitForSeconds(startDilayTime);
			isStartDilay = false;
		}

		// 点灯
		this.gameObject.GetComponent <MeshRenderer>().enabled = true;
		yield return new WaitForSeconds(3.00f);

		// 明滅を繰り返す
		for (int i=0; i<7; i++) {
			this.gameObject.GetComponent <MeshRenderer> ().enabled = false;
			yield return new WaitForSeconds (0.01f);
			this.gameObject.GetComponent <MeshRenderer> ().enabled = true;
			yield return new WaitForSeconds (0.01f);
		}

		// 消灯
		this.gameObject.GetComponent <MeshRenderer>().enabled = false;
		yield return new WaitForSeconds(1.50f);

		// 明滅を繰り返す
		for (int i=0; i<7; i++) {
			this.gameObject.GetComponent <MeshRenderer> ().enabled = false;
			yield return new WaitForSeconds (0.01f);
			this.gameObject.GetComponent <MeshRenderer> ().enabled = true;
			yield return new WaitForSeconds (0.01f);
		}

		StartCoroutine("InvalidLight");
	}
}
