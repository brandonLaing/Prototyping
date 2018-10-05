using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Event_Manager_System : MonoBehaviour
{
  public Text eventText;
  public Button eventButton;
  public GameObject eventPanel;

  public GameObject resourceManager;
  public GameObject upgradeManager;
  public GameObject workerManager;
  public GameObject buildManager;

  public int mHuntCount = 0;

  // begin game
  private bool eventOne = true;

  // get objects for event one
  public GameObject woodResource;
  public GameObject woodButton;

  // get over 100 wood
  private bool eventTwo = false;

  // get objects for event two
  public GameObject houseUpgrade;
  public GameObject stoneResource;
  public GameObject stoneButton;

  // build house
  private bool eventThree = false;

  // get object for event three
  public GameObject workerPanel;
  public GameObject lumberjacksWorker;
  public GameObject stoneWorker;
  public GameObject hunterWorker;
  public GameObject fisherWorker;
  public GameObject fishingButton;
  public GameObject huntButton;
  public GameObject boneResource;
  public GameObject teethResource;
  public GameObject furResource;
  public GameObject meatResource;
  public GameObject fishResource;
  public GameObject axeUpgrade;
  public GameObject carvingUpgrade;
  public GameObject bowUpgrade;
  public GameObject skinningUpgrade;
  public GameObject fishingUpgrade;

  // pop over 40
  private bool eventFour = false;

  // get objects for event four
  public GameObject huntMonsterButton;
  public GameObject monsterBoneResource;
  public GameObject monsterTeethResource;
  public GameObject monsterPeltResource;
  public GameObject monsterMeatResource;
  public GameObject monsterScalesResource;

  // on 10th hut
  private bool eventFive = false;

  // get object for event five
  public GameObject mineBuild;

  // on mine built
  private bool eventSix = false;

  // get objects for event six
  public GameObject mineWorker;
  public GameObject ironResource;
  public GameObject ironOreResource;
  public GameObject coalResource;
  public GameObject steelResource;
  public GameObject mineStabilityUpgrade;
  public GameObject pickaxeUpgrade;
  public GameObject blacksmithBuild;
  public GameObject mineSwitch;

  // on blacksmith built
  private bool eventSeven = false;

  // get objects for event seven
  public GameObject herbButton;
  public GameObject leatherResource;
  public GameObject herbResource;
  public GameObject RelicsResource;

  public GameObject tradingPostBuild;
  public GameObject wallBuild;
  public GameObject tanneryBuild;
  public GameObject ironForgeBuild;
  public GameObject trainingHutBuild;
  public GameObject smokeHouseBuild;
  public GameObject herbalistBuild;
  public GameObject enchanterBuild;
  public GameObject ritualTable;
  public GameObject chiefsHut;

  public GameObject buildPanel;
  public GameObject upgradePanel;
  public GameObject itemPanel;

  // Use this for initialization
  void Start ()
  {
    woodResource.gameObject.SetActive(false);
    woodButton.gameObject.SetActive(false);

    houseUpgrade.gameObject.SetActive(false);
    stoneResource.gameObject.SetActive(false);
    stoneButton.gameObject.SetActive(false);

    workerPanel.gameObject.SetActive(false);
    lumberjacksWorker.gameObject.SetActive(false);
    stoneWorker.gameObject.SetActive(false);
    hunterWorker.gameObject.SetActive(false);
    fisherWorker.gameObject.SetActive(false);
    fishingButton.gameObject.SetActive(false);
    huntButton.gameObject.SetActive(false);
    boneResource.gameObject.SetActive(false);
    teethResource.gameObject.SetActive(false);
    furResource.gameObject.SetActive(false);
    meatResource.gameObject.SetActive(false);
    fishResource.gameObject.SetActive(false);
    axeUpgrade.gameObject.SetActive(false);
    carvingUpgrade.gameObject.SetActive(false);
    bowUpgrade.gameObject.SetActive(false);
    skinningUpgrade.gameObject.SetActive(false);
    fishingUpgrade.gameObject.SetActive(false);
    huntMonsterButton.gameObject.SetActive(false);
    monsterBoneResource.gameObject.SetActive(false);
    monsterTeethResource.gameObject.SetActive(false);
    monsterPeltResource.gameObject.SetActive(false);
    monsterMeatResource.gameObject.SetActive(false);
    monsterScalesResource.gameObject.SetActive(false);
    mineWorker.gameObject.SetActive(false);
    ironResource.gameObject.SetActive(false);
    ironOreResource.gameObject.SetActive(false);
    coalResource.gameObject.SetActive(false);
    steelResource.gameObject.SetActive(false);
    mineStabilityUpgrade.gameObject.SetActive(false);
    pickaxeUpgrade.gameObject.SetActive(false);
    mineBuild.gameObject.SetActive(false);
    blacksmithBuild.gameObject.SetActive(false);
    herbButton.gameObject.SetActive(false);
    leatherResource.gameObject.SetActive(false);
    herbResource.gameObject.SetActive(false);
    RelicsResource.gameObject.SetActive(false);
    tradingPostBuild.gameObject.SetActive(false);
    wallBuild.gameObject.SetActive(false);
    tanneryBuild.gameObject.SetActive(false);
    ironForgeBuild.gameObject.SetActive(false);
    trainingHutBuild.gameObject.SetActive(false);
    smokeHouseBuild.gameObject.SetActive(false);
    herbalistBuild.gameObject.SetActive(false);
    enchanterBuild.gameObject.SetActive(false);
    ritualTable.gameObject.SetActive(false);
    chiefsHut.gameObject.SetActive(false);
    mineSwitch.gameObject.SetActive(false);
    itemPanel.gameObject.SetActive(false);

  }

  // Update is called once per frame
  void Update ()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    Upgrade_Manager upgradeManagerScript = upgradeManager.GetComponent<Upgrade_Manager>();

    Worker_Manager workerManagerScript = workerManager.GetComponent<Worker_Manager>();

    Build_Manager buildManagerScript = buildManager.GetComponent<Build_Manager>();

    // start game
    if (eventOne)
    {
      eventPanel.gameObject.SetActive(true);
      eventText.text = "You wake up on the bank of a river with no knowledge of where or who you are.";
      eventOne = false;
      eventTwo = true;

      woodResource.gameObject.SetActive(true);
      woodButton.gameObject.SetActive(true);

    } // end event One

    // over 100 wood
    if (resourceManagerScript.wood >= 50 && eventTwo)
    {
      eventPanel.gameObject.SetActive(true);
      eventText.text = "While the environment isn't foreign you can't remember how to get back where you came from.";
      eventTwo = false;
      eventThree = true;

      buildPanel.gameObject.SetActive(true);
      houseUpgrade.gameObject.SetActive(true);
      stoneResource.gameObject.SetActive(true);
      stoneButton.gameObject.SetActive(true);

    } // end event two

    // build house
    if (upgradeManagerScript.housingLevel >= 1 && eventThree)
    {
      eventPanel.gameObject.SetActive(true);
      eventText.text = "A stranger stumbles out of the woods with wounds all over his body. A giant beast appears behind him and with" +
        "a struggle you both bring the beast down. He like your house but says when he heals he could do it better";
      eventThree = false;
      eventFour = true;

      workerPanel.gameObject.SetActive(true);
      lumberjacksWorker.gameObject.SetActive(true);
      stoneWorker.gameObject.SetActive(true);
      hunterWorker.gameObject.SetActive(true);
      fisherWorker.gameObject.SetActive(true);
      fishingButton.gameObject.SetActive(true);
      huntButton.gameObject.SetActive(true);
      boneResource.gameObject.SetActive(true);
      teethResource.gameObject.SetActive(true);
      furResource.gameObject.SetActive(true);
      meatResource.gameObject.SetActive(true);
      fishResource.gameObject.SetActive(true);
      axeUpgrade.gameObject.SetActive(true);
      carvingUpgrade.gameObject.SetActive(true);
      bowUpgrade.gameObject.SetActive(true);
      skinningUpgrade.gameObject.SetActive(true);
      fishingUpgrade.gameObject.SetActive(true);

    } // end event three
 
    // pop over 40
    if (workerManagerScript.totalWorkers >= 40 && eventFour)
    {
      eventPanel.gameObject.SetActive(true);
      eventText.text = "The village has gotten big enough, to start fighting back.";
      eventFour = false;
      eventFive = true;

      huntMonsterButton.gameObject.SetActive(true);
      monsterBoneResource.gameObject.SetActive(true);
      monsterTeethResource.gameObject.SetActive(true);
      monsterPeltResource.gameObject.SetActive(true);
      monsterMeatResource.gameObject.SetActive(true);
      monsterScalesResource.gameObject.SetActive(true);

    } // end event four

    // gone on 10 monster hunts
    if (mHuntCount >= 10 && eventFive)
    {
      eventPanel.gameObject.SetActive(true);
      eventText.text = "You find what looks like a cave opening on your latest hunt. It looks full of resources. It may be mineable.";
      eventFive = false;
      eventSix = true;

      mineStabilityUpgrade.gameObject.SetActive(true);


    } // end event five

    // built mine
    if (buildManagerScript.mineBuilt && eventSix)
    {
      eventPanel.gameObject.SetActive(true);
      eventText.text = "This mine will help us advance our town and better defend ourselves from the monsters";
      eventSix = false;
      eventSeven = true;

      mineWorker.gameObject.SetActive(true);
      ironResource.gameObject.SetActive(true);
      ironOreResource.gameObject.SetActive(true);
      coalResource.gameObject.SetActive(true);
      steelResource.gameObject.SetActive(true);
      mineStabilityUpgrade.gameObject.SetActive(true);
      pickaxeUpgrade.gameObject.SetActive(true);
      blacksmithBuild.gameObject.SetActive(true);
      mineSwitch.gameObject.SetActive(true);
     
    } // end event six

    // on blacksmithBuild
    if (buildManagerScript.blacksmithBuilt && eventSeven)
    {
      eventPanel.gameObject.SetActive(true);
      eventText.text = "You have the tools to build a might city now that will attract people scattered all around the land.";
      eventSeven = false;

      buildPanel.gameObject.SetActive(true);
      herbButton.gameObject.SetActive(true);
      leatherResource.gameObject.SetActive(true);
      herbResource.gameObject.SetActive(true);
      RelicsResource.gameObject.SetActive(true);
      tradingPostBuild.gameObject.SetActive(true);
      wallBuild.gameObject.SetActive(true);
      tanneryBuild.gameObject.SetActive(true);
      ironForgeBuild.gameObject.SetActive(true);
      trainingHutBuild.gameObject.SetActive(true);
      smokeHouseBuild.gameObject.SetActive(true);
      herbalistBuild.gameObject.SetActive(true);
      enchanterBuild.gameObject.SetActive(true);
      ritualTable.gameObject.SetActive(true);
      chiefsHut.gameObject.SetActive(true);

    }

  } // end update

  public void _EndEventClicker()
  {
    eventPanel.gameObject.SetActive(false);
  }



}
