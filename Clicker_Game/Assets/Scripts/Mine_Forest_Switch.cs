using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mine_Forest_Switch : MonoBehaviour
{
  public bool inForest = true;
  public bool inMine = false;

  public Text switchButtonDisplay;

  public GameObject forestDisplay;
  public GameObject mineDisplay;

	// Update is called once per frame
	void Update ()
  {
    if (inForest)
    {
      switchButtonDisplay.text = "Go to mine";

    }

    if (inMine)
    {
      switchButtonDisplay.text = "Go to forest";

    }
		
	} // end update

  public void _SwitchButton()
  {
    if (inForest)
    {
      forestDisplay.gameObject.SetActive(false);
      inForest = false;
      mineDisplay.gameObject.SetActive(true);
      inMine = true;

    }

    else if (inMine)
    {
      mineDisplay.gameObject.SetActive(false);
      inMine = false;
      forestDisplay.gameObject.SetActive(true);
      inForest = true;

    }
  }
}
