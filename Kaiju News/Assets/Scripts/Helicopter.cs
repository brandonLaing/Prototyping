using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Helicopter does:
 * This is the basic script for my helicopter player controller for Prototyping.
 * It will have a rotating blade and a raycast on the front that constantly looks at an object.
 * When W is pressed it will move forward and when S is pressed it will move backwards.
 * A and D will rotate the helicopter left and right, not moving left and right but rotating it.
 * It wont be able to move up or down. If it hits a building the player will lose control and the plane
 * will fall to the ground. When it hits the ground it will disappear and a explosion particle effect will
 * come out. The camera will not be bound by plane at all and will have free movement. If the raycast
 * hits a target named kaiju it adds the amount of time looked at up onto a meter. When the meter is at 
 * full the player is allowed to leave the level.
 */

  /** Todo:
   * == Rotating Blade
   * == W and S movement
   * == A and D rotation
   * == camera
   * != raycast : look at and check
   * != look at meter
   * != crash
   * != exit level pause
   */
public class Helicopter : MonoBehaviour
{
  // set object for inspector
  public GameObject helicopterModel;
  public GameObject helicopterBlades;
  public GameObject helicopterCamera;
  public GameObject helicopterActualCamera;
  public GameObject helicopterRaycast;

  // blade variables
  private float bladeRotationSpeed = 720F;

  // helicopter variables
  private float helicopterSpeed;
  private float helicopterMinSpeed = -10.0F;
  private float helicopterMaxSpeed = 10.0F;
  private float helicopterBaseSpeed = 0F;
  private float helicopterRotationSpeed;
  private float helicopterMinRotationSpeed = -180;
  private float helicopterMaxRotationSpeed = 180F;
  private float helicopterBaseRotationSpeed = 0F;
  private bool movingHelicopter = false;
  private bool rotatingHelicopter = false;

  // set camera variables
  private float xAxisRotationSpeed = 500.0F;
  private float yAxisRotationSpeed = 500.0F;

  private float mouseY;
  private float mouseX;

  public float maxView = 45.0F;
  public float minView = -45.0F;

  // raycast variables
  public LayerMask KaijuLayer;
  public float meterMax = 18000;
  public float meterCount = 0;

  public bool recordVideo = false;

  public bool dead = false;

    void Update()
    {
        /// rotate blades
        helicopterBlades.transform.position = new Vector3(helicopterModel.transform.position.x, helicopterModel.transform.position.y + 1F, helicopterModel.transform.position.z);
        helicopterBlades.transform.Rotate(Vector3.up, bladeRotationSpeed * Time.deltaTime);


        /// movement
        // move forward and backward
        // check if the helicopter is moving
        movingHelicopter = false;

        if (helicopterSpeed != helicopterBaseSpeed)
        {
            movingHelicopter = true;

        }

        // if W is being pressed add up move speed
        if (Input.GetKey(KeyCode.W))
        {
            helicopterSpeed += .2F;

        }

        // if S is being pressed subtract move speed 
        if (Input.GetKey(KeyCode.S))
        {
            helicopterSpeed += -.2F;

        }

        // if speed is over max or min set it to the max or min
        if (helicopterMinSpeed > helicopterSpeed)
        {
            helicopterSpeed = helicopterMinSpeed;

        }

        if (helicopterMaxSpeed < helicopterSpeed)
        {
            helicopterSpeed = helicopterMaxSpeed;
        }

        // add or subtract helicopterSpeed if the player isn't pressing the buttons
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if (helicopterSpeed > helicopterBaseSpeed)
            {
                helicopterSpeed -= .02F;
                helicopterSpeed = Mathf.Round(helicopterSpeed * 100) / 100;

            }

            if (helicopterSpeed < helicopterBaseSpeed)
            {
                helicopterSpeed += .02F;
                helicopterSpeed = Mathf.Round(helicopterSpeed * 100) / 100;

            }

        }

        // constantly move
        helicopterModel.transform.position = helicopterModel.transform.position + -helicopterModel.transform.forward * Time.deltaTime * helicopterSpeed;
        helicopterCamera.transform.position = helicopterCamera.transform.position + -helicopterModel.transform.forward * Time.deltaTime * helicopterSpeed;

        /// Rotate left or right
        // check if helicopter is rotating
        rotatingHelicopter = false;

        if (helicopterRotationSpeed != helicopterBaseRotationSpeed)
        {
            rotatingHelicopter = true;

        }

        // rotate right
        if (Input.GetKey(KeyCode.D))
        {
            helicopterRotationSpeed += 10F;


        } // end rotate right

        // rotate left
        if (Input.GetKey(KeyCode.A))
        {
            helicopterRotationSpeed -= 10F;

        }

        // if rotation speed under or over min or max set it to the min or max
        if (helicopterMinRotationSpeed > helicopterRotationSpeed)
        {
            helicopterRotationSpeed = helicopterMinRotationSpeed;

        }

        if (helicopterMaxRotationSpeed < helicopterRotationSpeed)
        {
            helicopterRotationSpeed = helicopterMaxRotationSpeed;
        }

        // add or subtract helicopter speed if the player isn't moving the helicopter
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            // remove speed if speed is above base
            if (helicopterRotationSpeed > helicopterBaseRotationSpeed)
            {
                helicopterRotationSpeed -= 10F;
                helicopterRotationSpeed = Mathf.Round(helicopterRotationSpeed * 10) / 10;
            }

            // add speed if speed is below base
            if (helicopterRotationSpeed < helicopterBaseRotationSpeed)
            {
                helicopterRotationSpeed += 10F;
                helicopterRotationSpeed = Mathf.Round(helicopterRotationSpeed * 10) / 10;

            }

            // if the speed is within .3F set it to 0
            if (helicopterRotationSpeed < helicopterBaseRotationSpeed + .3F && helicopterRotationSpeed > helicopterBaseRotationSpeed - .3F)
            {
                helicopterRotationSpeed = 0F;
            }

        }

        // if the helicopter is moving forward decrease rotation
        if (movingHelicopter)
        {
            helicopterRotationSpeed /= 1.2F;

        } // end slow rotation if moving forward

        // constantly rotate
        helicopterModel.transform.Rotate(Vector3.up, helicopterRotationSpeed * Time.deltaTime);

        ///Camera movement
        // set left and right movements
        mouseX = Input.GetAxis("Mouse X");

        helicopterCamera.transform.Rotate(Vector3.up, mouseX * xAxisRotationSpeed * Time.deltaTime, Space.World);

        // set up and down movements
        mouseY = Input.GetAxis("Mouse Y");

        float angleEulerLimit = helicopterCamera.transform.eulerAngles.x;

        // fix euler angles if they are over limit
        if (angleEulerLimit > 180)
        {
            angleEulerLimit -= 360;

        }

        if (angleEulerLimit < -180)
        {
            angleEulerLimit += 360;

        }

        // check target rotation
        float targetRotation = angleEulerLimit + mouseY * yAxisRotationSpeed * Time.deltaTime;

        // then if the target rotation is within the min/max view set new rotation
        if (targetRotation < maxView && targetRotation > minView)
        {
            helicopterCamera.transform.eulerAngles += new Vector3(mouseY * yAxisRotationSpeed * Time.deltaTime, 0, 0);

        }

        /// check raycast
        // make raycast look at monster
        helicopterRaycast.transform.LookAt(GameObject.FindGameObjectWithTag("Kaiju").transform);

        RaycastHit hitInfo;
    if (recordVideo)
    {
      if (Physics.Raycast(helicopterRaycast.transform.position, helicopterRaycast.transform.forward, out hitInfo, Vector3.Distance(GameObject.FindGameObjectWithTag("Kaiju").transform.position, helicopterRaycast.transform.position) + 20))
      {
        Debug.DrawRay(helicopterRaycast.transform.position, helicopterRaycast.transform.forward, Color.green);

        if (meterCount < meterMax)
        {
          meterCount += 1;

        }

      }
      else
      {
        Debug.DrawRay(helicopterRaycast.transform.position, helicopterRaycast.transform.forward, Color.red);


      }
    }

    if (dead)
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu_Scene");
    }

    if (meterCount == meterMax)
    {
      UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu_Scene");
    }

    

  } // end Update

  private void OnCollisionEnter(Collision collision)
  {
    Debug.Log("HELLO");

  }

} // end class
