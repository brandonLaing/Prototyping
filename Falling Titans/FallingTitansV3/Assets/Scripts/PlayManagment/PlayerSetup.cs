using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSetup : MonoBehaviour
{
  /** PlayerSetUp Does:
   * Author: Brandon Laing
   * This will be in control of the player set up scene. Letting them press start and load in their character
   * choose abilities, and back out of playing. After all players are ready the Manager_Players will take the 
   * created players and load them into the main part of the game. This is a combo of Manager_Player and
   * Set ControllerToPlayers.
   */

  #region Variables
  [Header("Player Set Up Variables")]
  public int numberOfPlayers;

  #region Controller Variables
  private string addController;
  private string removeController;

  public string[] playerIndex;

  [Space(20)]
  #endregion

  #region Spawning Variables
  [Header("Spawning Variables")]
  public GameObject playerChooserPrefab;
  public GameObject[] players;

  public float destroyWaitTime = 0;

  private GameObject[] spawnPoints;

  [Space(20)]
  #endregion

  #region Tags
  [Header("Tags")]
  public string spawnPointsTag = "PlayerSpawnPoint";

  #endregion

  #endregion

  private void Awake()
  {
    // initiate arrays
    playerIndex = new string[numberOfPlayers];
    players = new GameObject[numberOfPlayers];

    spawnPoints = GameObject.FindGameObjectsWithTag(spawnPointsTag).OrderBy(go => go.name).ToArray();

  }

  private void Update()
  {
    // check if start is pressed
    #region Check Start Pressed
    if (Input.GetButtonDown("P1StartButton"))
    {
      addController = "P1";

    }

    if (Input.GetButtonDown("P2StartButton"))
    {
      addController = "P2";

    }

    if (Input.GetButtonDown("P3StartButton"))
    {
      addController = "P3";

    }

    if (Input.GetButtonDown("P4StartButton"))
    {
      addController = "P4";

    }

    if (Input.GetButtonDown("P5StartButton"))
    {
      addController = "P5";

    }

    if (Input.GetButtonDown("P6StartButton"))
    {
      addController = "P6";


    }

    if (Input.GetButtonDown("P7StartButton"))
    {
      addController = "P7";

    }

    if (Input.GetButtonDown("P8StartButton"))
    {
      addController = "P8";

    }

    if (Input.GetButtonDown("P9StartButton"))
    {
      addController = "P9";

    }

    if (Input.GetButtonDown("P10StartButton"))
    {
      addController = "P10";

    }

    if (Input.GetButtonDown("P11StartButton"))
    {
      addController = "P11";

    }

    if (Input.GetButtonDown("P12StartButton"))
    {
      addController = "P12";

    }

    if (Input.GetButtonDown("P13StartButton"))
    {
      addController = "P13";

    }

    if (Input.GetButtonDown("P14StartButton"))
    {
      addController = "P14";

    }

    if (Input.GetButtonDown("P15StartButton"))
    {
      addController = "P15";

    }

    if (Input.GetButtonDown("P16StartButton"))
    {
      addController = "P16";

    }

    #endregion
    // returns a string that contains the player index to add

    // check if back is pressed
    #region Check Back Pressed
    if (Input.GetButtonDown("P1BackButton"))
    {
      removeController = "P1";

    }

    if (Input.GetButtonDown("P2BackButton"))
    {
      removeController = "P2";

    }

    if (Input.GetButtonDown("P3BackButton"))
    {
      removeController = "P3";

    }

    if (Input.GetButtonDown("P4BackButton"))
    {
      removeController = "P4";

    }

    if (Input.GetButtonDown("P5BackButton"))
    {
      removeController = "P5";

    }

    if (Input.GetButtonDown("P6BackButton"))
    {
      removeController = "P6";


    }

    if (Input.GetButtonDown("P7BackButton"))
    {
      removeController = "P7";

    }

    if (Input.GetButtonDown("P8BackButton"))
    {
      removeController = "P8";

    }

    if (Input.GetButtonDown("P9BackButton"))
    {
      removeController = "P9";

    }

    if (Input.GetButtonDown("P10BackButton"))
    {
      removeController = "P10";

    }

    if (Input.GetButtonDown("P11BackButton"))
    {
      removeController = "P11";

    }

    if (Input.GetButtonDown("P12BackButton"))
    {
      removeController = "P12";

    }

    if (Input.GetButtonDown("P13BackButton"))
    {
      removeController = "P13";

    }

    if (Input.GetButtonDown("P14BackButton"))
    {
      removeController = "P14";

    }

    if (Input.GetButtonDown("P15BackButton"))
    {
      removeController = "P15";

    }

    if (Input.GetButtonDown("P16BackButton"))
    {
      removeController = "P16";

    }

    #endregion
    // returns a string that contains the player index to remove

    // when player added != null add it to an open slot
    #region Add Player
    bool inList = false;

    if (addController != null)
    {
      for (int i = 0; i < numberOfPlayers; i++)
      {
        if (playerIndex[i] == addController)
        {
          inList = true;

        }

      }
      if (!inList)
      {
        for (int i = 0; i < numberOfPlayers; i++)
        {
          if (playerIndex[i] == null)
          {
            playerIndex[i] = addController;

            addController = null;

          }
        }
      }

      addController = null;

    }

    #endregion

    // when player remove != null add it to an open slot
    #region Remove Player
    if (removeController != null)
    {
      for (int i = 0; i < numberOfPlayers; i++)
      {
        if (playerIndex[i] == removeController)
        {
          playerIndex[i] = null;

        }
      }

      removeController = null;

    }

    #endregion

    // when there is a player to spawn, spawn it
    #region Spawn and De-spawn Players
    for (int i = 0; i < numberOfPlayers; i++)
    {
      if (playerIndex[i] != null && players[i] == null)
      {
        players[i] = Instantiate(playerChooserPrefab, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
        players[i].GetComponent<CheckPlayerInputs>().playerIndex = playerIndex[i];
        players[i].GetComponent<CheckPlayerInputs>().playerNumber = i + 1;
        players[i].GetComponent<CheckPlayerInputs>().SetNumberPlayers(numberOfPlayers);

      }

      if (playerIndex[i] == null && players[i] != null)
      {
        players[i].GetComponent<CapsuleCollider>().isTrigger = true;
        Destroy(players[i], destroyWaitTime);
        players[i] = null;

      }
    }

    #endregion

  }
}
