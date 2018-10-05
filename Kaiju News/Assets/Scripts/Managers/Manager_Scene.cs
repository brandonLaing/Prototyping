using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Manger_Scene does:
 * This script will manager the scene swaping for the game
 */
public class Manager_Scene : MonoBehaviour
{

	// Use this for initialization
	void Start ()
  {
		
	} // end Start
	
	// Update is called once per frame
	void Update ()
  {
		
	} // end Update
 
  /** SwapToMainMenu does:
   * This will move the player to the main menu when called
   */
  public void _SwapToMainMenu()
  {
    SceneManager.LoadScene("MainMenu_Scene");

  } // end SwapToMainMenu

  /** SwapToCedits does:
 * this will move the player to the credits scene
 */
  public void _SwapToCredits()
  {
    SceneManager.LoadScene("Credits_Scene");

  } // end SwapToCredits

  public void _SwapToGame()
  {
    SceneManager.LoadScene("City_Scene");

  }

  /** QuitGame does:
   * If the player clicks on this it will end the game
   */
  public void _QuitGame()
  {
    Application.Quit();
  }

} // end Manager_Scene