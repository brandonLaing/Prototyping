using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  #region ControllerVariables
  public Vector2 leftJoystick;
  public Vector2 rightJoystick;
  public Vector2 dPad;

  public float leftTrigger;
  public float rightTrigger;

  public bool aButton;
  public bool bButton;
  public bool xButton;
  public bool yButton;

  public bool leftBumper;
  public bool rightBumper;
  public bool backButton;
  public bool startButton;

  public bool leftStickClick;
  public bool rightStickClick;
  #endregion

  public string playerNumber;

  private void Awake()
  {

  }

  private void Update()
  {
    #region Controls
    leftJoystick = Vector2.zero;
    leftJoystick.x = Input.GetAxis(playerNumber + "LeftStickX");
    leftJoystick.y = Input.GetAxis(playerNumber + "LeftStickY");

    rightJoystick = Vector2.zero;
    rightJoystick.x = Input.GetAxis(playerNumber + "RightStickX");
    rightJoystick.y = Input.GetAxis(playerNumber + "RightStickY");

    dPad = Vector2.zero;
    dPad.x = Input.GetAxis(playerNumber + "DPadX");
    dPad.y = Input.GetAxis(playerNumber + "DPadY");

    rightTrigger = Input.GetAxis(playerNumber + "RightTrigger");
    leftTrigger = Input.GetAxis(playerNumber + "LeftTrigger");

    if (Input.GetButton(playerNumber + "aButton"))
    {
      aButton = true;

    } // if button down A

    else
    {
      aButton = false;

    }

    if (Input.GetButton(playerNumber + "bButton"))
    {
      bButton = true;

    } // if button down A

    else
    {
      bButton = false;

    }

    if (Input.GetButton(playerNumber + "xButton"))
    {
      xButton = true;

    } // if button down A

    else
    {
      xButton = false;

    }


    if (Input.GetButton(playerNumber + "yButton"))
    {
      yButton = true;

    } // if button down A

    else
    {
      yButton = false;

    }

    if (Input.GetButton("P1LeftBumper"))
    {
      leftBumper = true;

    } // if button down A

    else
    {
      leftBumper = false;

    }

    if (Input.GetButton("P1RightBumper"))
    {
      rightBumper = true;

    } // if button down A

    else
    {
      rightBumper = false;

    }

    if (Input.GetButton("P1BackButton"))
    {
      backButton = true;

    } // if button down A

    else
    {
      backButton = false;

    }

    if (Input.GetButton("P1StartButton"))
    {
      startButton = true;

    } // if button down A

    else
    {
      startButton = false;

    }

    if (Input.GetButton("P1LeftStickClick"))
    {
      leftStickClick = true;

    } // if button down A

    else
    {
      leftStickClick = false;

    }

    if (Input.GetButton("P1RightStickClick"))
    {
      rightStickClick = true;

    } // if button down A

    else
    {
      rightStickClick = false;

    }

    #endregion

  }

} // end PlayerController
