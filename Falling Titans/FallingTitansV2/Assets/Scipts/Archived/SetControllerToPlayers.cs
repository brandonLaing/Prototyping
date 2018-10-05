using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Set ControllerToPlayers Does:
 * sets player slots and saves the player number to that slot and removes it if that is needed
 * 
 */

public class SetControllerToPlayers : MonoBehaviour
{

  public string controllerAdd;
  public string controllerRemove;

  public int numberOfPlayers;

  public string[] playerSlot;

  private void Awake()
  {
    controllerAdd = null;
    controllerRemove = null;

    playerSlot = new string[numberOfPlayers];

    for (int i = 0; i < playerSlot.Length; i++)
    {
      playerSlot[i] = null;
    }
  } // end Awake

  private void Update()
  {
    #region CheckJoystickStart
    if (Input.GetButtonDown("P1StartButton"))
    {
      controllerAdd = "P1";

    }

    if (Input.GetButtonDown("P2StartButton"))
    {
      controllerAdd = "P2";

    }

    if (Input.GetButtonDown("P3StartButton"))
    {
      controllerAdd = "P3";

    }

    if (Input.GetButtonDown("P4StartButton"))
    {
      controllerAdd = "P4";

    }

    if (Input.GetButtonDown("P5StartButton"))
    {
      controllerAdd = "P5";

    }

    if (Input.GetButtonDown("P6StartButton"))
    {
      controllerAdd = "P6";


    }

    if (Input.GetButtonDown("P7StartButton"))
    {
      controllerAdd = "P7";

    }

    if (Input.GetButtonDown("P8StartButton"))
    {
      controllerAdd = "P8";

    }

    if (Input.GetButtonDown("P9StartButton"))
    {
      controllerAdd = "P9";

    }

    if (Input.GetButtonDown("P10StartButton"))
    {
      controllerAdd = "P10";

    }

    if (Input.GetButtonDown("P11StartButton"))
    {
      controllerAdd = "P11";

    }

    if (Input.GetButtonDown("P12StartButton"))
    {
      controllerAdd = "P12";

    }

    if (Input.GetButtonDown("P13StartButton"))
    {
      controllerAdd = "P13";

    }

    if (Input.GetButtonDown("P14StartButton"))
    {
      controllerAdd = "P14";

    }

    if (Input.GetButtonDown("P15StartButton"))
    {
      controllerAdd = "P15";

    }

    if (Input.GetButtonDown("P16StartButton"))
    {
      controllerAdd = "P16";

    }
    #endregion

    #region CheckJoystickBack
    if (Input.GetButtonDown("P1BackButton"))
    {
      controllerRemove = "P1";

    }

    if (Input.GetButtonDown("P2BackButton"))
    {
      controllerRemove = "P2";

    }

    if (Input.GetButtonDown("P3BackButton"))
    {
      controllerRemove = "P3";

    }

    if (Input.GetButtonDown("P4BackButton"))
    {
      controllerRemove = "P4";

    }

    if (Input.GetButtonDown("P5BackButton"))
    {
      controllerRemove = "P5";

    }

    if (Input.GetButtonDown("P6BackButton"))
    {
      controllerRemove = "P6";


    }

    if (Input.GetButtonDown("P7BackButton"))
    {
      controllerRemove = "P7";

    }

    if (Input.GetButtonDown("P8BackButton"))
    {
      controllerRemove = "P8";

    }

    if (Input.GetButtonDown("P9BackButton"))
    {
      controllerRemove = "P9";

    }

    if (Input.GetButtonDown("P10BackButton"))
    {
      controllerRemove = "P10";

    }

    if (Input.GetButtonDown("P11BackButton"))
    {
      controllerRemove = "P11";

    }

    if (Input.GetButtonDown("P12BackButton"))
    {
      controllerRemove = "P12";

    }

    if (Input.GetButtonDown("P13BackButton"))
    {
      controllerRemove = "P13";

    }

    if (Input.GetButtonDown("P14BackButton"))
    {
      controllerRemove = "P14";

    }

    if (Input.GetButtonDown("P15BackButton"))
    {
      controllerRemove = "P15";

    }

    if (Input.GetButtonDown("P16BackButton"))
    {
      controllerRemove = "P16";

    }
    #endregion


    #region SetNewSlot
    // check if controller is already in list and if it inst add it to the list
    bool inList = false;
    if (controllerAdd != null)
    {
      for (int i = 0; i < playerSlot.Length; i++)
      {
        if (playerSlot[i] == controllerAdd)
        {
          inList = true;

        }

      }

      if (!inList)
      {

        for (int i = 0; i < playerSlot.Length; i++)
        {
          if (playerSlot[i] == null)
          {

            playerSlot[i] = controllerAdd;

            controllerAdd = null;

          }

        }

      } // end if not in list

      controllerAdd = null;

    } // end if controller add doesnt = null

    #endregion

    #region RemoveSlot

    if (controllerRemove != null)
    {
      for (int i = 0; i < playerSlot.Length; i ++)
      {
        if (playerSlot[i] == controllerRemove)
        {
          playerSlot[i] = null;
        }

      }

      controllerRemove = null;
    }
    #endregion

  } // end Update

} // end SetControllerToPlayers