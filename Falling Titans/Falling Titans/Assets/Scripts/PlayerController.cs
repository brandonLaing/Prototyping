using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  #region ControllerVariables
  private Vector3 leftJoystick;
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

  public float speed;

  public float jumpDistance;

  public GameObject playerTwo;

  public bool projectilesInArea;

  public bool touchingGround;

  public GameObject boulderPrefab;

  public float projectileForce;

  private void Start()
  {
    playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");

  }

  private void Update()
  {

    #region Testing
    leftJoystick = Vector3.zero;
    leftJoystick.x = Input.GetAxis("P1LeftJoystickX");
    leftJoystick.z = Input.GetAxis("P1LeftJoystickY");

    rightJoystick = Vector3.zero;
    rightJoystick.x = Input.GetAxis("P1RightJoystickX");
    rightJoystick.z = Input.GetAxis("P1RightJoystickY");

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

    // set look at to the second players
    Vector3 playerTwoLocation = playerTwo.transform.position;
    playerTwoLocation.y = transform.position.y;
    gameObject.transform.LookAt(playerTwoLocation);

    if (touchingGround)
    {
      transform.position += leftJoystick * (speed / 100);

    }

    if (Input.GetButtonDown("P1RightBumper") && projectilesInArea)
    {
      transform.position += leftJoystick * jumpDistance;
    }

    if (Input.GetButtonDown("P1LeftBumper"))
    {
      Vector3 projectilePosition = gameObject.transform.position + (rightJoystick * 1.2F);

      var projectile = (GameObject)Instantiate(boulderPrefab, projectilePosition, transform.rotation);
      transform.LookAt(projectile.transform.position);
      projectile.transform.rotation = transform.rotation;

      projectile.transform.forward = projectile.transform.up + (projectile.transform.forward/1.2F);

      projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileForce;
    }

  } // end Update

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Breakable")
    {
      projectilesInArea = true;

    }

  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.tag == "Breakable")
    {
      projectilesInArea = false;

    }

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

} // end class  