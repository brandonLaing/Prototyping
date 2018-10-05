using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaijuScript : MonoBehaviour {
  public GameObject player;


  private void OnCollisionEnter(Collision collision)
  {
    Helicopter playerScript = player.GetComponent<Helicopter>();
    if (collision.gameObject.tag == "Player")
    {
      playerScript.dead = true;
    }

  }

}