using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerInputs : MonoBehaviour
{

  public string playerIndex;
  public int playerNumber;

  public Material[] playerColors;

  private int numberOfPlayers;

  public int score = 0;

  #region ControllerVariables
  [Header("Controller Properties")]
  public Vector3 leftJoystick;
  public Vector3 rightJoystick;
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

  void Update ()
  {
    #region Controls
    leftJoystick = Vector3.zero;
    leftJoystick.x = Input.GetAxis(playerIndex + "LeftStickX");
    leftJoystick.z = Input.GetAxis(playerIndex + "LeftStickY");

    rightJoystick = Vector2.zero;
    rightJoystick.x = Input.GetAxis(playerIndex + "RightStickX");
    rightJoystick.z = Input.GetAxis(playerIndex + "RightStickY");

    dPad = Vector2.zero;
    dPad.x = Input.GetAxis(playerIndex + "DPadX");
    dPad.y = Input.GetAxis(playerIndex + "DPadY");


    rightTrigger = Input.GetAxis(playerIndex + "RightTrigger");

    leftTrigger = Input.GetAxis(playerIndex + "LeftTrigger");

    if (Input.GetButtonDown(playerIndex + "RightBumper"))
    {
      rightBumper = true;

    }

    else
    {
      rightBumper = false;

    }

    if (Input.GetButtonDown(playerIndex + "LeftBumper"))
    {
      leftBumper = true;

    }

    else
    {
      leftBumper = false;

    }

    if (Input.GetButtonDown(playerIndex + "aButton"))
    {
      aButton = true;

    } // if button down A

    else
    {
      aButton = false;

    }

    if (Input.GetButtonDown(playerIndex + "bButton"))
    {
      bButton = true;

    } // if button down A

    else
    {
      bButton = false;

    }

    if (Input.GetButtonDown(playerIndex + "xButton"))
    {
      xButton = true;

    } // if button down A

    else
    {
      xButton = false;

    }


    if (Input.GetButtonDown(playerIndex + "yButton"))
    {
      yButton = true;

    } // if button down A

    else
    {
      yButton = false;

    }

    if (Input.GetButtonDown(playerIndex + "BackButton"))
    {
      backButton = true;

    } // if button down A

    else
    {
      backButton = false;

    }

    if (Input.GetButtonDown(playerIndex + "StartButton"))
    {
      startButton = true;

    } // if button down A

    else
    {
      startButton = false;

    }

    if (Input.GetButtonDown(playerIndex + "LeftStickClick"))
    {
      leftStickClick = true;

    } // if button down A

    else
    {
      leftStickClick = false;

    }

    if (Input.GetButtonDown(playerIndex + "RightStickClick"))
    {
      rightStickClick = true;

    } // if button down A

    else
    {
      rightStickClick = false;

    }

    #endregion

    #region Update Color
    for (int i = 0; i < numberOfPlayers; i++)
    {
      if (playerNumber == i)
      {
        gameObject.GetComponent<Renderer>().material = playerColors[i-1];

      }
    }

    #endregion

  }

  public void SetNumberPlayers(int newNumberOfPlayers)
  {
    numberOfPlayers = newNumberOfPlayers;

  }

  public int GetNumberOfPlayers()
  {
    return numberOfPlayers;

  }
}
