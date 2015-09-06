using UnityEngine;
using System.Collections;
using System.Linq;

public class TouchController : MonoBehaviour
{
	
	/// <summary>回転対象</summary>
	//public GameObject Cube;
	/// <summary>回転速度</summary>
	public float Speed = 0.01f;
	
	void Update ()
	{
		//タッチ数取得
		int touchCount = Input.touches
			.Count (t => t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled);
		
		if (touchCount == 1) {
			RaycastHit rh;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out rh)) {
				if (rh.collider.gameObject == this.gameObject) {
					Touch t = Input.touches.First ();
					switch (t.phase) {
					case TouchPhase.Moved:
				
				//移動量に応じて角度計算
				//float xAngle = t.deltaPosition.y * Speed * 10;
						float xAngle = 0;
						float yAngle = t.deltaPosition.x * Speed * 10;
						float zAngle = 0;
				
				//回転
						this.transform.Rotate (xAngle, yAngle, zAngle, Space.World);
				
						break;
					}
				}
			}
		}
	}
}