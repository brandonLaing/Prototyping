using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Stone : MonoBehaviour
{
  // get button to change colors
  public Button stoneButton;
  private ColorBlock offCooldown;
  private ColorBlock onCooldown;

  // set cool downs
  private float stoneCooldownTimer = 0.0F;

  public int stoneCooldownLength = 1;

  // set bool for button
  public bool stoneOffCooldown = true;

  //set resource manager object
  public GameObject resourceManager;


	// Use this for initialization
	void Start ()
  {
    // start timer
    stoneCooldownTimer = Time.time;

    // set up the button for colors
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
    //update stone button color and bool
    if (stoneCooldownTimer <= Time.time)
    {
      stoneOffCooldown = true;
      stoneButton.colors = offCooldown;

    }

    else
    {
      stoneOffCooldown = false;
      stoneButton.colors = onCooldown;

    }
		
	} // end UPDATE

  public void _WoodClicked()
  {
    Resource_Manager resourceManagerScript = resourceManager.GetComponent<Resource_Manager>();

    if (stoneOffCooldown)
    {
      stoneCooldownTimer = Time.time + stoneCooldownLength;
      resourceManagerScript.stone += resourceManagerScript.woodClickIncrease;

    } // end WOODOFFCOOLDOWN

  } // end CLICKED

} // end CLASS
