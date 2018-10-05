using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Wood : MonoBehaviour
{
  // get button to change colors
  private Button woodButton;
  private ColorBlock offCooldown;
  private ColorBlock onCooldown;

  // set cool downs
  private float woodCooldownTimer = 0.0F;

  public int woodCooldownLength = 1;

  // set bool for button
  public bool woodOffCooldown = true;

  //set resource manager object
  public GameObject resourceManager;

  // Use this for initialization
  void Start ()
  {
    // start timer
    woodCooldownTimer = Time.time;

    // set up the button for colors
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
    // update wood button color and bool
    if (woodCooldownTimer <= Time.time)
    {
      woodOffCooldown = true;
      woodButton.colors = offCooldown;

    }

    else
    {
      woodOffCooldown = false;
      woodButton.colors = onCooldown;

    }
   
  } // end UPDATE

  public void _Clicked()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (woodOffCooldown)
    {
      woodCooldownTimer = Time.time + woodCooldownLength;
      resourceManagerScript.wood += resourceManagerScript.woodClickIncrease;

    } // end WOODOFFCOOLDOWN

  } // end CLICKED

} // end CLASS
