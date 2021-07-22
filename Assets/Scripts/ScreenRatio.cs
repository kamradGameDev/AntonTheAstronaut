using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ScreenRatio : MonoBehaviour
{
    private const float DefaultAspectRatio = 1.775f; // iPhone 5 landscape ratio
    private const float DefaultOrthographicSize = 5f;
    public Camera mainCamera;
    private void Start()
    {
        ScreenRate();
    }

    public void ScreenRate()
    {
        mainCamera.orthographicSize = DefaultOrthographicSize;
        //Debug.Log("ScreenRate");
        mainCamera.projectionMatrix = Matrix4x4.Ortho(
        -DefaultOrthographicSize * DefaultAspectRatio, 
        DefaultOrthographicSize * DefaultAspectRatio,
        -DefaultOrthographicSize, DefaultOrthographicSize,
        mainCamera.nearClipPlane, mainCamera.farClipPlane);
    }
}
