using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StagePanelSlider : MonoBehaviour {

	public GameObject stagePanel;
	public static Slider slider;

	private Vector2 pos;

	void Start () {
		slider = this.GetComponent<Slider>();
		slider.value = 1;

		// uGUI用のpositionを取得
		pos = stagePanel.GetComponent<RectTransform> ().anchoredPosition;
	}
	
	void Update ()
	{
		if (!ArrowPush.isStagePanelMove) {

			pos.x = -(slider.value-1) * 648;
			stagePanel.GetComponent<RectTransform> ().anchoredPosition = pos;
			ArrowPush.selectStageNumber = Mathf.RoundToInt(slider.value);
			//Debug.Log(ArrowPush.selectStageNumber);
		}
	}
}
