using UnityEngine;

public class Main : MonoBehaviour
{
    public int targetFrameRate = 30;
    public int vSyncCount = 0;
    
    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        QualitySettings.vSyncCount = vSyncCount;
    }
}
