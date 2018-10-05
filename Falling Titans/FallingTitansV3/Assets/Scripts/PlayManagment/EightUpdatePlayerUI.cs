using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EightUpdatePlayerUI : MonoBehaviour
{
  public Image[] playerBackgrounds;

  [Header("Player One")]
  public Text playerOneAbilityOne;
  public Text playerOneAbilityTwo;

  [Header("Player Two")]
  public Text playerTwoAbilityOne;
  public Text playerTwoAbilityTwo;

  [Header("Player Three")]
  public Text playerThreeAbilityOne;
  public Text playerThreeAbilityTwo;

  [Header("Player Four")]
  public Text playerFourAbilityOne;
  public Text playerFourAbilityTwo;

  [Header("Player Five")]
  public Text playerFiveAbilityOne;
  public Text playerFiveAbilityTwo;

  [Header("Player Six")]
  public Text playerSixAbilityOne;
  public Text playerSixAbilityTwo;

  [Header("Player Seven")]
  public Text playerSevenAbilityOne;
  public Text playerSevenAbilityTwo;

  [Header("Player Eight")]
  public Text playerEightAbilityOne;
  public Text playerEightAbilityTwo;


  private PlayerSetup playerSetupScript;

  private void Awake()
  {
    playerSetupScript = GetComponent<PlayerSetup>();

  }

  private void Update()
  {
    #region Set Backgrounds
    // set up background image
    for (int i = 0; i < playerSetupScript.numberOfPlayers; i++)
    {
      if (playerSetupScript.players[i] != null)
      {
        playerBackgrounds[i].color = Color.green;

      }

      else
      {
        playerBackgrounds[i].color = Color.red;

      }
    }

    #endregion

    #region Player One Abilities
    UpdatePlayerAbilites(0, playerOneAbilityOne, playerOneAbilityTwo);

    #endregion

    #region Player Two Abilities
    UpdatePlayerAbilites(1, playerTwoAbilityOne, playerTwoAbilityTwo);

    #endregion

    #region Player Three abilites
    UpdatePlayerAbilites(2, playerThreeAbilityOne, playerThreeAbilityTwo);

    #endregion

    #region Player Four abilites
    UpdatePlayerAbilites(3, playerFourAbilityOne, playerFourAbilityTwo);

    #endregion

    UpdatePlayerAbilites(4, playerFiveAbilityOne, playerFiveAbilityTwo);

    UpdatePlayerAbilites(5, playerSixAbilityOne, playerSixAbilityTwo);

    UpdatePlayerAbilites(6, playerSevenAbilityOne, playerSevenAbilityTwo);

    UpdatePlayerAbilites(7, playerEightAbilityOne, playerEightAbilityTwo);

  } // end update

  private void UpdatePlayerAbilites(int playerNumber, Text abilityOne, Text abilityTwo)
  {
    if (playerSetupScript.players[playerNumber])
    {
      if (playerSetupScript.players[playerNumber].GetComponent<ChooseAbility>())
      {
        abilityOne.text = playerSetupScript.players[playerNumber].GetComponent<ChooseAbility>().currentAbilityOne;
        abilityTwo.text = playerSetupScript.players[playerNumber].GetComponent<ChooseAbility>().currentAbilityTwo;

      }
    }

    else
    {
      abilityOne.text = "";
      abilityTwo.text = "";
    }
  }
}
