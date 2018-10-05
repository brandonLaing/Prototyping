using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushingJump : MonoBehaviour
{
  public CheckPlayerInputs playerInputs;
  public PlayerController playerController;

  public float jumpForce = 10;

  public float jumpingClamp = 10;

  public bool jumping;

  public Vector3 jumpingVelocity;

  public float lastJump;

  public bool abilityOffCooldown = true;
  public float abilityCooldownTimer = 5;

  public AudioSource mainAudioSource;
  public AudioSource playerAudioSource;

  public AudioClip end;

  private void Start()
  {
    playerInputs = GetComponent<CheckPlayerInputs>();
    playerController = GetComponent<PlayerController>();
    mainAudioSource = GameObject.FindGameObjectWithTag("MainAudioListener").GetComponent<AudioSource>();
    playerAudioSource = GetComponent<AudioSource>();
    end = (AudioClip)Resources.Load("Audio/Crushing Jump End", typeof(AudioClip));

  }

  private void Update()
  {
    Rigidbody playersRigidbody = gameObject.GetComponent<Rigidbody>();

    if (playerInputs.rightBumper && playerController.touchingGround && abilityOffCooldown)
    {
      playerAudioSource.clip = end;
      playerAudioSource.Play();
      lastJump = Time.time;
      playersRigidbody.velocity = (transform.up + playerInputs.rightJoystick) * jumpForce;
      jumping = true;
      StartCoroutine(CooldownTimer());

      foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
      {
        if (Vector3.Distance(tile.transform.position, transform.position) < 2)
        {
          if (tile.GetComponent<MapTile>())
          {
            tile.GetComponent<MapTile>().PopShrink();
            tile.GetComponent<Rigidbody>().velocity += new Vector3(0, -5, 0);

          }


        }
      }

    }

    if (jumping)
    {
      playersRigidbody.velocity = new Vector3
        (
        Mathf.Clamp(playersRigidbody.velocity.x + playerInputs.leftJoystick.x, -jumpingClamp, jumpingClamp),
        playersRigidbody.velocity.y,
        Mathf.Clamp(playersRigidbody.velocity.z + playerInputs.leftJoystick.z, -jumpingClamp, jumpingClamp)
        );
    }
  }

  private void OnCollisionStay(Collision collision)
  {
    if (collision.transform.tag == "Tile")
    {
      if (lastJump + 1 < Time.time)
      {
        jumping = false;

      }
    }
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (jumping)
    {
      GetComponent<Rigidbody>().velocity = Vector3.zero;

    }
  }

  IEnumerator CooldownTimer()
  {
    abilityOffCooldown = false;
    yield return new WaitForSeconds(5);
    abilityOffCooldown = true;

  }
}
