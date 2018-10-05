using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerUI : MonoBehaviour
{
  public GameObject playerSetUpManager;
  public Image[] playerImage;
  private PlayerSetUp playerSetUpScript;

  private void Awake()
  {
    playerSetUpScript = playerSetUpManager.GetComponent<PlayerSetUp>();
  }

  private void Update()
  {
    for (int i = 0; i < playerSetUpScript.players.Length; i++)
    {
      if (playerSetUpScript.players[i] != null)
      {
        playerImage[i].color = Color.green;

      }

      else
      {
        playerImage[i].color = Color.red;
      }
    }

  } // end Update

} // end UpdatePlayerUI
