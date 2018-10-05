using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScipt : MonoBehaviour
{
  private void Awake()
  {
    Vector3 localScale = transform.localScale;
    GetComponent<Rigidbody>().mass = (4 / 3) * (Mathf.PI) * (localScale.x * localScale.y * localScale.z) * 2;

  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "FallingTile")
    {
      gameObject.GetComponent<SphereCollider>().isTrigger = false;
    }
  }
}
