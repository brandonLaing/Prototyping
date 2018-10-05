using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Players : MonoBehaviour
{
  /** Manger_Players Does
   * This will keep track of each player and controle the game while being played
   */

  private static bool created = false;

  public GameObject[] players;
  public string[] playerTags;
  public int[] scores;
  public GameObject[] spawnPoints;


  private void Awake()
  {
    Debug.Log("Shit awoken");
    if (created)
    {
      for (int i = 0; i < players.Length; i++)
      {
        Debug.Log(i);
        players[i].transform.position = spawnPoints[i].transform.position;

      }

    }

    if (!created)
    {
      DontDestroyOnLoad(this.gameObject);
      created = true;

    }

    spawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");


  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && created && players.Length > 2)
    {
      for (int i = 0; i < players.Length; i++)
      {
        players[i] = GameObject.FindGameObjectWithTag(playerTags[i]);

        if (players[i] != null)
        {
          DontDestroyOnLoad(players[i].gameObject);

        }

      }

    }

    if (Input.GetKeyDown(KeyCode.KeypadEnter))
    {
      LoadNextScene();

    }
  }

  public void LoadNextScene()
  {
    SceneManager.LoadScene("scene_HexArena");
    SceneManager.sceneLoaded += OnSceneLoaded;

  }

  void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
  {
    Debug.Log("NewSceneLoaded: " + scene.name);
    Debug.Log(sceneMode);

    spawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");
  
    for (int i = 0; i < players.Length; i++)
    {
      if (players[i] != null)
      {
        players[i].GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        players[i].transform.position = spawnPoints[i].transform.position;

      }

    }
  }
}
