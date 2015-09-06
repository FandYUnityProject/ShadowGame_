using UnityEngine;
using System.Collections;

public class MouseDragController : MonoBehaviour {
	
	private bool drag;
	private bool first = true;
	private Vector3 prevPosition;
	private Vector3 diff;

	// キャリブレーション対策
	int cary = 0;
	public Vector3 prevObjRotation;

	void Start(){
		// シーン開始時のオブジェクトの角度取得
		prevObjRotation = new Vector3 (0, this.transform.localEulerAngles.y, 0);
	}

	// Update is called once per frame
	void Update()
	{
		// ドラッグ中じゃなくてマウスが押されたら
		if (!drag && Input.GetMouseButtonDown(0))
		{
			// 対象オブジェクトの上でクリックされたかチェックして
			RaycastHit rh;
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rh))
			{
				if (rh.collider.gameObject == this.gameObject)
				{
					// 対象オブジェクトの場合は、ドラッグ中の状態にする
					drag = true;
					if( cary == 0 ){
						this.transform.rotation = Quaternion.Euler(0, prevObjRotation.y, 0);
					}
				}
			}
		}
		
		// ドラッグ中にマウスが離されたらドラッグ中を解除して処理を抜ける
		if (drag && Input.GetMouseButtonUp(0))
		{
			drag = false;
			cary = 0;
			// localEulerAnglesで取得しないと、正しい角度が取得できない
			prevObjRotation = new Vector3(0, this.transform.localEulerAngles.y, 0);
			return;
		}
		
		// ドラッグ中は
		if (drag)
		{
			if (!first)
			{
				if( cary < 2 ){
					this.transform.rotation = Quaternion.Euler(0, prevObjRotation.y, 0);
					cary++;
				}else{
					diff = Input.mousePosition - prevPosition;
					this.transform.Rotate(new Vector3(0, diff.x * 0.1f, 0));
				}
			}
			first = false;
			prevPosition = Input.mousePosition;
		}
	}
}