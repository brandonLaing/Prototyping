using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
  public CheckPlayerInputs playerInputs;
  public PlayerController playerController;
  public float blinkExplostion = 5;
  public GameObject tilePrefab;

  public AudioSource mainAudioSource;
  public AudioSource playerAudioSource;

  public AudioClip end;

  public bool offCooldown = true;
  public float cooldownTime = 10;

  private void Start()
  {
    playerInputs = GetComponent<CheckPlayerInputs>();
    tilePrefab = (GameObject)Resources.Load("Prefabs/HexTile", typeof(GameObject));
    playerController = GetComponent<PlayerController>();
    mainAudioSource = GameObject.FindGameObjectWithTag("MainAudioListener").GetComponent<AudioSource>();
    playerAudioSource = GetComponent<AudioSource>();
    end = (AudioClip)Resources.Load("Audio/Blink End", typeof(AudioClip));

  }

  private void Update()
  {
    if (playerInputs.rightBumper && offCooldown)
    {
      StartCoroutine(CooldownTimer());
      playerAudioSource.clip = end;
      playerAudioSource.Play();
      transform.position += playerInputs.rightJoystick * 5;
      EnclosedExplosion();

    }
  }

  private void EnclosedExplosion()
  {
    bool doExplosion = false;

    foreach (GameObject player in playerController.players)
    {
      if (Vector3.Distance(this.transform.position, player.transform.position) < 2)
      {
        doExplosion = true;

      }

    }
    if (doExplosion)
    {
      foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
      {
        if (Vector3.Distance(this.transform.position, tile.transform.position) < 2)
        {
          tile.GetComponent<MapTile>().PopShrink();
          tile.GetComponent<Rigidbody>().velocity = playerInputs.rightJoystick * blinkExplostion + new Vector3(0, 5, 0);
          tile.GetComponent<MeshCollider>().isTrigger = true;

        }
      }

      Instantiate(tilePrefab, transform.position - new Vector3(0, 1.1F, 0), transform.rotation);

    }


  }

  IEnumerator CooldownTimer()
  {
    offCooldown = false;
    yield return new WaitForSeconds(cooldownTime);
    offCooldown = true;

  }
}
