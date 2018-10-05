using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class EndPlane : MonoBehaviour
{
  public Manage_Players arenaController;
  public GameObject[] endPoints;
  bool loadNextScene;
  float loadTime;

  private void Start()
  {
    arenaController = gameObject.GetComponentInParent<Manage_Players>();
    endPoints = GameObject.FindGameObjectsWithTag("EndSpawn").OrderBy(go => go.name).ToArray();

  }

  private void Update()
  {
    if (!arenaController.ableToLoad)
    {
      if (arenaController.deadPlayers.Count == arenaController.players.Length - 1)
      {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
          if (!arenaController.deadPlayers.Contains(player))
          {
            player.GetComponent<CheckPlayerInputs>().score++;

          }
        }

        arenaController.deadPlayers = new List<GameObject>();

        loadNextScene = true;
        loadTime = Time.time + 5;
        arenaController.MakeAllTilesFall();
      }
    }

    if (loadNextScene && Time.time > loadTime)
    {
      arenaController.LoadNextScene();
      loadNextScene = false;
      
    }

  }

  private void OnCollisionEnter(Collision collision)
  {
    if (collision.transform.tag == "Player")
    {
      arenaController.deadPlayers.Add(collision.gameObject);

    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      arenaController.deadPlayers.Add(other.gameObject);

    }
  }

  //private void OnTriggerStay(Collider other)
  //{
  //  if (other.transform.tag == "Player")
  //  {
  //    other.transform.position = Vector3.MoveTowards(other.transform.position, endPoints[other.GetComponent<CheckPlayerInputs>().playerNumber - 1].transform.position, 25 * Time.deltaTime);

  //  }

  //  for (int i = 0; i < arenaController.players.Length; i++)
  //  {
  //    if(arenaController.players[i] == arenaController.deadPlayers.Contains(other.gameObject))
  //    {
  //      arenaController.players[i].transform.position = endPoints[i].transform.position;
  //    }
  //  }

  //}
}
