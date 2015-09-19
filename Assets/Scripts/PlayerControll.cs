using UnityEngine;
using System.Collections;
using UnitySampleAssets.CrossPlatformInput;

public class PlayerControll : MonoBehaviour {

	public float lookSmoother = 3.0f;			// a smoothing setting for camera motion
	public bool  useCurves = true;				// Mecanimでカーブ調整を使うか設定する
	// このスイッチが入っていないとカーブは使われない
	public float useCurvesHeight = 0.5f;		// カーブ補正の有効高さ（地面をすり抜けやすい時には大きくする）
	
	// 以下キャラクターコントローラ用パラメタ
	// 前進速度
	public float forwardSpeed = 7.0f;
	// 後退速度
	public float backwardSpeed = 2.0f;
	// 旋回速度
	public float rotateSpeed = 2.0f;
	// ジャンプ威力
	public float jumpPower = 3.0f; 
	// キャラクターコントローラ（Boxコライダ）の参照
	private CapsuleCollider col;
	private Rigidbody rb;
	// キャラクターコントローラ（Boxコライダ）の移動量
	private Vector3 velocity;
	// CapsuleColliderで設定されているコライダのHeiht、Centerの初期値を収める変数
	private float orgColHight;
	private Vector3 orgVectColCenter;
	Animator anim;
	
	//private GameObject cameraObject;	// メインカメラへの参照

	// 初期化
	void Start ()
	{
		// CapsuleColliderコンポーネントを取得する（カプセル型コリジョン）
		col = GetComponent<CapsuleCollider> ();
		rb  = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		//メインカメラを取得する
		//cameraObject = GameObject.FindWithTag ("MainCamera");
		// CapsuleColliderコンポーネントのHeight、Centerの初期値を保存する
		//orgColHight = col;
		orgVectColCenter = col.center;
	}
	
	// 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
	void FixedUpdate ()
	{
		float h;
		float v;

		if (Input.GetAxis ("Horizontal") > 0.1 
		    || Input.GetAxis ("Horizontal") < -0.1
		    || Input.GetAxis ("Vertical") > 0.1 
		    || Input.GetAxis ("Vertical") < -0.1) {
			h = Input.GetAxis ("Horizontal");				// 入力デバイスの水平軸をhで定義
			v = Input.GetAxis ("Vertical");				// 入力デバイスの垂直軸をvで定義
		} else {
			h = CrossPlatformInputManager.GetAxis ("Horizontal");				// 入力デバイスの水平軸をhで定義
			v = CrossPlatformInputManager.GetAxis ("Vertical") * 3;				// 入力デバイスの垂直軸をvで定義
		}
		//Debug.Log (h + "   " + v);
		//rb.useGravity = true;//ジャンプ中に重力を切るので、それ以外は重力の影響を受けるようにする



		// 以下、キャラクターの移動処理
		velocity = new Vector3 (0, 0, v);		// 上下のキー入力からZ軸方向の移動量を取得
		// キャラクターのローカル空間での方向に変換
		velocity = transform.TransformDirection (velocity);
		//以下のvの閾値は、Mecanim側のトランジションと一緒に調整する



		if (v > 0.1) {
			velocity *= forwardSpeed;		// 移動速度を掛ける
		} else if (v < -0.1) {
			velocity *= backwardSpeed;	// 移動速度を掛ける
		}
		 
		if(Input.GetButton("Fire1")){
			v /= 2.0f;
			velocity /= 3.0f;
		}
		anim.SetFloat ("Speed",v);
		// 上下のキー入力でキャラクターを移動させる
		transform.localPosition += velocity * Time.fixedDeltaTime;
		
		// 左右のキー入力でキャラクタをY軸で旋回させる
		transform.Rotate (0, h * rotateSpeed, 0);
	}

	void OnCollisionEnter(Collision coll){

		if (coll.gameObject.name == "Spotlight") {
			Debug.Log("OK");
		}
	}
	
	void OnCollisionExit(Collision coll){
		
		if (coll.gameObject.name == "Spotlight") {
			Debug.Log("NG");
		}
	}
}
