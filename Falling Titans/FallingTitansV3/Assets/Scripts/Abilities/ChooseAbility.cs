using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseAbility : MonoBehaviour
{
  private CheckPlayerInputs playerInputsScript;

  public string[] abilitiesListOne;
  public int abilitiesOneIndex = 0;
  public bool listOneResetUp = true;
  public bool listOneResetDown = true;

  public string[] abilitiesListTwo;
  public int abilitiesTwoIndex = 0;
  public bool listTwoResetUp = true;
  public bool listTwoResetDown = true;

  public bool listRestLeft = true;
  public bool listRestRight = true;

  public string currentAbilityOne;
  public string currentAbilityTwo;

  public bool onListSwitch = true;

  private void Awake()
  {
    playerInputsScript = GetComponent<CheckPlayerInputs>();

    currentAbilityOne = abilitiesListOne[0];
    currentAbilityTwo = abilitiesListTwo[0];

    onListSwitch = true;

  }

  private void Update()
  {
    // set ability One
    #region List One
    if (onListSwitch)
    {
      #region D-Pad
      // dPad up
      if (listOneResetUp)
      {
        if (playerInputsScript.dPad.y > .8F)
        {
          abilitiesOneIndex++;
          listOneResetUp = false;

          if (abilitiesOneIndex >= abilitiesListOne.Length)
          {
            abilitiesOneIndex = 0;

          }
        }

      }

      else
      {
        if (playerInputsScript.dPad.y < .3F)
        {
          listOneResetUp = true;

        }
      }

      // dPad down
      if (listOneResetDown)
      {
        if (playerInputsScript.dPad.y < -.8F)
        {
          abilitiesOneIndex--;
          listOneResetDown = false;

          if (abilitiesOneIndex < 0)
          {
            abilitiesOneIndex = abilitiesListOne.Length - 1;

          }
        }
      }

      else
      {
        if (playerInputsScript.dPad.y > -.3F)
        {
          listOneResetDown = true;
        }
      }

      #endregion

      #region Button
      // button up
      if (playerInputsScript.yButton)
      {
        abilitiesOneIndex++;

        if (abilitiesOneIndex >= abilitiesListOne.Length)
        {
          abilitiesOneIndex = 0;

        }


      }

      // button down
      if (playerInputsScript.xButton)
      {
        abilitiesOneIndex--;

        if (abilitiesOneIndex < 0)
        {
          abilitiesOneIndex = abilitiesListOne.Length - 1;

        }

      }

      #endregion

      currentAbilityOne = abilitiesListOne[abilitiesOneIndex];

    }

    #endregion

    // set ability Two
    #region List Two
    if (!onListSwitch)
    {
      #region D-Pad
      // dPad up
      if (listTwoResetUp)
      {
        if (playerInputsScript.dPad.y > .8F)
        {
          abilitiesTwoIndex++;
          listTwoResetUp = false;

          if (abilitiesTwoIndex >= abilitiesListTwo.Length)
          {
            abilitiesTwoIndex = 0;

          }
        }

      }

      else
      {
        if (playerInputsScript.dPad.y < .3F)
        {
          listTwoResetUp = true;

        }
      }

      // dPad down
      if (listTwoResetDown)
      {
        if (playerInputsScript.dPad.y < -.8F)
        {
          abilitiesTwoIndex--;
          listTwoResetDown = false;

          if (abilitiesTwoIndex < 0)
          {
            abilitiesTwoIndex = abilitiesListTwo.Length - 1;

          }
        }
      }

      else
      {
        if (playerInputsScript.dPad.y > -.3F)
        {
          listTwoResetDown = true;
        }
      }

      #endregion

      #region Button
      // button up
      if (playerInputsScript.yButton)
      {
        abilitiesTwoIndex++;

        if (abilitiesTwoIndex >= abilitiesListTwo.Length)
        {
          abilitiesTwoIndex = 0;

        }


      }

      // button down
      if (playerInputsScript.xButton)
      {
        abilitiesTwoIndex--;

        if (abilitiesTwoIndex < 0)
        {
          abilitiesTwoIndex = abilitiesListTwo.Length - 1;

        }

      }

      #endregion

      currentAbilityTwo = abilitiesListTwo[abilitiesTwoIndex];

    }

    #endregion

    // in list One
    if (onListSwitch)
    {
      #region Button to Next List
      if (playerInputsScript.aButton)
      {
        onListSwitch = !onListSwitch;

      }

      #endregion

      // dPad moves to next list
      #region D-Pad to Next List
      if (listRestRight)
      {
        if (playerInputsScript.dPad.x > .8F)
        {
          onListSwitch = !onListSwitch;
          listRestRight = false;

        }

        
      }

      else
      {
        if (playerInputsScript.dPad.x < .3F)
        {
          listRestRight = true;

        }
      }

      #endregion

    }

    // in list Two
    if (!onListSwitch)
    {
      #region Button to Previous List
      if (playerInputsScript.bButton)
      {
        onListSwitch = !onListSwitch;

      }

      #endregion

      #region D-Pad to Previous List
      if (listRestLeft)
      {
        if (playerInputsScript.dPad.x < -.8F)
        {
          onListSwitch = !onListSwitch;
          listRestLeft = false;

        }

      }

      else
      {
        if (playerInputsScript.dPad.x > -.3F)
        {
          listRestLeft = true;

        }
      }


      #endregion

    }

    // when start is pressed it adds the scripts to the player
    if (playerInputsScript.startButton)
    {
      SetScriptsToPlayer();
    }

  }

  private void SetScriptsToPlayer()
  {
    #region List One Abilities
    if (currentAbilityOne == "RockToss")
    {
      this.gameObject.AddComponent<RockToss>();

    }

    if (currentAbilityOne == "FallingRun")
    {
      this.gameObject.AddComponent<FallingRun>();

    }

    #endregion

    #region List Two Abilities
    if (currentAbilityTwo == "CrushingJump")
    {
      this.gameObject.AddComponent<CrushingJump>();

    }

    if (currentAbilityTwo == "Blink")
    {
      this.gameObject.AddComponent<Blink>();

    }

    if (currentAbilityTwo == "MeteorJump")
    {
      this.gameObject.AddComponent<MeteorJump>();

    }

    #endregion

    gameObject.GetComponent<PlayerController>().enabled = true;

    Destroy(this);

  }

}
