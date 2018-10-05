using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreBoardController : MonoBehaviour
{
  public Manage_Players arenaController;
  public GameObject scoreBoard;
  public GameObject[] playerScoreBoard;
  public Text[] playerNumber;
  public Text[] playerScore;

  private void Awake()
  {
    arenaController = GetComponentInParent<Manage_Players>();

  }

  private void Update()
  {
    // update player info
    for (int i = 0; i < arenaController.players.Length; i++)
    {
      if (arenaController.players[i] != null)
      {
        playerScoreBoard[i].SetActive(true);
        playerNumber[i].text = arenaController.players[i].GetComponent<CheckPlayerInputs>().playerNumber.ToString();
        playerScore[i].text = arenaController.players[i].GetComponent<CheckPlayerInputs>().score.ToString();

      }

      else
      {
        playerScoreBoard[i].SetActive(false);

      }
    }

    // show scoreboard
    if (Input.GetButtonDown("AllBackButton") && UnityEngine.SceneManagement.SceneManager.GetActiveScene().name != "PlayerSetup")
    {
      scoreBoard.SetActive(true);

    }

    if (Input.GetButtonUp("AllBackButton"))
    {
      scoreBoard.SetActive(false);

    }

  }
}
