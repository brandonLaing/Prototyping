using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSetUp : MonoBehaviour
{

  /** PlayerSetUp Does:
   * Author: Brandon Laing
   * This will be in controle of the player set up scene. Letting them press start and load in their charecter
   * choose abilities, and back out of playing. After all players are ready the Manager_Players will take the 
   * created players and load them into the main part of the game. This is a combo of Manager_Player and
   * Set ControllerToPlayers.
   */

  #region Variables
  public int numberOfPlayers;

  #region Controller Variables
  // Privates
  private string controllerAdd = null;
  private string controllerRemove = null;

  public string[] playerNumbers;

  #endregion

  #region Spawning Variables
  // Publics
  [Header("Spawing Variables")]
  public GameObject playerPrefab;

  [Space(20)]
  //privates
  private GameObject[] playerSpawnPoints;
  public GameObject[] players;

  #endregion

  #region Tags
  [Header("Tags")]
  public string playerSpawnPointsTag = "PlayerSpawnPoint";

  #endregion

  #endregion

  // Manualy sets shit
  private void Awake()
  {
    // set up the new arrays then set all slots to null
    playerNumbers = new string[numberOfPlayers];
    players = new GameObject[numberOfPlayers];

    for (int i = 0; i < numberOfPlayers; i++)
    {
      playerNumbers[i] = null;
      players[i] = null;

    }

    // Set up Spawn Points
    playerSpawnPoints = GameObject.FindGameObjectsWithTag(playerSpawnPointsTag).OrderBy(go => go.name).ToArray();

  } // end Awake

  private void Update()
  {
    // this will check if someone presses start
    #region CheckJoyStickStart
    if (Input.GetButtonDown("P1StartButton"))
    {
      controllerAdd = "P1";

    }

    if (Input.GetButtonDown("P2StartButton"))
    {
      controllerAdd = "P2";

    }

    if (Input.GetButtonDown("P3StartButton"))
    {
      controllerAdd = "P3";

    }

    if (Input.GetButtonDown("P4StartButton"))
    {
      controllerAdd = "P4";

    }

    if (Input.GetButtonDown("P5StartButton"))
    {
      controllerAdd = "P5";

    }

    if (Input.GetButtonDown("P6StartButton"))
    {
      controllerAdd = "P6";


    }

    if (Input.GetButtonDown("P7StartButton"))
    {
      controllerAdd = "P7";

    }

    if (Input.GetButtonDown("P8StartButton"))
    {
      controllerAdd = "P8";

    }

    if (Input.GetButtonDown("P9StartButton"))
    {
      controllerAdd = "P9";

    }

    if (Input.GetButtonDown("P10StartButton"))
    {
      controllerAdd = "P10";

    }

    if (Input.GetButtonDown("P11StartButton"))
    {
      controllerAdd = "P11";

    }

    if (Input.GetButtonDown("P12StartButton"))
    {
      controllerAdd = "P12";

    }

    if (Input.GetButtonDown("P13StartButton"))
    {
      controllerAdd = "P13";

    }

    if (Input.GetButtonDown("P14StartButton"))
    {
      controllerAdd = "P14";

    }

    if (Input.GetButtonDown("P15StartButton"))
    {
      controllerAdd = "P15";

    }

    if (Input.GetButtonDown("P16StartButton"))
    {
      controllerAdd = "P16";

    }
    #endregion

    // This will check if someone presses back
    #region CheckJoystickBack
    if (Input.GetButtonDown("P1BackButton"))
    {
      controllerRemove = "P1";

    }

    if (Input.GetButtonDown("P2BackButton"))
    {
      controllerRemove = "P2";

    }

    if (Input.GetButtonDown("P3BackButton"))
    {
      controllerRemove = "P3";

    }

    if (Input.GetButtonDown("P4BackButton"))
    {
      controllerRemove = "P4";

    }

    if (Input.GetButtonDown("P5BackButton"))
    {
      controllerRemove = "P5";

    }

    if (Input.GetButtonDown("P6BackButton"))
    {
      controllerRemove = "P6";


    }

    if (Input.GetButtonDown("P7BackButton"))
    {
      controllerRemove = "P7";

    }

    if (Input.GetButtonDown("P8BackButton"))
    {
      controllerRemove = "P8";

    }

    if (Input.GetButtonDown("P9BackButton"))
    {
      controllerRemove = "P9";

    }

    if (Input.GetButtonDown("P10BackButton"))
    {
      controllerRemove = "P10";

    }

    if (Input.GetButtonDown("P11BackButton"))
    {
      controllerRemove = "P11";

    }

    if (Input.GetButtonDown("P12BackButton"))
    {
      controllerRemove = "P12";

    }

    if (Input.GetButtonDown("P13BackButton"))
    {
      controllerRemove = "P13";

    }

    if (Input.GetButtonDown("P14BackButton"))
    {
      controllerRemove = "P14";

    }

    if (Input.GetButtonDown("P15BackButton"))
    {
      controllerRemove = "P15";

    }

    if (Input.GetButtonDown("P16BackButton"))
    {
      controllerRemove = "P16";

    }
    #endregion

    // if a controller is added put it in an open slot
    #region SetNewSlot
    bool inList = false;
    if (controllerAdd != null)
    {
      for (int i = 0; i < playerNumbers.Length; i++)
      {
        if (playerNumbers[i] == controllerAdd)
        {
          inList = true;

        }

      }

      if (!inList)
      {

        for (int i = 0; i < playerNumbers.Length; i++)
        {
          if (playerNumbers[i] == null)
          {

            playerNumbers[i] = controllerAdd;

            controllerAdd = null;

          }

        }

      } // end if not in list

      controllerAdd = null;

    } // end if controller add doesnt = null

    #endregion

    // if a controller is being removed check each slot then if it matches remove it.
    #region RemoveSlot
    if (controllerRemove != null)
    {
      for (int i = 0; i < playerNumbers.Length; i++)
      {
        if (playerNumbers[i] == controllerRemove)
        {
          playerNumbers[i] = null;
        }

      }

      controllerRemove = null;
    }

    #endregion

    // when players are added or removed spawn or despawn them onto the screen for the players to see
    #region Spawn and Despawn Players
    for (int i = 0; i < numberOfPlayers; i++)
    {
      if (playerNumbers[i] != null && players[i] == null)
      {
        players[i] = Instantiate(playerPrefab, playerSpawnPoints[i].transform.position, playerSpawnPoints[i].transform.rotation);
        players[i].GetComponent<PlayerController>().playerNumber = playerNumbers[i];
        players[i].transform.tag = ("Player " + (i + 1));

      }

      if (playerNumbers[i] == null && players[i] != null)
      {
        players[i].GetComponent<CapsuleCollider>().isTrigger = true;
        Destroy(players[i], 2);
        players[i] = null;

      }
    }
    #endregion

    // in this it will allow the players to choose what abilites they want
    #region Choose Abilities


    #endregion


  } // end Update

} // end PlayerSetUp
