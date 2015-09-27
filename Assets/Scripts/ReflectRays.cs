using UnityEngine;  
using System.Collections;

[RequireComponent (typeof(LineRenderer))]  

public class ReflectRays : MonoBehaviour
{  
	//this game object's Transform  
	private Transform goTransform;  
	//the attached line renderer  
	private LineRenderer lineRenderer;  
	
	//a ray  
	private Ray ray;  
	//a RaycastHit variable, to gather informartion about the ray's collision  
	private RaycastHit hit;  
	
	//reflection direction  
	private Vector3 inDirection;  
	
	//the number of reflections  
	public int nReflections = 2;  
	
	//the number of points at the line renderer  
	private int nPoints;
	public Material[] materials;
	public float warningTimer = 0.2f;
	public float timer = 0.01f;
	public bool  isWarning = false;

	private float PlayerDeathTime = 0.02f;
	private float DeathTimer = 0.0f;

	private GameObject playerObj;
	private GameObject startObj;
	private GameObject burstObj;

	public bool isAlertLight = false;

	public AudioClip BurstSound;


	void Awake ()
	{  
		//get the attached Transform component  
		goTransform = this.GetComponent<Transform> ();  
		//get the attached LineRenderer component  
		lineRenderer = this.GetComponent<LineRenderer> ();  
	}

	
	private GameObject[] objects;
	private bool isDestroyWall = false;

	void Start(){
		//FindGameObjectsWithTagメソッド指定のタグのインスタンスを配列で取得
		objects = GameObject.FindGameObjectsWithTag("GoalWall");
		
		playerObj = GameObject.Find ("Player");
		startObj  = GameObject.Find ("StartObj");
		burstObj  = GameObject.Find ("BurstObj");
	}
	
	// Update is called once per frame
	void Update ()
	{  
		//clamp the number of reflections between 1 and int capacity  
		nReflections = Mathf.Clamp (nReflections, 1, nReflections);  
		//cast a new ray forward, from the current attached game object position  
		ray = new Ray (goTransform.position, goTransform.forward);  
		
		//represent the ray using a line that can only be viewed at the scene tab  
		Debug.DrawRay (goTransform.position, goTransform.forward * 100, Color.magenta);  
		
		//set the number of points to be the same as the number of reflections  
		nPoints = nReflections;  
		//make the lineRenderer have nPoints  
		lineRenderer.SetVertexCount (nPoints);  
		//Set the first point of the line at the current attached game object position  
		lineRenderer.SetPosition (0, goTransform.position);  
		
		for (int i=0; i<=nReflections; i++) {  
			//If the ray hasn't reflected yet  
			if (i == 0) {  
				//Check if the ray has hit something  
				if (Physics.Raycast (ray.origin, ray.direction, out hit, 100)) {//cast the ray 100 units at the specified direction  
					//the reflection direction is the reflection of the current ray direction flipped at the hit normal  
					inDirection = Vector3.Reflect (ray.direction, hit.normal);  
					//cast the reflected ray, using the hit point as the origin and the reflected direction as the direction  
					ray = new Ray (hit.point, inDirection);  
					
					//Draw the normal - can only be seen at the Scene tab, for debugging purposes  
					Debug.DrawRay (hit.point, hit.normal * 3, Color.blue);  
					//represent the ray using a line that can only be viewed at the scene tab  
					Debug.DrawRay (hit.point, inDirection * 100, Color.magenta);  
					
					//Print the name of the object the cast ray has hit, at the console  
					//Debug.Log ("Object name: " + hit.transform.name);  

					//if the number of reflections is set to 1  
					if (nReflections == 1) {  
						//add a new vertex to the line renderer  
						lineRenderer.SetVertexCount (++nPoints);  
					}  

					// // リフレクトブロック以外は反射させない
					if (hit.transform.name != "ReflectBlock") {	
						nReflections = 0;
					} else {
						nReflections = 2;
					}

					// ライトスイッチに光を当てると黄色く光らせて特定のブロックを削除する
					if (hit.transform.name == "LightPointSwitch") {	
						this.lineRenderer.material = materials [2];

						if( !isDestroyWall ){

							isDestroyWall = true;

							//配列内のオブジェクトの数だけループ
							foreach (GameObject destroyObj in objects) {
								//オブジェクトを削除
								Destroy(destroyObj);
							}
						}

					} else {
						this.lineRenderer.material = materials [0];
					}

					// プレイヤーに光を当てると赤く光らせる
					if (hit.transform.name == "Player") {
						
						isWarning = true;
						timer = warningTimer;

						DeathTimer += Time.deltaTime;

						if( DeathTimer > PlayerDeathTime ){

							if( !GoalTouchScript.GoalTouch ){
								// 指定したコルーチンを呼び出す
								StartCoroutine("PlayerDeath");
							}
						}
					} else {
						DeathTimer = 0.0f;
					}

					if (isWarning) {
						
						this.lineRenderer.material = materials [1];
						timer -= Time.deltaTime;
						
						if (timer < 0) {
							timer = 0.0f;
							this.lineRenderer.material = materials [0];
							isWarning = false;
						}
					}

					//set the position of the next vertex at the line renderer to be the same as the hit point  
					lineRenderer.SetPosition (i + 1, hit.point);  
				}  
			} else {  
				//Check if the ray has hit something  
				if (Physics.Raycast (ray.origin, ray.direction, out hit, 100)) {//cast the ray 100 units at the specified direction  
					//the refletion direction is the reflection of the ray's direction at the hit normal  
					inDirection = Vector3.Reflect (inDirection, hit.normal);  
					//cast the reflected ray, using the hit point as the origin and the reflected direction as the direction  
					ray = new Ray (hit.point, inDirection);  
				
					//Draw the normal - can only be seen at the Scene tab, for debugging purposes  
					Debug.DrawRay (hit.point, hit.normal * 3, Color.blue);  
					//represent the ray using a line that can only be viewed at the scene tab  
					Debug.DrawRay (hit.point, inDirection * 100, Color.magenta);  
				
					//Print the name of the object the cast ray has hit, at the console  
					//Debug.Log ("Object name: " + hit.transform.name); 


					// リフレクトブロック以外は反射させない
					if (hit.transform.name != "ReflectBlock") {	
						nReflections = 0;
					} else {
						nReflections = 20;
					}

					// ライトスイッチに光を当てると黄色く光らせて特定のブロックを削除する
					if (hit.transform.name == "LightPointSwitch") {	
						this.lineRenderer.material = materials [2];
						
						if( !isDestroyWall ){
							
							isDestroyWall = true;
							
							//配列内のオブジェクトの数だけループ
							foreach (GameObject destroyObj in objects) {
								//オブジェクトを削除
								Destroy(destroyObj);
							}
						}
						
					} else {
						this.lineRenderer.material = materials [0];
					}

					// プレイヤーに光を当てると赤く光らせる
					if (hit.transform.name == "Player") {
						
						isWarning = true;
						timer = warningTimer;
						
						DeathTimer += Time.deltaTime;
						
						if( DeathTimer > PlayerDeathTime ){
							// 指定したコルーチンを呼び出す
							StartCoroutine("PlayerDeath");
						}
					} else {
						DeathTimer = 0.0f;
					}

					if (isWarning) {
						
						this.lineRenderer.material = materials [1];
						timer -= Time.deltaTime;
						
						if (timer < 0) {
							timer = 0.0f;
							this.lineRenderer.material = materials [0];
							isWarning = false;
						}
					}

					//add a new vertex to the line renderer
					lineRenderer.SetVertexCount (++nPoints);  
					//set the position of the next vertex at the line renderer to be the same as the hit point  
					lineRenderer.SetPosition (i + 1, hit.point);  

				}
			}
		}  
	} 

	// PlayerDeathコルーチン
	IEnumerator PlayerDeath(){
	
		if (!isAlertLight) {

			burstObj.SetActiveRecursively (false);
			burstObj.transform.position = new Vector3 (playerObj.transform.position.x, playerObj.transform.position.y + 0.5f, playerObj.transform.position.z);
			burstObj.SetActiveRecursively (true);
			playerObj.SetActiveRecursively (false);
			GetComponent<AudioSource>().PlayOneShot(BurstSound);
			yield return new WaitForSeconds (3.00f);
			playerObj.transform.position = new Vector3 (startObj.transform.position.x, startObj.transform.position.y, startObj.transform.position.z);
			playerObj.SetActiveRecursively (true);
		} else {

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
}  
