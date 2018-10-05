using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/** Manager_Players Does:
 * This is responsible for spawning in the players and setting the right inputs to them.
 * 
 */

public class Manager_Player : MonoBehaviour
{
  public GameObject playerPrefab;

  public SetControllerToPlayers inputManagerScript;

  public GameObject[] playerSpawnPoints;
  public int numberOfPlayers;
  public GameObject[] players;

  public string getInputManagerTag = "GetInputManager";
  public string playerSpawnPointsTag = "PlayerSpawnPoint";


  private void Awake()
  {
    inputManagerScript = GameObject.FindGameObjectWithTag(getInputManagerTag).GetComponent<SetControllerToPlayers>();

    playerSpawnPoints = GameObject.FindGameObjectsWithTag(playerSpawnPointsTag).OrderBy(go => go.name).ToArray();

    players = new GameObject[numberOfPlayers];

    for (int i = 0; i < numberOfPlayers; i++)
    {
      players[i] = null;

    }

  } // end Awake

  private void Update()
  {
    #region Spawn and Despawn Players
    for (int i = 0; i < numberOfPlayers; i++)
    {
      if (inputManagerScript.playerSlot[i] != null && players[i] == null)
      {
        players[i] = Instantiate(playerPrefab, playerSpawnPoints[i].transform.position, playerSpawnPoints[i].transform.rotation);
        players[i].GetComponent<PlayerController>().playerNumber = inputManagerScript.playerSlot[i];
        players[i].transform.tag = ("Player " + (i + 1));

      }

      if (inputManagerScript.playerSlot[i] == null && players[i] != null)
      {
        players[i].GetComponent<CapsuleCollider>().isTrigger = true;
        Destroy(players[i], 2);
        players[i] = null;

      }
    }
    #endregion

    #region Choose Abilities

    #endregion



  }
}
