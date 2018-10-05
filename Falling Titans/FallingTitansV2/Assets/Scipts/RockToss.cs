using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToss : MonoBehaviour
{
  private string playerNumber;

  private GameObject frontTarget;

  public GameObject rockPrefab;
  public float rockForce;

  public bool rightBumper;

  private void Awake()
  {
    frontTarget = GetComponent<PlayerController>().frontProjectile;

  }

  private void Update()
  {
    rightBumper = GetComponent<PlayerController>().rightBumper;

    if (rightBumper)
    {
      GameObject rock = Instantiate(rockPrefab, frontTarget.transform.position, frontTarget.transform.rotation);
      rock.GetComponent<Rigidbody>().velocity = rock.transform.forward * rockForce;
      Destroy(rock, 10);


    }

  }

}
