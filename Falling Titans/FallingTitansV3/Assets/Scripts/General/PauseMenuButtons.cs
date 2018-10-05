using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuButtons : MonoBehaviour
{
  public static bool GameIsPaused = false;

  public GameObject pauseMenuUI;

  private void Update()
  {
    if (Input.GetButtonDown("AllStartButton") && SceneManager.GetActiveScene().name != "PlayerSetup" && SceneManager.GetActiveScene().name != "EightPlayerSetup")
    {
      if (GameIsPaused)
      {
        Resume();

      }

      else
      {
        Pause();

      }
    }
  }

  public void Resume()
  {
    pauseMenuUI.SetActive(false);
    Time.timeScale = 1F;
    GameIsPaused = false;

  }

  public void Pause()
  {
    pauseMenuUI.SetActive(true);
    Time.timeScale = 0F;
    GameIsPaused = true;
  }

  public void MainMenu()
  {
    Time.timeScale = 1;
    foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
    {
      Destroy(player);

    }

    SceneManager.LoadScene("MainMenu");
    Destroy(GameObject.FindGameObjectWithTag("ArenaController"));
  }
}
