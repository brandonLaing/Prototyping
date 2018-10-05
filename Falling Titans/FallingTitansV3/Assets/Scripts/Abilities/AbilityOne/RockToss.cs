using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToss : MonoBehaviour
{
  public CheckPlayerInputs playerInputs;

  public GameObject shootPoint;

  public GameObject rockPrefab;

  public float rockForece = 10;

  public AudioSource mainAudioSource;
  public AudioSource playerAudioSource;

  public AudioClip start;


  private void Start()
  {
    shootPoint = GetComponent<PlayerController>().shootTransform;
    playerInputs = GetComponentInParent<CheckPlayerInputs>();
    rockPrefab = (GameObject)Resources.Load("Prefabs/Rock", typeof(GameObject));

    mainAudioSource = GameObject.FindGameObjectWithTag("MainAudioListener").GetComponent<AudioSource>();
    playerAudioSource = GetComponent<AudioSource>();

    start = (AudioClip)Resources.Load("Audio/Rock Toss Start", typeof(AudioClip));

  }

  private void Update()
  {
    if (playerInputs.leftBumper)
    {
      GameObject rock = Instantiate(rockPrefab, shootPoint.transform.position, shootPoint.transform.rotation);
      rock.GetComponent<Rigidbody>().velocity = rock.transform.forward * rockForece;

      Destroy(rock, 10);

      playerAudioSource.clip = start;
      playerAudioSource.Play();

    }
  }
}
