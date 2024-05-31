using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
  [SerializeField] float intensityAmount = 3.5f;
  [SerializeField] float restoreAngle = 65f;

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      FlashlightSystem flashlight = other.GetComponentInChildren<FlashlightSystem>();
      flashlight.RestoreLightAngle(restoreAngle);
      flashlight.AddLightIntensity(intensityAmount);
      Destroy(gameObject);
    }
  }
}
