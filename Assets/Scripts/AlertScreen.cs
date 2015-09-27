using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlertScreen : MonoBehaviour {

	public static bool isAlertScreen = false;

	public AudioClip AlertSound;
	private AudioSource audioSource;
	private bool isPlaySound = false;

	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource>();
		audioSource.clip = AlertSound;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (isAlertScreen) {

			this.gameObject.GetComponent <Image> ().enabled = true;
			if (!isPlaySound){
				isPlaySound = true;
				audioSource.Play ();
			}
			isAlertScreen = true;
		} else {
			audioSource.Stop ();
			isPlaySound = false;
			this.gameObject.GetComponent <Image> ().enabled = false;
			isAlertScreen = false;
		}
	}
}
