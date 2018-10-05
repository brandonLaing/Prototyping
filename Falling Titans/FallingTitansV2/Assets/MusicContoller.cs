using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContoller : MonoBehaviour
{
  private void Awake()
  {
    DontDestroyOnLoad(this.gameObject);

  }
}
