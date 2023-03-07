using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private InputHandler inputHandler;

    float cameraDistance;
    CinemachineComponentBase componentBase;
    public CinemachineVirtualCamera VirtualCamera;
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        
        componentBase = VirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }
    void Update()
    {
        CameraZoom();
    }

    private void CameraZoom()
    {
        if (inputHandler.zoom != 0)
        {
            cameraDistance = inputHandler.zoom * 0.001f;
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                Debug.Log((componentBase as Cinemachine3rdPersonFollow).CameraDistance);
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance -= cameraDistance;
            }
        }  
    }
}
