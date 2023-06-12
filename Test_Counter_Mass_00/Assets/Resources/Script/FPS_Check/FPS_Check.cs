using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Check : MonoBehaviour
{
    [Range(1, 100)]
    public int fFontSize;
    [Range(0, 1)]
    public float R, G, B;

    private float fDeltaTime = 0.0f;


    private void Awake()
    {
        GameManager.SetFPS();
    }

    void Start()
    {
        fFontSize = fFontSize == 0 ? 50 : fFontSize;
    }
    
    void Update()
    {
        fDeltaTime += (Time.unscaledDeltaTime - fDeltaTime) * 0.1f;
    }

    private void OnGUI()
    {
        int w = Screen.width;
        int h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 0.02f);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / fFontSize;     //폰트 사이즈
        style.normal.textColor = Color.green;   //원하는 색상
        float msec = fDeltaTime * 1000.0f;
        float fps = 1.0f / fDeltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
