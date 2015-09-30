using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour {

	private GameObject playerObj;
	private GameObject startObj;
	private GameObject burstObj;
	public AudioClip BurstSound;
	public AudioClip PlayerRestartSound;
	
	void Start(){
		playerObj = GameObject.Find ("Player");
		startObj  = GameObject.Find ("StartObj");
		burstObj  = GameObject.Find ("BurstObj");
	}

	void OnCollisionEnter( Collision coll ){
		if (coll.gameObject.name == "Player") {
			StartCoroutine("PlayerDeath");
		}
	}

	// PlayerDeathコルーチン
	IEnumerator PlayerDeath(){
			
		burstObj.SetActiveRecursively (false);
		burstObj.transform.position = new Vector3 (playerObj.transform.position.x, playerObj.transform.position.y + 0.5f, playerObj.transform.position.z);
		burstObj.SetActiveRecursively (true);
		playerObj.SetActiveRecursively (false);
		GetComponent<AudioSource>().PlayOneShot(BurstSound);
		playerObj.GetComponent<Rigidbody> ().velocity = Vector3.zero;
        //av.Play();
		yield return new WaitForSeconds (3.00f);
		playerObj.transform.position = new Vector3 (startObj.transform.position.x, startObj.transform.position.y, startObj.transform.position.z);
		playerObj.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		playerObj.SetActiveRecursively (true);
		GetComponent<AudioSource>().PlayOneShot(PlayerRestartSound);
	}
}
