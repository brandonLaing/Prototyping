using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* TODO:
 * Move variables to other scripts when they are created:
 *    autoClickIntervalTime
 *    workersWood
 */


public class Clicker_Wood : MonoBehaviour
{
  // link to display boxes
  public Text woodDisplay;

  // set wood variable
  public int wood = 0;
  public int woodClickIncrease = 1;

  // set time variables
  private float timeStamp = 0.0F;
  private int timeCooldown = 1;

  // get button to change colors
  private Button woodButton;
  private ColorBlock offCooldown;
  private ColorBlock onCooldown;
      
  // auto click interval time variables
  public int autoClickIntervalTime = 10;
  private float autoTimeStamp = 0.0F;
  public int workersWood = 2;

	// Use this for initialization
	void Start ()
  {
    // start time stamp
    timeStamp = Time.time;

    // set up the button color
    woodButton = GetComponent<Button>();
    offCooldown = GetComponent<Button>().colors;
    onCooldown = GetComponent<Button>().colors;

    // set colors
    offCooldown.normalColor = Color.green;
    offCooldown.pressedColor = Color.green;
    offCooldown.highlightedColor = Color.green;

    onCooldown.normalColor = Color.red;
    onCooldown.pressedColor = Color.red;
    onCooldown.highlightedColor = Color.red;

  } // end START

  // Update is called once per frame
  void Update ()
  {
    // display updated info to the text boxes
    woodDisplay.text = "Wood: " + wood;

    // set conditions to show correct colors
    if (timeStamp <= Time.time)
    {
      woodButton.colors = offCooldown;

    } // timeStamp <= Time.time

    if (timeStamp > Time.time)
    {
      woodButton.colors = onCooldown;

    } // timeStamp > Time.time

    // auto click code
    if (autoTimeStamp <= Time.time)
    {
      wood = (workersWood * woodClickIncrease) + wood;
      autoTimeStamp = Time.time + autoClickIntervalTime;
    } // end autoTimeStamp <= Time.time

  } // end UPDATE

  // Update is called when button is clicked
  public void Clicked()
  {
    // add values if off cool down
    if (timeStamp <= Time.time)
    {
      timeStamp = Time.time + timeCooldown;
      wood += woodClickIncrease;

    } // end timeStamp <= Time.time

  } // end CLICKED

} // end CLASS