using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRun : MonoBehaviour
{
  public CheckPlayerInputs playerInputs;

  public float cooldownTime = 3;
  public float runTime = 1;

  public bool runAbility = false;
  public bool runOffCooldown = true;

  public AudioSource mainAudioSource;
  public AudioSource playerAudioSource;

  public AudioClip fallingRunStart;
  public AudioClip fallingRunEnd;

  private void Start()
  {
    playerInputs = GetComponentInParent<CheckPlayerInputs>();
    mainAudioSource = GameObject.FindGameObjectWithTag("MainAudioListener").GetComponent<AudioSource>();
    playerAudioSource = GetComponent<AudioSource>();
    fallingRunStart = (AudioClip)Resources.Load("Audio/Falling Run Start", typeof(AudioClip));
    fallingRunEnd = (AudioClip)Resources.Load("Audio/Falling Run End", typeof(AudioClip));


  }

  private void Update()
  {
    if (playerInputs.leftBumper && runOffCooldown)
    {
      StartCoroutine(CooldownTimer());
      StartCoroutine(DoAbility());
      playerAudioSource.clip = fallingRunStart;
      playerAudioSource.Play();


    }
  }

  IEnumerator DoAbility()
  {
    runAbility = true;
    yield return new WaitForSeconds(runTime);
    runAbility = false;
    playerAudioSource.clip = fallingRunEnd;
    playerAudioSource.Play();

  }

  IEnumerator CooldownTimer()
  {
    runOffCooldown = false;
    yield return new WaitForSeconds(cooldownTime);
    runOffCooldown = true;

  }

  private void OnCollisionExit(Collision collision)
  {
    if (collision.transform.tag == "Tile" && runAbility)
    {
      collision.gameObject.GetComponent<MapTile>().PopShrink();

    }
  }
}
