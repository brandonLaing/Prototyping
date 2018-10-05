using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneAfterDelay : MonoBehaviour
{
  public float delayedSeconds;
  public string nextSceneName;
  private float sceneChangeTimer;

  private void Awake()
  {
    sceneChangeTimer = Time.time + delayedSeconds;

  }

  private void Update()
  {
     if (sceneChangeTimer < Time.time)
    {
      SceneManager.LoadScene(nextSceneName);

    }
  }
} // end NextSceneAfterDelay
