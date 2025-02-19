using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    private float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width;
        int h = Screen.height;
        
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = Color.white;

        Rect rect = new Rect(10, 10, w, h * 2 / 100);
        float fps = 1.0f / deltaTime;
        string text = $"FPS: {Mathf.Ceil(fps)}";
        GUI.Label(rect, text, style);
    }
}