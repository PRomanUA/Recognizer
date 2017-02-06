using UnityEngine;
using System.Collections;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif

public class ShowScreenRect : MonoBehaviour {

    public RectTransform rectTransform;

    private ScreenRect r;
    private Canvas canvas;

    void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }


    public void OnGUI() {
        r = rectTransform.GetScreenRect(canvas);
		//UnityEditor.Handles
		//#if UNITY_EDITOR
		//UnityEditor.Handles.BeginGUI();
		//UnityEditor.Handles.DrawLine(new Vector3(r.xMin, r.yMin, 0), new Vector3(r.xMax, r.yMin, 0));
		//UnityEditor.Handles.DrawLine(new Vector3(r.xMax, r.yMin, 0), new Vector3(r.xMax, r.yMax, 0));
		//UnityEditor.Handles.DrawLine(new Vector3(r.xMax, r.yMax, 0), new Vector3(r.xMin, r.yMax, 0));
		//UnityEditor.Handles.DrawLine(new Vector3(r.xMin, r.yMax, 0), new Vector3(r.xMin, r.yMin, 0));

		//UnityEditor.Handles.EndGUI();
		//#endif
    }
}
