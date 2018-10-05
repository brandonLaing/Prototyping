using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller_MainMenu : MonoBehaviour
{
  public string mainMenu = "MainMenu";
  public string credits = "Credits";
  public string startGame = "PlayerSetup";

  public void GoToMainMenu()
  {
    SceneManager.LoadScene(mainMenu);

  }

  public void GoToEightPlayerGame()
  {
    SceneManager.LoadScene("EightPlayerSetup");

  }

  public void GoToTestingArena()
  {
    SceneManager.LoadScene("SinglePlayerTest");

  }

  public void GoToCredits()
  {
    SceneManager.LoadScene(credits);

  }

  public void OpenOptions()
  {

  }

  public void GoToStartGame()
  {
    SceneManager.LoadScene(startGame);

  }

  public void QuitGame()
  {
    Application.Quit();

  }

}
