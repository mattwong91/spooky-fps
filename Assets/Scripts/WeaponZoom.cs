using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using StarterAssets;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
  [SerializeField] CinemachineVirtualCamera fpsCamera;
  [SerializeField] FirstPersonController fpsController;
  [SerializeField] float zoomOutFOV = 40f;
  [SerializeField] float zoomInFOV = 20f;
  [SerializeField] float zoomOutSensitivity = 5f;
  [SerializeField] float zoomInSensitivity = 2f;

  bool zoomedInToggle = false;

  void Update()
  {
    if (Input.GetMouseButtonDown(1))
    {
      if (zoomedInToggle == false)
      {
        zoomedInToggle = true;
        fpsCamera.m_Lens.FieldOfView = zoomInFOV;
        fpsController.RotationSpeed = zoomInSensitivity;
      }
      else
      {
        zoomedInToggle = false;
        fpsCamera.m_Lens.FieldOfView = zoomOutFOV;
        fpsController.RotationSpeed = zoomOutSensitivity;
      }
    }
  }
}
