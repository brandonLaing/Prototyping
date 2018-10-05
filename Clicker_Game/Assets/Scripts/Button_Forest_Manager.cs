using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Forest_Manager : MonoBehaviour
{
  // set resource manager object
  public GameObject resourceManager;
  public GameObject workerManager;
  public GameObject eventManager;

  // get buttons for color
  public Button woodButton;
  public Button stoneButton;
  public Button rHuntButton;
  public Button mHuntButton;
  public Button herbsButton;
  public Button fishingButton;

  // set cool down lengths
  public int woodCooldownLength = 1;
  public int stoneCooldownLength = 1;
  public int rHuntCooldownLength = 1;
  public int mHuntCooldownLength = 1;
  public int herbsCooldownLength = 1;
  public int fishingCooldownLenth = 1;

  // set button colors for wood
  private ColorBlock woodColorGreen;
  private ColorBlock woodColorRed;

  // set button colors for stone
  private ColorBlock stoneColorGreen;
  private ColorBlock stoneColorRed;

  // set button colors for rHunt
  private ColorBlock rHuntColorGreen;
  private ColorBlock rHuntColorRed;

  // set button colors for mHunt
  private ColorBlock mHuntColorGreen;
  private ColorBlock mHuntColorRed;

  // set button colors for herbs
  private ColorBlock herbsColorGreen;
  private ColorBlock herbsColorRed;

  // set button colors for fishing
  private ColorBlock fishingColorGreen;
  private ColorBlock fishingColorRed;

  // set cool down timers
  private float woodCooldownTimer = 0.0F;
  private float stoneCooldownTimer = 0.0F;
  private float rHuntCooldownTimer = 0.0F;
  private float mHuntCooldownTimer = 0.0F;
  private float herbsCooldownTimer = 0.0F;
  private float fishingCooldownTimer = 0.0F;


  // set cool down bools
  private bool woodOffCooldown = true;
  private bool stoneOffCooldown = true;
  private bool rHuntOffCooldown = true;
  private bool mHuntOffCooldown = true;
  private bool herbsOffCooldown = true;
  private bool fishingOffCooldown = true;

  public int mHuntDeathMod = 0;

	// Use this for initialization
	void Start ()
  {
    // set start timers
    woodCooldownTimer = Time.time;
    stoneCooldownTimer = Time.time;
    rHuntCooldownTimer = Time.time;
    mHuntCooldownTimer = Time.time;
    herbsCooldownTimer = Time.time;
    fishingCooldownTimer = Time.time;

    // set up button colors
    if (true)
    {
      // set up wood button colors
      woodButton = woodButton.GetComponent<Button>();
      woodColorGreen = woodButton.GetComponent<Button>().colors;
      woodColorRed = woodButton.GetComponent<Button>().colors;

      // set wood green button colors
      woodColorGreen.highlightedColor = Color.green;
      woodColorGreen.normalColor = Color.green;
      woodColorGreen.pressedColor = Color.green;

      // set wood red button colors
      woodColorRed.highlightedColor = Color.red;
      woodColorRed.normalColor = Color.red;
      woodColorRed.pressedColor = Color.red;

      // set up stone button colors
      stoneButton = stoneButton.GetComponent<Button>();
      stoneColorGreen = stoneButton.GetComponent<Button>().colors;
      stoneColorRed = stoneButton.GetComponent<Button>().colors;

      // set stone green button colors
      stoneColorGreen.highlightedColor = Color.green;
      stoneColorGreen.normalColor = Color.green;
      stoneColorGreen.pressedColor = Color.green;

      // set stone red button colors
      stoneColorRed.highlightedColor = Color.red;
      stoneColorRed.normalColor = Color.red;
      stoneColorRed.pressedColor = Color.red;

      // set up rHunt button colors
      rHuntButton = rHuntButton.GetComponent<Button>();
      rHuntColorGreen = rHuntButton.GetComponent<Button>().colors;
      rHuntColorRed = rHuntButton.GetComponent<Button>().colors;

      // set rHunt green button colors
      rHuntColorGreen.highlightedColor = Color.green;
      rHuntColorGreen.normalColor = Color.green;
      rHuntColorGreen.pressedColor = Color.green;

      // set rHunt red button colors
      rHuntColorRed.highlightedColor = Color.red;
      rHuntColorRed.normalColor = Color.red;
      rHuntColorRed.pressedColor = Color.red;

      // set mHunt button colors
      mHuntButton = mHuntButton.GetComponent<Button>();
      mHuntColorGreen = mHuntButton.GetComponent<Button>().colors;
      mHuntColorRed = mHuntButton.GetComponent<Button>().colors;

      // set mHunt green button colors
      mHuntColorGreen.highlightedColor = Color.green;
      mHuntColorGreen.normalColor = Color.green;
      mHuntColorGreen.pressedColor = Color.green;

      // set mHunt red buttons colors
      mHuntColorRed.highlightedColor = Color.red;
      mHuntColorRed.normalColor = Color.red;
      mHuntColorRed.pressedColor = Color.red;

      // set herbs button colors
      herbsButton = herbsButton.GetComponent<Button>();
      herbsColorGreen = herbsButton.GetComponent<Button>().colors;
      herbsColorRed = herbsButton.GetComponent<Button>().colors;

      // set herbs green button colors
      herbsColorGreen.highlightedColor = Color.green;
      herbsColorGreen.normalColor = Color.green;
      herbsColorGreen.pressedColor = Color.green;

      // set herbs red button colors
      herbsColorRed.highlightedColor = Color.red;
      herbsColorRed.normalColor = Color.red;
      herbsColorRed.pressedColor = Color.red;

      // set fishing button colors
      fishingButton = fishingButton.GetComponent<Button>();
      fishingColorGreen = fishingButton.GetComponent<Button>().colors;
      fishingColorRed = fishingButton.GetComponent<Button>().colors;

      // set fishing green button colors
      fishingColorGreen.highlightedColor = Color.green;
      fishingColorGreen.normalColor= Color.green;
      fishingColorGreen.pressedColor = Color.green;

      // set fishing red button colors
      fishingColorRed.highlightedColor = Color.red;
      fishingColorRed.normalColor = Color.red;
      fishingColorRed.pressedColor = Color.red;

    } // end SET COLORS

  } // end START

  // Update is called once per frame
  void Update ()
  {
    // update wood button color and bool
    if (woodCooldownTimer <= Time.time)
    {
      woodOffCooldown = true;
      woodButton.colors = woodColorGreen;

    }

    else
    {
      woodOffCooldown = false;
      woodButton.colors = woodColorRed;

    }

    // update stone button color and bool
    if (stoneCooldownTimer <= Time.time)
    {
      stoneOffCooldown = true;
      stoneButton.colors = stoneColorGreen;

    }

    else
    {
      stoneOffCooldown = false;
      stoneButton.colors = stoneColorRed;
    }
    
    // update rHut button color and bool
    if (rHuntCooldownTimer <= Time.time)
    {
      rHuntOffCooldown = true;
      rHuntButton.colors = rHuntColorGreen;

    }

    else
    {
      rHuntOffCooldown = false;
      rHuntButton.colors = rHuntColorRed;

    }

    // update mHut button color and bool
    if (mHuntCooldownTimer <= Time.time)
    {
      mHuntOffCooldown = true;
      mHuntButton.colors = mHuntColorGreen;

    }

    else
    {
      mHuntOffCooldown = false;
      mHuntButton.colors = mHuntColorRed;

    }

    // update herbs button color and bool
    if (herbsCooldownTimer <= Time.time)
    {
      herbsOffCooldown = true;
      herbsButton.colors = herbsColorGreen;

    }

    else
    {
      herbsOffCooldown = false;
      herbsButton.colors = herbsColorRed;

    }

    // update fishing button color and bool
    if (fishingCooldownTimer <= Time.time)
    {
      fishingOffCooldown = true;
      fishingButton.colors = fishingColorGreen;

    }

    else
    {
      fishingOffCooldown = false;
      fishingButton.colors = fishingColorRed;

    }

  } // end UPDATE

  public void _WoodClicker()
  {
    // update the resource manager when the button is clicked
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    // if the button is off cooldown add time to cooldown then increase the resource count
    if (woodOffCooldown)
    {
      woodCooldownTimer = Time.time + woodCooldownLength;
      resourceManagerScript.wood += resourceManagerScript.woodClickIncrease;
    }
  } // end _WOODCLICKER

  public void _StoneClicker()
  {
    // update the resource manager when the button is clicked
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    // if the button is off cooldown add time to cooldown then increase the resource count
    if (stoneOffCooldown)
    {
      stoneCooldownTimer = Time.time + stoneCooldownLength;
      resourceManagerScript.stone += resourceManagerScript.stoneClickIncrease;
    }
  } // end _STONECLICKER

  public void _RHuntClicker()
  {
    // update the resource manager when the button is clicked
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    // if the button is off cooldown add time to cooldown then increase the resource count
    if (rHuntOffCooldown)
    {
      rHuntCooldownTimer = Time.time + rHuntCooldownLength;
      resourceManagerScript.food += resourceManagerScript.meatClickIncrease;
      resourceManagerScript.bone += resourceManagerScript.boneClickIncrease;
      resourceManagerScript.teeth += resourceManagerScript.teethClickIncrease;
      resourceManagerScript.fur += resourceManagerScript.furClickIncrease;

    }
  } // end _RHUNTCLICKER(

  public void _MHuntClicker()
  {
    // update the resource manager when the button is clicked
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();
    Worker_Manager workerManagerScript = workerManager.GetComponent<Worker_Manager>();
    Event_Manager_System eventManagerScript = eventManager.GetComponent<Event_Manager_System>();

    // if the button is off cooldown add time to cooldown then increase the resource count
    if (mHuntOffCooldown)
    {
      if (Random.Range(1, 10) + mHuntDeathMod + ((float)workerManagerScript.workersMonsterHunt / 2) <= 7)
      {
        if (workerManagerScript.workersMonsterHunt > 0)
        {
          workerManagerScript.workersMonsterHunt -= Random.Range(1, 3);

          if (workerManagerScript.workersMonsterHunt < 0)
          {
            workerManagerScript.workersMonsterHunt = 0;
          } // end setting the workers to 0 is they are lower

        } // end REMOVE WORKER
        eventManagerScript.mHuntCount += 1;

      } // end CHECK IF HUNT SUCCESSFUL

      else
      {
        mHuntCooldownTimer = Time.time + mHuntCooldownLength;
        resourceManagerScript.mBone += resourceManagerScript.mBoneClickIncrease;
        resourceManagerScript.mTeeth += resourceManagerScript.mTeethClickIncrease;
        resourceManagerScript.mPelt += resourceManagerScript.mPeltClickIncrease;
        resourceManagerScript.food += resourceManagerScript.mMeatClickIncrease;
        resourceManagerScript.mScale += resourceManagerScript.mScaleClickIncrease;

      } // end ELSE

    }

  } // end MHUNTCLICKER

  public void _HerbsClicker()
  {
    // update the resource manager when the button is clicked
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    // if the button is off cooldown add time to the cooldown then increase the resource count
    if (herbsOffCooldown)
    {
      herbsCooldownTimer = Time.time + herbsCooldownLength;
      resourceManagerScript.herb += resourceManagerScript.herbClickIncrease;

    }

  } // end HERBSCLICKER

  public void _FishingClicker()
  {
    // update the resource manager when the button is clicked
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    // if the button is off cooldown add time to the cooldown then increase the resource count
    if (fishingOffCooldown)
    {
      fishingCooldownTimer = Time.time + fishingCooldownLenth;
      resourceManagerScript.food += resourceManagerScript.fishClickIncrease;
    }

  } // end FISHINGCLICKER

} // end CLASS