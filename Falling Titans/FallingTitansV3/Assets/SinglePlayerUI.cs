using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SinglePlayerUI : MonoBehaviour
{
  public GameObject player;
  public Text abilityOneText;
  public Text abilityTwoText;

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");

  }

  private void Update()
  {
    if (player.GetComponent<ChooseAbility>())
    {
      abilityOneText.text = player.GetComponent<ChooseAbility>().currentAbilityOne;
      abilityTwoText.text = player.GetComponent<ChooseAbility>().currentAbilityTwo;
    }
  }

  public void BackToMainMenu()
  {
    SceneManager.LoadScene("MainMenu");

  }
}
