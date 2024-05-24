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
  [SerializeField] GameObject hitEffect;
  [SerializeField] Ammo ammoSlot;
  [SerializeField] float timeBetweenShots = 0.5f;

  bool canShoot = true;

  void Update()
  {
    if (Input.GetMouseButtonDown(0) && canShoot == true)
    {
      StartCoroutine(Shoot());
    }
  }

  IEnumerator Shoot()
  {
    canShoot = false;
    if (ammoSlot.GetCurrentAmmo() > 0)
    {
      PlayMuzzleFlash();
      ProcessRaycast();
      ammoSlot.ReduceCurrentAmmo();
    }
    yield return new WaitForSeconds(timeBetweenShots);
    canShoot = true;
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
      CreateHitImpact(hit);
      EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
      if (target == null) { return; }
      target.TakeDamage(damage);
    }
    else
    {
      return;
    }
  }

  void CreateHitImpact(RaycastHit hit)
  {
    GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
    Destroy(impact, .1f);
  }
}
