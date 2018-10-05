using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* TODO:
Move variables to other scripts when they are created:
 *    workersRegularHunt
 */

public class Clicker_RegularHunt : MonoBehaviour
{
  // link to the display boxes
  public Text teethDisplay;
  public Text boneDisplay;
  public Text furDisplay;

  // set the animal variables
  public int teeth = 0;
  public int bone = 0;
  public int fur = 0;

  public int teethClickIncrease = 5;
  public int boneClickIncrease = 10;
  public int furClickIncrease = 15;

  // set time variables
  private float timeStamp = 0.0F;
  private int timeCooldown = 10;

  // get the button to change colors
  private Button regHuntButton;
  private ColorBlock offCooldown;
  private ColorBlock onCooldown;

	// Use this for initialization
	void Start ()
  {
    //start the time stamp
    timeStamp = Time.time;

    // set up the button color
    regHuntButton = GetComponent<Button>();
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
    // display the updated info to text boxes
    teethDisplay.text = "Teeth: " + teeth;
    boneDisplay.text = "Bone: " + bone;
    furDisplay.text = "Fur: " + fur;

    // set conditions to show correct colors
    if (timeStamp <= Time.time)
    {
      regHuntButton.colors = offCooldown;

    } // end timeStamp <= Time.time

    if (timeStamp > Time.time)
    {
      regHuntButton.colors = onCooldown;

    } // end timeStamp > Time.time

  } // end UPDATE

  // Update is called when button is clicked
  public void Clicked()
  {
    // add values if off cool down
    if (timeStamp <= Time.time)
    {
      timeStamp = Time.time + timeCooldown;
      teeth += teethClickIncrease;
      bone += boneClickIncrease;
      fur += furClickIncrease;

    } // end timeStamp <= Time.time

  } // end CLICKED

} // end CLASS