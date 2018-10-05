using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTile : MonoBehaviour
{
  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "Breakable")
    {
      gameObject.GetComponent<Rigidbody>().isKinematic = false;

      gameObject.transform.localScale = new Vector3(.7F, .7F, .7F);

    } // end if breakable

    if (collision.gameObject.tag == "Destroy")
    {
      Destroy(gameObject);

    }
  } // end OnCollisionEnter

} // end class
