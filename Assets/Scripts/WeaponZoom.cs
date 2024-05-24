using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
  [SerializeField] GameObject followCamera;
  CinemachineVirtualCamera fpsCamera;
  [SerializeField] float zoomOutFOV = 40f;
  [SerializeField] float zoomInFOV = 20f;

  bool zoomedInToggle = false;

  void Start()
  {
    fpsCamera = followCamera.GetComponent<CinemachineVirtualCamera>();
  }

  void Update()
  {
    if (Input.GetMouseButtonDown(1))
    {
      if (zoomedInToggle == false)
      {
        zoomedInToggle = true;
        fpsCamera.m_Lens.FieldOfView = zoomInFOV;
      }
      else
      {
        zoomedInToggle = false;
        fpsCamera.m_Lens.FieldOfView = zoomOutFOV;
      }
    }
  }
}
