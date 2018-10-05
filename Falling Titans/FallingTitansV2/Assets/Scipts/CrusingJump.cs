using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusingJump : MonoBehaviour
{
  public GameObject jumpHitBox;

  public float jumpForce;

  public bool touchingGround;

  public float jumpingClamp;

  public bool jumping;

  public Vector3 leftJoystick;
  public Vector3 rightJoystick;
  public Vector3 playerVelocity;

  private bool leftBumper;

  public float lastJump;

  private void Update()
  {
    Rigidbody playersRigidbody = gameObject.GetComponent<Rigidbody>();

    leftBumper = GetComponent<PlayerController>().leftBumper;
    leftJoystick = GetComponent<PlayerController>().leftJoystick;
    rightJoystick = GetComponent<PlayerController>().rightJoystick;

    touchingGround = GetComponent<PlayerController>().touchingGround;

    if (leftBumper && touchingGround)
    {
      Destroy(Instantiate(jumpHitBox, transform.position - new Vector3(0, 1, 0), transform.rotation),1);
      playersRigidbody.velocity = (transform.up + rightJoystick) * jumpForce;
      jumping = true;
      lastJump = Time.time;


    }

    if (jumping)
    {
      playersRigidbody.velocity = new Vector3
        (
        Mathf.Clamp(playersRigidbody.velocity.x + leftJoystick.x, -jumpingClamp, jumpingClamp),
        playersRigidbody.velocity.y,
        Mathf.Clamp(playersRigidbody.velocity.z + leftJoystick.z, -jumpingClamp, jumpingClamp)
        );

    } // end jumping

  } // end Update

  private void OnCollisionStay(Collision collision)
  {
    Debug.Log("Stay");

    if (collision.transform.tag == "FallingTile")
    {
      Debug.Log("fallingTile");

      if (lastJump + 2 < Time.time)
      {
        Debug.Log("JumpTime");

        jumping = false;
      }
    }
  }

}
