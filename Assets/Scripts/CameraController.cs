using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Update camera position to change based on user input
/// </summary>
public class CameraController : MonoBehaviour
{
    public delegate void SetCamerPositionHandler(Vector3 position, Vector3 direction);
    public static SetCamerPositionHandler SetCameraPosition;

    public Transform Camera;

    private void OnEnable()
    {
        SetCameraPosition += SetCamera;
    }

    private void OnDisable()
    {
        SetCameraPosition -= SetCamera;
    }

    public void SetCamera(Vector3 position, Vector3 direction)
    {
        Camera.position = position;
        Camera.LookAt(direction);
    }

}
