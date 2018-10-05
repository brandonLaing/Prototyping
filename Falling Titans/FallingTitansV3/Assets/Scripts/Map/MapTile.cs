using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTile : MonoBehaviour
{
  public Vector3 localScale;
  bool doThing = false;

  private void Awake()
  {
    localScale = transform.localScale;
    GetComponent<Rigidbody>().mass = 2 * ((localScale.x * 2) * (localScale.y * .5F) * (localScale.z * 2));

    gameObject.GetComponent<Rigidbody>().isKinematic = true;

  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Breaker")
    {
      PopShrink();

    }

    if (collision.gameObject.tag == "DestroyBarier")
    {
      doThing = true;
      GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Breaker")
    {
      PopShrink();

    }

    if (other.gameObject.tag == "DestroyBarier")
    {
      doThing = true;
      GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

  }

  public void PopShrink()
  {
    gameObject.GetComponent<Rigidbody>().isKinematic = false;

    gameObject.transform.localScale = new Vector3((localScale.x / 1.1F), localScale.y, (localScale.z / 1.1F));

  }

  private void Update()
  {
    if (doThing)
    {
      if (transform.localScale.x > 0 && transform.localScale.y > 0 && transform.localScale.y > 0)
      {
        transform.localScale -= new Vector3(.01F, .01F, .01F);

      }

      else
      {
        Destroy(this.gameObject);

      }
    }
  }

}
