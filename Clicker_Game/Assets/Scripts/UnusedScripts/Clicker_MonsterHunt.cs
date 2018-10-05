using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* TODO:
 * Add auto click ever ten seconds
 */

public class Clicker_MonsterHunt : MonoBehaviour
{
  // link to display boxes
  public Text monsterTeethDisplay;
  public Text monsterBoneDisplay;
  public Text monsterHideDisplay;

  // set monster variables
  public int monsterTeeth = 0;
  public int monsterBone = 0;
  public int monsterHide = 0;

  public int monsterTeethClickIncrease = 10;
  public int monsterBoneClickIncrease = 20;
  public int monsterHideClickIncrease = 40;

  // set time variables
  private float timeStamp = 0.0F;
  private int timeCooldown = 30;

  // get button change colors
  private Button monsterHuntButton;
  private ColorBlock offCooldown;
  private ColorBlock onCooldown;

  // Use this for initialization
  void Start()
  {
    // start the time stamp
    timeStamp = Time.time;

    // set up the button color
    monsterHuntButton = GetComponent<Button>();
    onCooldown = GetComponent<Button>().colors;
    offCooldown = GetComponent<Button>().colors;

    // set colors
    onCooldown.normalColor = Color.red;
    onCooldown.pressedColor = Color.red;
    onCooldown.highlightedColor = Color.red;

    offCooldown.normalColor = Color.green;
    offCooldown.pressedColor = Color.green;
    offCooldown.highlightedColor = Color.green;

  } // end START

  // Update is called once per frame
  void Update()
  {
    // display the updated info to the text boxes
    monsterTeethDisplay.text = "Monster Teeth: " + monsterTeeth;
    monsterBoneDisplay.text = "Monster Bone: " + monsterBone;
    monsterHideDisplay.text = "Monster Hide: " + monsterHide;

    // set conditions to show correct colors
    if (timeStamp <= Time.time)
    {
      monsterHuntButton.colors = offCooldown;

    } // end timeStamp <= Time.time

    if (timeStamp > Time.time)
    {
      monsterHuntButton.colors = onCooldown;

    } // end timeStamp > Time.time

  } // end UPDATE

  public void Clicked()
  {
    // add values if off cool down
    if (timeStamp <= Time.time)
    {
      timeStamp = Time.time + timeCooldown;
      monsterTeeth += monsterTeethClickIncrease;
      monsterBone += monsterBoneClickIncrease;
      monsterHide += monsterHideClickIncrease;

    } // end timeStamp <= Time.time

  } // end CLICKED
	
} // end CLASS
