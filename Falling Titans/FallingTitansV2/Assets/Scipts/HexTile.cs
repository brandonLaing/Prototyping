using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexTile : MonoBehaviour
{

  public bool shrink;

  public Material hexTileMaterial;

  Vector3 localScale;


  private void Awake()
  {
    localScale = transform.localScale;
    GetComponent<Rigidbody>().mass = 2 * ((localScale.x * 2) * (localScale.y * .5F) * (localScale.z * 2));

    gameObject.GetComponent<Rigidbody>().isKinematic = true;

    GetComponent<MeshRenderer>().material = hexTileMaterial;

  } // end Awake

  private void OnCollisionEnter(Collision collision)
  {
    Vector3 localScale = transform.localScale;

    if (collision.gameObject.tag == "Projectile")
    {
      ShrinkABit();
    } // if hit by projectile

    if (collision.gameObject.tag == "DestroyBarrier")
    {
      shrink = true;
    }

  } // end OnCollisionEnter

  public void ShrinkABit()
  {
    gameObject.GetComponent<Rigidbody>().isKinematic = false;

    gameObject.transform.localScale = new Vector3((localScale.x / 1.1F), (localScale.y / 1.1F), (localScale.z / 1.1F));

  }

  private void OnTriggerStay(Collider other)
  {
    Vector3 localScale = transform.localScale;

    if (other.gameObject.tag == "Projectile")
    {
      gameObject.GetComponent<Rigidbody>().isKinematic = false;

      gameObject.transform.localScale = new Vector3((localScale.x / 1.1F), (localScale.y / 1.1F), (localScale.z / 1.1F));

    } // if hit by projectile

  }

  private void Update()
  {
    Vector3 localScale = transform.localScale;

    if (localScale.x < 0)
    {
      transform.localScale = new Vector3(0, 0, 0);

      Destroy(gameObject);

    }

    if (shrink)
    {
      gameObject.transform.localScale -= new Vector3(.01F, .01F, .01F);

    }



  }

} // end class
