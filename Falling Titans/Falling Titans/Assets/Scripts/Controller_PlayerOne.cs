using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_PlayerOne : MonoBehaviour
{
  // variables for controller controls
  #region ControllerVariables
  public Vector3 leftJoystick;
  private Vector3 rightJoystick;
  private Vector3 dPad;

  private float leftTrigger;
  private float rightTrigger;

  private bool AButton;
  private bool BButton;
  private bool XButton;
  private bool YButton;

  private bool leftBumper;
  private bool rightBumper;

  private bool backButton;
  private bool startButton;

  private bool leftStickClick;
  private bool rightStickClick;
  #endregion

  // movement variables
  public float speed;
  public float jumpDistance;

  public bool projectilesInArea;
  public bool touchingGround;

  // Verses variables
  public GameObject playerTwo;

  // target variable
  public GameObject frontProjectile;
  public GameObject frontProjectileTarget;

  private void Awake()
  {
    // finds player two
    playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");

  }

  private void Update()
  {
    #region Controls
    leftJoystick = Vector3.zero;
    leftJoystick.x = Input.GetAxis("P1LeftJoystickX");
    leftJoystick.z = Input.GetAxis("P1LeftJoystickY");

    rightJoystick = Vector3.zero;
    rightJoystick.x = Input.GetAxis("P1RightJoystickX");
    rightJoystick.y = Input.GetAxis("P1RightJoystickY");

    dPad = Vector3.zero;
    dPad.x = Input.GetAxis("P1D-PadX");
    dPad.z = Input.GetAxis("P1D-PadY");

    rightTrigger = Input.GetAxis("P1RightTrigger");
    leftTrigger = Input.GetAxis("P1LeftTrigger");

    if (Input.GetButton("P1AButton"))
    {
      AButton = true;

    } // if button down A

    else
    {
      AButton = false;

    }

    if (Input.GetButton("P1BButton"))
    {
      BButton = true;

    } // if button down A

    else
    {
      BButton = false;

    }

    if (Input.GetButton("P1XButton"))
    {
      XButton = true;

    } // if button down A

    else
    {
      XButton = false;

    }


    if (Input.GetButton("P1YButton"))
    {
      YButton = true;

    } // if button down A

    else
    {
      YButton = false;

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

    Vector3 playerTwoTargetLocation = playerTwo.transform.position;
    playerTwoTargetLocation.y = transform.position.y;
    gameObject.transform.LookAt(playerTwoTargetLocation);



    // look at other player if your touching the ground
    if (touchingGround)
    {

      transform.position += leftJoystick * (speed / 100);

    }

    frontProjectile.transform.position = transform.position + transform.forward * 1;

    frontProjectileTarget.transform.position = frontProjectile.transform.position + transform.forward * 1;

    frontProjectileTarget.transform.position = frontProjectileTarget.transform.position + transform.up * Input.GetAxis("P1RightJoystickY");
    frontProjectileTarget.transform.position = frontProjectileTarget.transform.position + transform.right * Input.GetAxis("P1RightJoystickX");

    frontProjectile.transform.LookAt(frontProjectileTarget.transform.position);

  }
  

  private void OnCollisionStay(Collision collision)
  {
    if (collision.gameObject.tag == "FallingTile")
    {
      touchingGround = true;
    }

  }

  private void OnCollisionExit(Collision collision)
  {
    if (collision.gameObject.tag == "FallingTile")
    {
      touchingGround = false;
    }
  }

}
