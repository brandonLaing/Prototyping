using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* TODO:
 * Update upgrade level text
 * when upgrade level is at max block out the text
 * when upgrade buttons are pressed update info to variables
 * set upgrade cost
 */

public class Upgrade_Manager : MonoBehaviour
{
  public GameObject resourceManager;
  public GameObject workerManager;
  public GameObject buildManager;

  public Button housingButton;
  public Button mineStabilityButton;
  public Button axesButton;
  public Button pickaxesButton;
  public Button butcherKnifeButton;
  public Button bowButton;
  public Button skinningKnifeButton;
  public Button fishingPoleButton;

  public Text housingDisplay;
  public Text mineStablityDisplay;
  public Text axeDisplay;
  public Text pickaxeDisplay;
  public Text butcherDisplay;
  public Text bowDisplay;
  public Text skinningDisplay;
  public Text fishingPoleDisplay;

  public Text housingCostDisplay;
  public Text mineStabilityCostDisplay;
  public Text axeCostDisplay;
  public Text pickaseCostDisplay;
  public Text butcherCostDisplay;
  public Text bowCostDisplay;
  public Text skinningKnifeCostDisplay;
  public Text fishingPoleCostDisplay;

  public float upgradeCostMultiplier = 1.5F;
  
  private int housingCostWood = 50;
  private int housingCostStone = 20;

  private int mineStabilityCostStone = 100;
  private int mineStabilityCostWood = 50;

  private int axeCostWood = 50;
  private int axeCostStone = 20;

  private int pickaxeCostWood = 50;
  private int pickaxeCostStone = 20;

  private int butcherCostWood = 50;
  private int butcherCostStone = 20;

  private int bowCostTeeth = 30;
  private int bowCostWood = 100;

  private int skinningCostWood = 30;
  private int skinningCostStone = 50;

  private int fishingCostWood = 100;
  private int fishingCostStone = 5;

  public int housingLevel = 0;
  public int mineStablityLevel = 0;
  public int axeLevel = 0;
  public int pickaxeLevel = 0;
  public int butcherLevel = 0;
  public int bowLevel = 0;
  public int skinningLevel = 0;
  public int fishingLevel = 0;
	
	// Update is called once per frame
	void Update ()
  {
		// set displays for all levels
    housingDisplay.text = "Upgrade Housing [" + housingLevel + "]";
    mineStablityDisplay.text = "Upgrade Mine [" + mineStablityLevel + "]";
    axeDisplay.text = "Upgrade Axes [" + axeLevel + "]";
    pickaxeDisplay.text = "Upgrade Pickax [" + pickaxeLevel + "]";
    butcherDisplay.text = "Upgrade Butcher Knife [" + butcherLevel + "]";
    bowDisplay.text = "Upgrade Bow [" + bowLevel + "]";
    skinningDisplay.text = "Upgrade Skinning Knife [" + skinningLevel + "]";
    fishingPoleDisplay.text = "Upgrade Fishing Pole [" + fishingLevel + "]";

    // set display for all upgrade cost
    housingCostDisplay.text = "Wood: " + housingCostWood + " Stone: " + housingCostStone;

    mineStabilityCostDisplay.text = "Wood: " + mineStabilityCostWood + " Stone: " + mineStabilityCostStone;

    axeCostDisplay.text = "Wood: " + axeCostWood + " Stone: " + axeCostStone;

    pickaseCostDisplay.text = "Wood: " + pickaxeCostWood + " Stone: " + pickaxeCostStone;

    butcherCostDisplay.text = "Wood: " + butcherCostWood + " Stone: " + pickaxeCostStone;

    fishingPoleCostDisplay.text = "Wood: " + fishingCostWood + " Stone: " + fishingCostStone;

  } // end update

  public void _HousingUpgrade()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();
    Worker_Manager workerManagerScript = workerManager.GetComponent<Worker_Manager>();

    if (resourceManagerScript.wood >= housingCostWood && resourceManagerScript.stone >= housingCostStone)
    {
      ++housingLevel;
      resourceManagerScript.wood -= housingCostWood;
      resourceManagerScript.stone -= housingCostWood;

      float newHousingCostWood = (float)housingCostWood * upgradeCostMultiplier;
      housingCostWood = (int)newHousingCostWood;

      float newHousingCostStone = (float)housingCostStone * upgradeCostMultiplier;
      housingCostStone = (int)newHousingCostStone;

      workerManagerScript.workersIdle += 5;

    }
  }

  public void _mineStabilityUpgrade()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();
    Build_Manager buildManagerScript = buildManager.GetComponent<Build_Manager>();

    if (resourceManagerScript.wood >= mineStabilityCostWood && resourceManagerScript.stone >= mineStabilityCostStone && buildManagerScript.mineBuilt == false)
    {
      ++mineStablityLevel;
      resourceManagerScript.wood -= mineStabilityCostWood;
      resourceManagerScript.stone -= mineStabilityCostStone;

      float newStabilityCostWood = (float)mineStabilityCostWood * upgradeCostMultiplier;
      mineStabilityCostWood = (int)newStabilityCostWood;

      float newStabilityCostStone = (float)mineStabilityCostStone * upgradeCostMultiplier;
      mineStabilityCostStone = (int)newStabilityCostStone;
      
      if (buildManagerScript.mineBuilt == false)
      {
        buildManagerScript.mineBuilt = true;

      }

    }

  }

  public void _Axes()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (resourceManagerScript.wood >= axeCostWood && resourceManagerScript.stone >= axeCostStone)
    {
      ++axeLevel;
      resourceManagerScript.wood -= axeCostWood;
      resourceManagerScript.stone -= axeCostStone;

      float newAxesCostWood = (float)axeCostWood * upgradeCostMultiplier;
      axeCostWood = (int)newAxesCostWood;

      float newAxesCostStone = (float)axeCostStone * upgradeCostMultiplier;
      axeCostStone = (int)newAxesCostStone;

      resourceManagerScript.woodClickUpgradeMultiplier += 1;

    }

  }

  public void _Pickaxe()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (resourceManagerScript.wood >= pickaxeCostWood && resourceManagerScript.stone >= pickaxeCostStone)
    {
      ++pickaxeLevel;
      resourceManagerScript.wood -= pickaxeCostWood;
      resourceManagerScript.stone -= pickaxeCostStone;

      float newPickCostWood = (float)pickaxeCostWood * upgradeCostMultiplier;
      pickaxeCostWood = (int)newPickCostWood;

      float newPickCostStone = (float)pickaxeCostStone * upgradeCostMultiplier;
      pickaxeCostStone = (int)newPickCostStone;

      resourceManagerScript.stoneClickUpgradeMultiplier += 1;

    }

  }

  public void _ButcherKnife()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (resourceManagerScript.wood >= butcherCostWood && resourceManagerScript.stone >= butcherCostStone)
    {
      ++butcherLevel;
      resourceManagerScript.wood -= butcherCostWood;
      resourceManagerScript.stone -= butcherCostStone;

      float newButcherCostWood = (float)butcherCostWood * upgradeCostMultiplier;
      butcherCostWood = (int)newButcherCostWood;

      float newButcherCostStone = (float)butcherCostStone * upgradeCostMultiplier;
      newButcherCostStone = (int)newButcherCostStone;

      resourceManagerScript.meatClickUpgradeMultiplier += 1;
      resourceManagerScript.mMeatClickUpgradeMultiplier += 1;

    }

  }


  public void _SkinningKnife()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (resourceManagerScript.wood >= skinningCostWood && resourceManagerScript.stone >= skinningCostStone)
    {
      ++skinningLevel;
      resourceManagerScript.wood -= skinningCostWood;
      resourceManagerScript.stone -= skinningCostStone;

      float newSkinningCostWood = (float)skinningCostWood * upgradeCostMultiplier;
      skinningCostWood = (int)newSkinningCostWood;

      float newSkinningCostStone = (float)skinningCostStone * upgradeCostMultiplier;
      skinningCostStone = (int)newSkinningCostStone;

    }

  }

  public void _fishingPole()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (resourceManagerScript.wood >= fishingCostWood && resourceManagerScript.stone >= fishingCostStone)
    {
      ++fishingLevel;
      resourceManagerScript.wood -= fishingCostWood;
      resourceManagerScript.stone -= fishingCostStone;

      float newFishCostWood = (float)fishingCostWood * upgradeCostMultiplier;
      fishingCostWood = (int)newFishCostWood;

      float newFishCostStone = (float)fishingCostStone * upgradeCostMultiplier;
      fishingCostStone = (int)newFishCostStone;

      resourceManagerScript.fishClickUpgradeMultiplier += 1;
    }

  }

}
