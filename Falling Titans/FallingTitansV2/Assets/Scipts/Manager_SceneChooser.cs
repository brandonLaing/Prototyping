using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_SceneChooser : MonoBehaviour {

  public string mainMenuScene = "scene_MainMenu";
  public string creditsScene = "scene_Credits";
  public string startGameScene;

  public void _GoToMainMenu()
  {
    SceneManager.LoadScene(mainMenuScene);

  } // _GoToMainMenu

  public void _GoToCredits()
  {
    SceneManager.LoadScene(creditsScene);

  } // end _GoToCredits

  public void _GoToStartGame()
  {
    SceneManager.LoadScene(startGameScene);

  } // end _GoToStartGame

  public void _QuitGame()
  {
    Application.Quit();

  } // end _QuitGame

}
