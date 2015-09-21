using UnityEngine;
using System.Collections;

public class LightBall : MonoBehaviour {

	public GameObject burstObj;
	public GameObject lightBallStartPosition ;
	
	private int PlayerLayer;
	private int LightBallLayer;

	// Use this for initialization
	void Start () {
		burstObj.SetActiveRecursively (true);

		// LayerIDを取得 
		PlayerLayer    = LayerMask.NameToLayer("Player"); 
		LightBallLayer = LayerMask.NameToLayer("LightBall");
	}

	void OnTriggerEnter(Collider coll){
		if (coll.gameObject.name == "Player") {
			Debug.Log("HIT");

			// 衝突判定を無視するLayerの設定 (true: 無視する)
			Physics.IgnoreLayerCollision( PlayerLayer, LightBallLayer, true ); 

			if( !AlertScreen.isAlertScreen ) {
				AlertScreen.isAlertScreen = true;
				foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType(typeof(GameObject)))
				{
					// シーン上に存在するオブジェクトならば処理.
					if (obj.activeInHierarchy)
					{
						if( obj.name == "GateWall" ){
							iTween.MoveBy(obj, iTween.Hash("y", -12.5, "easeType", "easeInOutExpo", "time", .5));
						}
					}
				}
			}
		}
	}

	void OnCollisionEnter(Collision coll){

		if (coll.gameObject.tag == "Wall") {
			StartCoroutine("Burning");
		}
	}

	// Burningコルーチン
	IEnumerator Burning(){
		burstObj.SetActiveRecursively (false);
		burstObj.SetActiveRecursively (true);
		this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;
		yield return new WaitForSeconds(1.0f);
		this.gameObject.GetComponent<MeshRenderer>().enabled = true;
		this.transform.position = new Vector3(lightBallStartPosition.transform.position.x, lightBallStartPosition.transform.position.y,lightBallStartPosition.transform.position.z);

		// 衝突判定を無視しないLayerの設定 
		Physics.IgnoreLayerCollision( PlayerLayer, LightBallLayer, false );
	}
}
