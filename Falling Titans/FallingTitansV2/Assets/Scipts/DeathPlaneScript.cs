using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlaneScript : MonoBehaviour
{
  public string[] playerTags;
  public GameObject[] tiles;
  public float randomMax;
  private float loadNextTime;
  private bool loadNewScene;

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha0))
    {
      MakeAllTilesFall();
    }

    if (loadNextTime < Time.time && loadNewScene)
    {
      loadNewScene = false;
      GameObject managerPlayers = GameObject.FindGameObjectWithTag("PlayerGameManager");
      managerPlayers.GetComponent<Manager_Players>().LoadNextScene();
    }


  }
  private void OnCollisionEnter(Collision collision)
  {
    for (int i = 0; i < 2; i++)
    {
      if (collision.transform.tag == playerTags[i])
      {
        MakeAllTilesFall();
      }

    }

  }

  private void MakeAllTilesFall()
  {
    Debug.Log("TilesFalling");
    tiles = GameObject.FindGameObjectsWithTag("FallingTile");
    loadNextTime = Time.time + 5;
    loadNewScene = true;

    for (int i = 0; i < tiles.Length; i++)
    {
      if (tiles[i] != null)
      {
        tiles[i].GetComponent<Rigidbody>().isKinematic = false;
        tiles[i].GetComponent<HexTile>().ShrinkABit();
        tiles[i].GetComponent<Rigidbody>().velocity = new Vector3(UnityEngine.Random.Range(-randomMax, randomMax), UnityEngine.Random.Range(-randomMax, randomMax), UnityEngine.Random.Range(-randomMax, randomMax));

      }
    }
  }
}
