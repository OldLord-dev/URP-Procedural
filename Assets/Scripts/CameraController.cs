using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private InputHandler inputHandler;

    // cinemachine

    float cameraDistance;
    //public float zoom;
    CinemachineComponentBase componentBase;
    public CinemachineVirtualCamera VirtualCamera;
    void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        
        componentBase = VirtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
    }

    // Update is called once per frame
    void Update()
    {
        //CameraRotation();
        CameraZoom();
    }

    private void CameraZoom()
    {
        if (inputHandler.zoom != 0)
        {
            cameraDistance = inputHandler.zoom * 0.001f;
            if (componentBase is Cinemachine3rdPersonFollow)
            {
                (componentBase as Cinemachine3rdPersonFollow).CameraDistance -= cameraDistance;
            }
        }  
    }
}
