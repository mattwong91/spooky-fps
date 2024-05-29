using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("You got the pickup! - " + name);
      Destroy(gameObject);
    }
  }
}
