using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_CheetResources : MonoBehaviour
{
  public GameObject resourceManager;
  public GameObject eventManager;


  // Update is called once per frame
  void Update ()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();
    Event_Manager_System eventManagerScript = eventManager.GetComponent<Event_Manager_System>();


    if (Input.GetKey(KeyCode.P))
    {
      resourceManagerScript.wood += 1000;

    }

    if (Input.GetKey(KeyCode.O))
    {
      resourceManagerScript.stone += 1000;

    }

    if (Input.GetKey(KeyCode.I))
    {
      resourceManagerScript.bone += 1000;

    }

    if (Input.GetKey(KeyCode.U))
    {
      resourceManagerScript.teeth += 1000;

    }

    if (Input.GetKey(KeyCode.Y))
    {
      resourceManagerScript.fur += 1000;

    }

    if (Input.GetKey(KeyCode.L))
    {
      resourceManagerScript.mBone += 1000;

    }

    if (Input.GetKey(KeyCode.K))
    {
      resourceManagerScript.mTeeth += 1000;

    }

    if (Input.GetKey(KeyCode.J))
    {
      resourceManagerScript.mPelt += 1000;

    }

    if (Input.GetKey(KeyCode.H))
    {
      resourceManagerScript.iron += 1000;

    }

    if (Input.GetKey(KeyCode.M))
    {
      resourceManagerScript.steel += 1000;

    }

    if (Input.GetKey(KeyCode.N))
    {
      resourceManagerScript.coal += 1000;

    }

    if (Input.GetKey(KeyCode.B))
    {
      resourceManagerScript.leather += 1000;

    }

    if (Input.GetKey(KeyCode.I))
    {
      resourceManagerScript.mScale += 1000;

    }

    if (Input.GetKey(KeyCode.G))
    {
      resourceManagerScript.food += 1000;

    }

    if (Input.GetKey(KeyCode.V))
    {
      resourceManagerScript.herb += 1000;

    }

    if (Input.GetKey(KeyCode.R))
    {
      resourceManagerScript.ironOre += 1000;

    }

    if (Input.GetKey(KeyCode.F))
    {
      resourceManagerScript.relic += 1000;

    }

    if (Input.GetKey(KeyCode.C))
    {
      eventManagerScript.mHuntCount += 10;
    }
  }

}
