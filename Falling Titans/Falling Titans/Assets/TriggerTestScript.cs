using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTestScript : MonoBehaviour
{

  public bool p1LeftTrigger;
  public bool p2LeftTrigger;

  private void Update()
  {

    if (Input.GetButton("NewP1LeftBumper"))
    {
      p1LeftTrigger = true;

    }

    else
    {
      p1LeftTrigger = false;
    }

    if (Input.GetButton("NewP2LeftBumper"))
    {
      p2LeftTrigger = true;

    }

    else
    {
      p2LeftTrigger = false;
    }
  }
}
