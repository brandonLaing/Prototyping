using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Game : MonoBehaviour
{

	// Use this for initialization
	void Start ()
  {
    GameObject temp = GameObject.FindGameObjectWithTag("GameController");

    if (temp == null)
    {
      DontDestroyOnLoad(this.gameObject);
      tag = "GameController";

    } // end if null

    else
    {
      Destroy(this.gameObject);

    }

  } // end Start
	
	// Update is called once per frame
	void Update ()
  {
		
	} // end Update
}
