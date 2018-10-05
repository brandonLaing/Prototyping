using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneAfterDelay : MonoBehaviour
{
  public float timeDelayed;
  public string nextSceneName;

  private void Awake()
  {
    Debug.Log("Starting");
    StartCoroutine(NextScene());

  }

  IEnumerator NextScene()
  {
    Debug.Log("In NextScene");
    yield return new WaitForSeconds(timeDelayed);
    Debug.Log("Waited");
    SceneManager.LoadScene(nextSceneName);
    Debug.Log("Loaded Scene");

  }

}
