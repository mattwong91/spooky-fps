using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
  [SerializeField] int currentWeapon = 0;

  void Start()
  {
    SetWeaponActive();
  }

  void SetWeaponActive()
  {
    int weaponIndex = 0;
    foreach (Transform weapon in transform)
    {
      if (weaponIndex == currentWeapon)
      {
        weapon.gameObject.SetActive(true);
      }
      else
      {
        weapon.gameObject.SetActive(false);
      }
      weaponIndex++;
    }
  }

  void Update()
  {

  }
}
