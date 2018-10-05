using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkCollider : MonoBehaviour {
  public GameObject player;


  private void OnTriggerEnter(Collider other)
  {
    Helicopter playerScript = player.GetComponent<Helicopter>();
    if (other.tag == "Player")
    {
      playerScript.recordVideo = true;
    }

  }

  private void OnTriggerExit(Collider other)
  {
    Helicopter playerScript = player.GetComponent<Helicopter>();

    if (other.tag == "Player")
    {
      playerScript.recordVideo = false;
    }

  }
}
