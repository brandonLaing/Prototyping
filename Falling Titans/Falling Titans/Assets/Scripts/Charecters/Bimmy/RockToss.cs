using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToss : MonoBehaviour
{
  public GameObject frontTarget;
  public GameObject rockPrefab;

  public float rockForce;


  private void Update()
  {
    if (Input.GetButtonDown("P1LeftBumper"))
    {
      Debug.Log("making boulder on player1");

      var rock = (GameObject)Instantiate(rockPrefab, frontTarget.transform.position, frontTarget.transform.rotation);
      rock.GetComponent<Rigidbody>().velocity = rock.transform.forward * rockForce;
    }

  }

}