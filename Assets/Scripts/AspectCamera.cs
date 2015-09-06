using UnityEngine;
using System.Collections;

public class AspectCamera : MonoBehaviour {

	Vector2 resolution;
	string  targetDevice;
	
	bool    enable = true;  // enable fixed aspect ratio
	Vector2 offset;     	// offset
	Vector2 scale;		    // scaling

	public Camera cam;

	private float width   = 640.0f;	// width (actual resolution)
	private float height  = 960.0f;	// height (actual resolution)
	private Rect  camRect;			// camera's rectangle

	// Use this for initialization
	void Start () {

		// 画面サイズを取得
		resolution =  new Vector2(Screen.width, Screen.height);

		// カメラのoffset, scaleを設定
		offset = new Vector2(0.0f, 0.0f);
		scale  = new Vector2(1.0f, 1.0f);

		// 現在のデバイス名を取得
		targetDevice = SystemInfo.deviceModel;
		Debug.Log ( SystemInfo.deviceModel );
	}

	
	// Update is called once per frame
	void Update () {
	
		float targetAspect;
		float curAspect;
		float ratio;
		
		if (!enable)    { return; }
		if (!cam)       { return; }

		SetEditorActualResolution(targetDevice);

		targetAspect = width / height;
		curAspect = Screen.width * 1.0f / Screen.height;
		ratio = curAspect / targetAspect;
		
		if (1.0f > ratio) {
			GetComponent<Camera>().rect = new Rect(0.0f + offset.x
			                                      ,(1.0f - ratio) / 2.0f + offset.y
			                                      ,1.0f
			                                      ,ratio);
			cam.orthographicSize = Screen.width / (2.0f * scale.x);
		}
		else {
			ratio = 1.0f / ratio;
			GetComponent<Camera>().rect = new Rect((1.0f - ratio) / 2.0f + offset.x
			                                       ,0.0f + offset.y
			                                       ,ratio
			                                       ,1.0f);
			cam.orthographicSize = Screen.height / (2.0f * scale.y);
		}
		camRect = cam.rect;
	}

	private void SetEditorActualResolution(string targetDeviceModel)
	{
		if (targetDeviceModel == "Unknown") {
			width = resolution.x;
			height = resolution.y;
		}
		else{
			SetActualResolution(targetDeviceModel);
		}
	}

	private void SetActualResolution(string targetDeviceModel)
	{
		switch (targetDeviceModel) {
		case "iPhone4S":
			width = 640.0f;
			height = 960.0f;
			break;
		case "iPhone5":
		case "iPhone5C":
		case "iPhone5S":
			width = 640.0f;
			height = 1136.0f;
			break;
		case "iPad2,1":
		case "iPad2,2":
		case "iPad2,3":
		case "iPad2,4":
			width = 768.0f;
			height = 1024.0f;
			break;
		case "iPad2,5":
		case "iPad2,6":
		case "iPad2,7":
		case "iPad3,1":
		case "iPad3,2":
		case "iPad3,3":
		case "iPad3,4":
		case "iPad3,5":
		case "iPad3,6":
			width = 1536.0f;
			height = 2048.0f;
			break;
		default:
			width = 1280.0f;
			height = 800.0f;
			break;
		}
	}

}
