using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  #region ControllerVariables
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

  public string playerNumber;

  public float speed;
  public bool touchingGround;

  public Material[] playerColors;

  public GameObject frontProjectile;
  public GameObject frontProjectileTarget;

  public Transform playerTarget;
  public int playerTargetIndex = 0;

  public GameObject[] players;

  public string[] playerTags;

  private void Update()
  {
    #region Controls
    leftJoystick = Vector3.zero;
    leftJoystick.x = Input.GetAxis(playerNumber + "LeftStickX");
    leftJoystick.z = Input.GetAxis(playerNumber + "LeftStickY");

    rightJoystick = Vector2.zero;
    rightJoystick.x = Input.GetAxis(playerNumber + "RightStickX");
    rightJoystick.z = Input.GetAxis(playerNumber + "RightStickY");

    dPad = Vector2.zero;
    dPad.x = Input.GetAxis(playerNumber + "DPadX");
    dPad.y = Input.GetAxis(playerNumber + "DPadY");


    rightTrigger = Input.GetAxis(playerNumber + "RightTrigger");

    leftTrigger = Input.GetAxis(playerNumber + "LeftTrigger");

    if (Input.GetButton(playerNumber + "RightBumper"))
    {
      rightTrigger = 1;

    }

    if (Input.GetButton(playerNumber + "LeftBumper"))
    {
      leftTrigger = 1;
    }

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

    if (Input.GetButtonDown(playerNumber + "LeftBumper"))
    {
      leftBumper = true;

    } // if button down A

    else
    {
      leftBumper = false;

    }

    if (Input.GetButtonDown(playerNumber + "RightBumper"))
    {
      rightBumper = true;

    } // if button down A

    else
    {
      rightBumper = false;

    }

    if (Input.GetButton(playerNumber + "BackButton"))
    {
      backButton = true;

    } // if button down A

    else
    {
      backButton = false;

    }

    if (Input.GetButton(playerNumber + "StartButton"))
    {
      startButton = true;

    } // if button down A

    else
    {
      startButton = false;

    }

    if (Input.GetButton(playerNumber + "LeftStickClick"))
    {
      leftStickClick = true;

    } // if button down A

    else
    {
      leftStickClick = false;

    }

    if (Input.GetButton(playerNumber + "RightStickClick"))
    {
      rightStickClick = true;

    } // if button down A

    else
    {
      rightStickClick = false;

    }

    #endregion

    #region UpdateColor
    for (int i = 0; i < 4; i++)
    {
      if (transform.tag == "Player " + (i + 1))
      {
        gameObject.GetComponent<Renderer>().material = playerColors[i];

      }
    }

    #endregion

    #region Movement
    if (touchingGround)
    {
      transform.position += leftJoystick * speed * Time.deltaTime;

    }

    #endregion

    #region Projectile Targeting
    frontProjectile.transform.position = transform.position + transform.forward * 1;

    frontProjectileTarget.transform.position = frontProjectile.transform.position + transform.forward * 1;

    frontProjectileTarget.transform.position = frontProjectileTarget.transform.position + transform.right * rightJoystick.x;
    frontProjectileTarget.transform.position = frontProjectileTarget.transform.position + transform.up * rightJoystick.z;

    frontProjectile.transform.LookAt(frontProjectileTarget.transform.position);

    #endregion

    #region Choosing Target
    for (int i = 0; i < players.Length; i++)
    {
      if (playerTags[i] != transform.tag)
      {
        players[i] = GameObject.FindGameObjectWithTag(playerTags[i]);

      }

    }

    if (Input.GetButtonDown(playerNumber + "aButton"))
    {
      playerTargetIndex++;

    }

    if (Input.GetButtonDown(playerNumber + "bButton"))
    {
      playerTargetIndex--;

    }

    if (playerTargetIndex > players.Length - 1)
    {
      playerTargetIndex = 0;

    }

    if (playerTargetIndex < 0)
    {
      playerTargetIndex = players.Length - 1;

    }

    if (players[playerTargetIndex] != null)
    {
      playerTarget = players[playerTargetIndex].transform;

    }

    #endregion

    #region Looking at Target
    if (playerTarget != null)
    {
      Vector3 playerTargetVector = playerTarget.transform.position;
      playerTargetVector.y = transform.position.y;
      gameObject.transform.LookAt(playerTargetVector);

    }

    #endregion

  }

  #region Collisions
  private void OnCollisionStay(Collision collision)
  {
    if (collision.gameObject.tag == "FallingTile")
    {
      touchingGround = true;

    }

  } // end OnCollisionStay

  private void OnCollisionExit(Collision collision)
  {
    if (collision.gameObject.tag == "FallingTile")
    {
      touchingGround = false;

    }

  } // end OnCollisionExit

  #endregion

} // end PlayerController
