using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Button_Mine_Manager : MonoBehaviour
{
  // set resource manager object
  public GameObject resourceManager;

  // get buttons for color
  public Button mineIronButton;
  public Button mineCoalButton;
  public Button exploreRuinsButton;
  public Button expandMineButton;
  public Button performRitualButton;
  public Button smeltIron;
  public Button makeSteel;

  // set cooldown lengths
  public int mineIronCooldownLength = 1;
  public int mineCoalCooldownLength = 1;
  public int exploreRuinsCooldownLength = 1;
  public int expandMineCooldownLength = 1;
  public int performRitualCooldownLength = 1;

  // set button colors for mineIron
  private ColorBlock mineIronColorGreen;
  private ColorBlock mineIronColorRed;

  // set button colors for mineCoal
  private ColorBlock mineCoalColorGreen;
  private ColorBlock mineCoalColorRed;

  // set button colors for exploreRuins
  private ColorBlock exploreRuinsColorGreen;
  private ColorBlock exploreRuinsColorRed;

  // set button colors for expandMine
  private ColorBlock expandMineColorGreen;
  private ColorBlock expandMineColorRed;

  // set button colors for performRitual
  private ColorBlock performRitualColorGreen;
  private ColorBlock performRitualColorRed;

  // set cooldown timers
  private float mineIronCooldownTimer;
  private float mineCoalCooldownTimer;
  private float exploreRuinsCooldownTimer;
  private float expandMineCooldownTimer;
  private float performRitualCooldownTimer;

  // set cooldown bools
  private bool mineIronOffCooldown = true;
  private bool mineCoalOffCooldown = true;
  private bool exploreRuinsOffCooldown = true;
  private bool expandMineOffCooldown = true;
  private bool performmRitualOffCooldown = true;

  // Use this for initialization
  void Start ()
  {
    // set start timers
    mineIronCooldownTimer = Time.time;
    mineCoalCooldownTimer = Time.time;
    exploreRuinsCooldownTimer = Time.time;
    expandMineCooldownTimer = Time.time;
    performRitualCooldownTimer = Time.time;

    if (true)
    {
      // set up mineIron button colors
      mineIronButton = mineIronButton.GetComponent<Button>();
      mineIronColorGreen = mineIronButton.GetComponent<Button>().colors;
      mineIronColorRed = mineIronButton.GetComponent<Button>().colors;

      // set iron green button colors
      mineIronColorGreen.highlightedColor = Color.green;
      mineIronColorGreen.normalColor = Color.green;
      mineIronColorGreen.pressedColor = Color.green;

      // set iron red button colors
      mineIronColorRed.highlightedColor = Color.red;
      mineIronColorRed.normalColor = Color.red;
      mineIronColorRed.pressedColor = Color.red;

      // set up mineCoal button colors
      mineCoalButton = mineCoalButton.GetComponent<Button>();
      mineCoalColorGreen = mineCoalButton.GetComponent<Button>().colors;
      mineCoalColorRed = mineCoalButton.GetComponent<Button>().colors;

      // set coal green button colors
      mineCoalColorGreen.highlightedColor = Color.green;
      mineCoalColorGreen.normalColor = Color.green;
      mineCoalColorGreen.pressedColor = Color.green;

      // set coal red button colors
      mineCoalColorRed.highlightedColor = Color.red;
      mineCoalColorRed.normalColor = Color.red;
      mineCoalColorRed.pressedColor = Color.red;

      // set up exploreMine button colors
      exploreRuinsButton = exploreRuinsButton.GetComponent<Button>();
      exploreRuinsColorGreen = exploreRuinsButton.GetComponent<Button>().colors;
      exploreRuinsColorRed = exploreRuinsButton.GetComponent<Button>().colors;

      // set explore green button colors
      exploreRuinsColorGreen.highlightedColor = Color.green;
      exploreRuinsColorGreen.normalColor = Color.green;
      exploreRuinsColorGreen.pressedColor = Color.green;

      // set explore red button colors
      exploreRuinsColorRed.highlightedColor = Color.red;
      exploreRuinsColorRed.normalColor = Color.red;
      exploreRuinsColorRed.pressedColor = Color.red;

      // set up expandMine button colors
      expandMineButton = expandMineButton.GetComponent<Button>();
      expandMineColorGreen = expandMineButton.GetComponent<Button>().colors;
      expandMineColorRed = expandMineButton.GetComponent<Button>().colors;

      // set expand green button colors
      expandMineColorGreen.highlightedColor = Color.green;
      expandMineColorGreen.normalColor = Color.green;
      expandMineColorGreen.pressedColor = Color.green;

      // set expand red button colors
      expandMineColorRed.highlightedColor = Color.red;
      expandMineColorRed.normalColor = Color.red;
      expandMineColorRed.pressedColor = Color.red;

      // set up performRitual button colors
      performRitualButton = performRitualButton.GetComponent<Button>();
      performRitualColorGreen = performRitualButton.GetComponent<Button>().colors;
      performRitualColorRed = performRitualButton.GetComponent<Button>().colors;

      // set ritual green button colors
      performRitualColorGreen.highlightedColor = Color.green;
      performRitualColorGreen.normalColor = Color.green;
      performRitualColorGreen.pressedColor = Color.green;

      // set ritual red button colors
      performRitualColorRed.highlightedColor = Color.red;
      performRitualColorRed.normalColor = Color.red;
      performRitualColorRed.pressedColor = Color.red;

    } // end SET COLORS

  } // end START
	
	// Update is called once per frame
	void Update ()
  {
    // update mineIron button color and bool
    if (mineIronCooldownTimer <= Time.time)
    {
      mineIronOffCooldown = true;
      mineIronButton.colors = mineIronColorGreen;

    }

    else
    {
      mineIronOffCooldown = false;
      mineIronButton.colors = mineIronColorRed;

    }

    // update mineCoal button color and bool
    if (mineCoalCooldownTimer <= Time.time)
    {
      mineCoalOffCooldown = true;
      mineCoalButton.colors = mineCoalColorGreen;

    }

    else
    {
      mineCoalOffCooldown = false;
      mineCoalButton.colors = mineCoalColorRed;

    }

    // update exploreRuins button color and bool
    if (exploreRuinsCooldownTimer <= Time.time)
    {
      exploreRuinsOffCooldown = true;
      exploreRuinsButton.colors = exploreRuinsColorGreen;

    }

    else
    {
      exploreRuinsOffCooldown = false;
      exploreRuinsButton.colors = exploreRuinsColorRed;

    }

    // update expandMine button color and bool
    if (expandMineCooldownTimer <= Time.time)
    {
      expandMineOffCooldown = true;
      expandMineButton.colors = expandMineColorGreen;

    }

    else
    {
      expandMineOffCooldown = false;
      expandMineButton.colors = expandMineColorRed;
    }

    // update performRitual button color and bool 
		if (performRitualCooldownTimer <= Time.time)
    {
      performmRitualOffCooldown = true;
      performRitualButton.colors = performRitualColorGreen;

    }

    else
    {
      performmRitualOffCooldown = false;
      performRitualButton.colors = performRitualColorRed;
    }

	} // end UPDATE

  public void _IronClicker()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (mineIronOffCooldown)
    {
      mineIronCooldownTimer = Time.time + mineIronCooldownLength;
      resourceManagerScript.ironOre += resourceManagerScript.ironOreClickIncrease;

    }

  } // end IRONCLICKER

  public void _CoalClicker()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (mineCoalOffCooldown)
    {
      mineCoalCooldownTimer = Time.time + mineCoalCooldownLength;
      resourceManagerScript.coal += resourceManagerScript.coalClickIncrease;
    }

  } // end COALCLIKER

  public void _ExploreRuinsClicker()
  {
      Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (exploreRuinsOffCooldown)
    {
      exploreRuinsCooldownTimer = Time.time + exploreRuinsCooldownLength;
      resourceManagerScript.relic += resourceManagerScript.relicClickIncrease;

    }

  } // end EXPLORERUINSCLICKER

  public void _ExpandMineClicker()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (expandMineOffCooldown)
    {
      expandMineCooldownTimer = Time.time + expandMineCooldownLength;
      resourceManagerScript.ironOreClickUpgradeMultiplier += 1;
      resourceManagerScript.coalClickUpgradeMultiplier += 1;
      resourceManagerScript.stone += 100;

    }

  } // end EXPANDMINECLICKER

  public void _PerformRitualClicker()
  {
    if (performmRitualOffCooldown)
    {
      performRitualCooldownTimer = Time.time + performRitualCooldownLength;
    }
  } // end PERFORMRITUALCLICKER

  public void _SmeltIron()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (resourceManagerScript.ironOre > 0)
    {
      resourceManagerScript.ironOre--;
      resourceManagerScript.iron++;

    }

  }

  public void _MakeSteel()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (resourceManagerScript.iron > 5 && resourceManagerScript.coal > 5)
    {
      resourceManagerScript.iron -= 5;
      resourceManagerScript.coal -= 5;

      resourceManagerScript.steel++;
    }
  }
} // end CLASS
