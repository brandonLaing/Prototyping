using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorJump : MonoBehaviour
{
  public CheckPlayerInputs playerInputs;
  public PlayerController playerController;

  public float jumpForce = 30;

  public float lastJump;

  public Rigidbody playerRigidbody;

  public bool offCooldown = true;
  public float cooldownTimer = 10;

  public bool jumping;

  public float speed = 20;
  public bool crushingDown = false;
  public float crushingFallSpeed = 75;

  public GameObject tilePrefab;

  public AudioSource mainAudioSource;
  public AudioSource playerAudioSource;

  public AudioClip land;
  public AudioClip pushdown;
  public AudioClip start;

  private void Start()
  {
    playerInputs = GetComponent<CheckPlayerInputs>();
    playerController = GetComponent<PlayerController>();
    playerRigidbody = GetComponent<Rigidbody>();
    tilePrefab = (GameObject)Resources.Load("Prefabs/HexTile", typeof(GameObject));
    mainAudioSource = GameObject.FindGameObjectWithTag("MainAudioListener").GetComponent<AudioSource>();
    playerAudioSource = GetComponent<AudioSource>();

    start = (AudioClip)Resources.Load("Audio/Meteor Jump Start", typeof(AudioClip));
    pushdown = (AudioClip)Resources.Load("Audio/Meteor Jump Push Down", typeof(AudioClip));
    land = (AudioClip)Resources.Load("Audio/Meteor Jump Land", typeof(AudioClip));

  }

  private void Update()
  {
    if (playerInputs.rightBumper && playerController.touchingGround && offCooldown && !jumping)
    {
      lastJump = Time.time;
      playerRigidbody.velocity += transform.up * jumpForce;
      jumping = true;
      offCooldown = false;
      StartCoroutine(CooldownTimer());
      playerAudioSource.clip = start;
      playerAudioSource.Play();


    }

    if (jumping && lastJump + .1 < Time.time)
    {
      transform.position += playerInputs.leftJoystick * speed * Time.deltaTime;

      if (playerInputs.rightBumper)
      {
        playerRigidbody.velocity -= new Vector3(0, crushingFallSpeed, 0);

        crushingDown = true;

        mainAudioSource.clip = pushdown;
        mainAudioSource.Play();

      }
    }
  }

  public void OnCollisionEnter(Collision collision)
  {
    if (jumping && lastJump + .1 < Time.time)
    {
      jumping = false;
      if (crushingDown)
      {
        crushingDown = false;

        playerAudioSource.clip = land;
        playerAudioSource.Play();

        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
          if (Vector3.Distance(transform.position, tile.transform.position) < 3)
          {
            tile.GetComponent<MeshCollider>().isTrigger = true;

            Debug.Log("Found tile in jump landing zone");

            Vector3 dir = tile.transform.position - transform.position;

            dir = -dir.normalized;

            tile.GetComponent<MapTile>().PopShrink();

            playerRigidbody.velocity = new Vector3(playerRigidbody.velocity.x, 0, playerRigidbody.velocity.z);

            playerRigidbody.AddForce(dir + new Vector3(0, playerRigidbody.velocity.y * playerRigidbody.velocity.y));

          }
        }

        Instantiate(tilePrefab, transform.position - new Vector3(0, 1.1F, 0), transform.rotation);

      }

      GetComponent<Rigidbody>().velocity = Vector3.zero;


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


  IEnumerator CooldownTimer()
  {
    offCooldown = false;
    yield return new WaitForSecondsRealtime(cooldownTimer);
    offCooldown = true;

  }
}
