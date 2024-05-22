using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
  [SerializeField] Camera FPCamera;
  [SerializeField] float range = 100f;
  [SerializeField] float damage = 25f;
  [SerializeField] ParticleSystem muzzleFlash;

  void Update()
  {
    if (Input.GetButtonDown("Fire1"))
    {
      Shoot();
    }
  }

  void Shoot()
  {
    PlayMuzzleFlash();
    ProcessRaycast();
  }

  void PlayMuzzleFlash()
  {
    muzzleFlash.Play();
  }

  void ProcessRaycast()
  {
    RaycastHit hit;
    bool enemyIsHit = Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
    if (enemyIsHit)
    {
      Debug.Log("I hit this thing: " + hit.transform.name);
      //TODO Add visual hit effect
      EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
      if (target == null) { return; }
      target.TakeDamage(damage);
    }
    else
    {
      return;
    }
  }
}
