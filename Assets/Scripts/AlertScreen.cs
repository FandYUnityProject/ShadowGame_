using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlertScreen : MonoBehaviour {

	public static bool isAlertScreen = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isAlertScreen) {
			this.gameObject.GetComponent <Image> ().enabled = true;
			isAlertScreen = true;
		} else {
			this.gameObject.GetComponent <Image> ().enabled = false;
			isAlertScreen = false;
		}
	}
}
