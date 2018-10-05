using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* TODO:
 * Add Auto click ever ten seconds
 */

public class Clicker_Stone : MonoBehaviour
{
  // link to display boxes
  public Text stoneDisplay;

  // set stone variable
  public int stone = 0;
  public int stoneClickIncrease = 2;

  // set time variables
  private float timeStamp = 0.0F;
  private int timeCooldown = 2;

  // get button to change colors
  private Button stoneButton;
  private ColorBlock offCooldown;
  private ColorBlock onCooldown;

	// Use this for initialization
	void Start ()
  {
    // start time stamp
    timeStamp = Time.time;

    // set up the button color
    stoneButton = GetComponent<Button>();
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
    stoneDisplay.text = "Stone: " + stone;

    // set conditions to show correct colors
    if (timeStamp <= Time.time)
    {
      stoneButton.colors = offCooldown;

    } // end timeStamp <= Time.time

    if (timeStamp > Time.time)
    {
      stoneButton.colors = onCooldown;

    } // timeStamp > Time.time

  } // end UPDATE

  // Update is called when button is clicked
  public void Clicked()
  {
    // add values if off cool down
    if (timeStamp <= Time.time)
    {
      timeStamp = Time.time + timeCooldown;
      stone += stoneClickIncrease;

    } // end timeStamp <= Time.time

  } // end CLICKED

}