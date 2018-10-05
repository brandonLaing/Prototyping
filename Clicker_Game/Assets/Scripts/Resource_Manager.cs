using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resource_Manager : MonoBehaviour {
  // link to other mangers
  public GameObject workerManager;

  // link to display boxes
  public Text woodDisplay;
  public Text stoneDisplay;

  public Text boneDisplay;
  public Text teethDisplay;
  public Text furDisplay;
  public Text meatDisplay;
  public Text fishDisplay;
  public Text herbDispaly;

  public Text ironOreDisplay;
  public Text ironDispaly;
  public Text coalDisplay;
  public Text steelDisplay;

  public Text leatherDisplay;

  public Text mBoneDisplay;
  public Text mTeethDisplay;
  public Text mPeltDisplay;
  public Text mScalesDisplay;
  public Text mMeatDisplay;

  public Text relicDisplay;

  // set up variables
  public int wood = 0;
  public int stone = 0;

  public int bone = 0;
  public int teeth = 0;
  public int fur = 0;
  public int food = 0;
  public int herb = 0;

  public int ironOre = 0;
  public int iron = 0;
  public int coal = 0;
  public int steel = 0;

  public int leather = 0;

  public int mBone = 0;
  public int mTeeth = 0;
  public int mPelt = 0;
  public int mScale = 0;

  public int relic = 0;

  // set cool downs
  private float autoCooldownTimer = 0.0F;
  private int autoClickTimeInterval = 10;

  // set click increase
  public int woodClickIncrease = 1;
  public int stoneClickIncrease = 1;

  public int boneClickIncrease = 1;
  public int teethClickIncrease = 1;
  public int furClickIncrease = 1;
  public int meatClickIncrease = 1;
  public int fishClickIncrease = 1;
  public int herbClickIncrease = 1;

  public int ironOreClickIncrease = 1;
  public int coalClickIncrease = 1;

  public int mBoneClickIncrease = 1;
  public int mTeethClickIncrease = 1;
  public int mPeltClickIncrease = 1;
  public int mMeatClickIncrease = 1;
  public int mScaleClickIncrease = 1;

  public int relicClickIncrease = 1;

  // temp set click upgrade --> move this to upgradeManager
  public int woodClickUpgradeMultiplier = 1;
  public int stoneClickUpgradeMultiplier = 1;

  public int boneClickUpgradeMultiplier = 1;
  public int teethClickUpgradeMultiplier = 1;
  public int furClickUpgradeMultiplier = 1;
  public int meatClickUpgradeMultiplier = 1;
  public int fishClickUpgradeMultiplier = 1;
  public int herbClickUpgradeMultiplier = 1;

  public int ironOreClickUpgradeMultiplier = 1;
  public int coalClickUpgradeMultiplier = 1;

  public int mBoneClickUpgradeMultiplier = 1;
  public int mTeethClickUpgradeMultiplier = 1;
  public int mPeltClickUpgradeMultiplier = 1;
  public int mMeatClickUpgradeMultiplier = 1;
  public int mScaleClickUpgradeMultiplier = 1;

  public int relicClickUpgradeMultiplier = 1;

	// Update is called once per frame
	void Update ()
  {

    // set displays for all of the 
    woodDisplay.text = "Wood: " + wood;
    stoneDisplay.text = "Stone: " + stone;

    boneDisplay.text = "Bone: " + bone;
    teethDisplay.text = "Teeth: " + teeth;
    furDisplay.text = "Fur: " + fur;
    meatDisplay.text = "Food: " + food;

    herbDispaly.text = "Herb: " + herb;

    ironOreDisplay.text = "Iron Ore: " + ironOre;
    ironDispaly.text = "Iron: " + iron;
    coalDisplay.text = "Coal: " + coal;
    steelDisplay.text = "Steel: " + steel;

    leatherDisplay.text = "Leather: " + leather;
    
    mBoneDisplay.text = "Monster Bone: " + mBone;
    mTeethDisplay.text = "Monster Teeth: " + mTeeth;
    mPeltDisplay.text = "Monster Pelt: " + mPelt;
    mScalesDisplay.text = "Monster Scales: " + mScale;

    relicDisplay.text = "Relics: " + relic;

    // set up call to other managers
    Worker_Manager workerManagerScript = workerManager.GetComponent<Worker_Manager>();
     
    // run auto click ever ten seconds
    if (autoCooldownTimer <= Time.time)
    {
      // set new timer to current time + the auto time - reduction time while keeping it in between 0 and 10
      autoCooldownTimer = Time.time + autoClickTimeInterval;

      // add (click increase * click upgrade) * number of workers to each resource variable
      wood += (woodClickIncrease * woodClickUpgradeMultiplier) * (workerManagerScript.workersWood + 1);
      stone += (stoneClickIncrease * stoneClickUpgradeMultiplier) * (workerManagerScript.workersStone + 1);

      bone += (boneClickIncrease * boneClickUpgradeMultiplier) * (workerManagerScript.workersRegularHunt + 1);
      teeth += (teethClickIncrease * boneClickUpgradeMultiplier) * (workerManagerScript.workersRegularHunt + 1);
      fur += (furClickIncrease * furClickUpgradeMultiplier) * (workerManagerScript.workersRegularHunt + 1);
      food += (meatClickIncrease * meatClickUpgradeMultiplier) * (workerManagerScript.workersRegularHunt + 1);
      food += (fishClickIncrease * fishClickUpgradeMultiplier) * (workerManagerScript.workersFisher + 1);
      herb += (herbClickIncrease * herbClickUpgradeMultiplier) * (workerManagerScript.workersHerb + 1);

      ironOre += (ironOreClickIncrease * ironOreClickUpgradeMultiplier) * (workerManagerScript.workersMine + 1);
      coal += (coalClickIncrease * coalClickUpgradeMultiplier) * (workerManagerScript.workersMine + 1);


      mBone += (mBoneClickIncrease * mBoneClickUpgradeMultiplier) * (workerManagerScript.workersMonsterHunt + 1);
      mTeeth += (mTeethClickIncrease * mBoneClickUpgradeMultiplier) * (workerManagerScript.workersMonsterHunt + 1);
      mPelt += (mPeltClickIncrease * mPeltClickUpgradeMultiplier) * (workerManagerScript.workersMonsterHunt + 1);
      food += (mMeatClickIncrease * mMeatClickUpgradeMultiplier) * (workerManagerScript.workersMonsterHunt + 1);
      mScale += (mScaleClickIncrease * mScaleClickUpgradeMultiplier) * (workerManagerScript.workersMonsterHunt + 1);

      food -= (workerManagerScript.workersWood + workerManagerScript.workersStone + workerManagerScript.workersRegularHunt
         + workerManagerScript.workersMine + workerManagerScript.workersMonsterHunt
        + workerManagerScript.workersFisher);

      if (food < 0)
      {
        if (workerManagerScript.workersIdle > 3)
        {
          workerManagerScript.workersIdle -= 3;

        }

        else if (workerManagerScript.workersWood > 3)
        {
          workerManagerScript.workersWood -= 3;

        }
        
        else if (workerManagerScript.workersStone > 3)
        {
          workerManagerScript.workersStone -= 3;

        }

        else if (workerManagerScript.workersRegularHunt > 3)
        {
          workerManagerScript.workersRegularHunt -= 3;

        }

        else if (workerManagerScript.workersHerb > 3)
        {
          workerManagerScript.workersHerb -= 3;

        }

        else if (workerManagerScript.workersMine > 3)
        {
          workerManagerScript.workersMine -= 3;

        }

        else if (workerManagerScript.workersMonsterHunt > 3)
        {
          workerManagerScript.workersMonsterHunt -= 3;
          
        }

        else if (workerManagerScript.workersFisher > 3)
        {
          workerManagerScript.workersFisher -= 3;

        }

      }

    }

	} // end UPDATE

} // end CLASS
