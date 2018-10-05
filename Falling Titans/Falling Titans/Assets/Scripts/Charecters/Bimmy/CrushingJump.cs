using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingJump : MonoBehaviour
{
  public GameObject jumpHitBox;

  public float rightTrigger;
  public float jumpForce;
  public bool touchingGround;
  public bool jumping;
  public Vector3 leftJoystick;
  public Vector3 rightJoystick;
  public Vector3 playersVelocity;

  public float jumpingVelocityClamp;

  private void Update()
  {
    Rigidbody playersRigidboy = gameObject.GetComponent<Rigidbody>();

    rightTrigger = Input.GetAxis("P1RightTrigger");
    leftJoystick = Vector3.zero;
    leftJoystick.x = Input.GetAxis("P1LeftJoystickX");
    leftJoystick.z = Input.GetAxis("P1LeftJoystickY");

    rightJoystick = Vector3.zero;
    rightJoystick.x = Input.GetAxis("P1RightJoystickX");
    rightJoystick.z = Input.GetAxis("P1RightJoystickY");

    if (rightTrigger > .90F && touchingGround)
    {
      playersRigidboy.velocity = (transform.up + rightJoystick) * jumpForce;
      jumping = true;
      Instantiate(jumpHitBox, transform.position - new Vector3(0, 1, 0), transform.rotation);


    }

    if (jumping)
    {
      playersRigidboy.velocity = new Vector3
        (
        Mathf.Clamp(playersRigidboy.velocity.x + leftJoystick.x, -jumpingVelocityClamp, jumpingVelocityClamp), 
        playersRigidboy.velocity.y, 
        Mathf.Clamp(playersRigidboy.velocity.z + leftJoystick.z, -jumpingVelocityClamp, jumpingVelocityClamp)
        );

    }

    playersVelocity = playersRigidboy.velocity;

  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.tag == "FallingTile")
    {
      jumping = false;
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


}
