using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyThis : MonoBehaviour
{
  private void Awake()
  {
    GameObject[] tempArray = GameObject.FindGameObjectsWithTag("MainAudioListener");

    if (tempArray.Length > 1)
    {
      foreach (GameObject obj in GameObject.FindGameObjectsWithTag("MainAudioListener"))
      {
        if (obj == this.gameObject)
        {
          Destroy(obj);

        }
      }

    }

    else
    {
      DontDestroyOnLoad(this.gameObject);

    }


  }
}
