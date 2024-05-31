using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
  [SerializeField] Canvas damageCanvas;
  [SerializeField] float vfxDuration = 0.3f;
  // Start is called before the first frame update
  void Start()
  {
    damageCanvas.enabled = false;
  }

  public void DisplayDamageEffect()
  {
    StartCoroutine(ShowSplatter());
  }

  IEnumerator ShowSplatter()
  {
    damageCanvas.enabled = true;
    yield return new WaitForSeconds(vfxDuration);
    damageCanvas.enabled = false;
  }
}
