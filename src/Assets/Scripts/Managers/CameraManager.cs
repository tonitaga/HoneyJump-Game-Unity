using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private const float TargetWidth = 2400.0f;
    private const float TargetHeight = 1000.0f;

    private float screenWidth;

    private void Awake()
    {
        CameraResize();
    }

    private void CameraResize()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = TargetWidth / TargetHeight;

        if(screenRatio >= targetRatio)
        {
            Resize();
        }
        else
        {
            float difference = targetRatio / screenRatio;
            Resize(difference);
        }
    }
    private void Resize(float difference = 1.0f)
    {
        Camera.main.orthographicSize = TargetHeight / 200 * difference;
    }

    private void FixedUpdate()
    {
        
    }
}
