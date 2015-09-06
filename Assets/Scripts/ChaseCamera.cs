using UnityEngine;
using System.Collections;


public class ChaseCamera : MonoBehaviour
{
	public float smooth = 3f;
	Transform standardPos;

	void Start()
	{
		standardPos = GameObject.Find ("cCamPos").transform;

		transform.position = standardPos.position;	
		transform.forward = standardPos.forward;	
	}
	
	
	void FixedUpdate ()	
	{
			setCameraPositionNormalView();
	}
	
	void setCameraPositionNormalView()
	{
			transform.position = Vector3.Lerp(transform.position, standardPos.position, Time.fixedDeltaTime * smooth);	
			transform.forward = Vector3.Lerp(transform.forward, standardPos.forward, Time.fixedDeltaTime * smooth);
	}

}
