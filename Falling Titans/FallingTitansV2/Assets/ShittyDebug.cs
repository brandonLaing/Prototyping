using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShittyDebug : MonoBehaviour {
  public string playerOneNumber;
  public string playerTwoNumber;

  public float playerOneRightTrigger;
  public float playerOneLeftTrigger;

  public float playerTwoLeftTrigger;
  public float playerTwoRightTrigger;

  public string controllerAdd;

  private void Update()
  {
    playerOneRightTrigger = Input.GetAxis(playerOneNumber + "RightTrigger");
    playerOneLeftTrigger = Input.GetAxis(playerOneNumber + "LeftTrigger");


    playerTwoLeftTrigger = Input.GetAxis(playerTwoNumber + "LeftTrigger");

    playerTwoRightTrigger = Input.GetAxis(playerTwoNumber + "RightTrigger");

    #region CheckJoyStickStart
    if (Input.GetButtonDown("P1StartButton"))
    {
      controllerAdd = "P1";

    }

    if (Input.GetButtonDown("P2StartButton"))
    {
      controllerAdd = "P2";

    }

    if (Input.GetButtonDown("P3StartButton"))
    {
      controllerAdd = "P3";

    }

    if (Input.GetButtonDown("P4StartButton"))
    {
      controllerAdd = "P4";

    }

    if (Input.GetButtonDown("P5StartButton"))
    {
      controllerAdd = "P5";

    }

    if (Input.GetButtonDown("P6StartButton"))
    {
      controllerAdd = "P6";


    }

    if (Input.GetButtonDown("P7StartButton"))
    {
      controllerAdd = "P7";

    }

    if (Input.GetButtonDown("P8StartButton"))
    {
      controllerAdd = "P8";

    }

    //if (Input.GetButtonDown("P9StartButton"))
    //{
    //  controllerAdd = "P9";

    //}

    //if (Input.GetButtonDown("P10StartButton"))
    //{
    //  controllerAdd = "P10";

    //}

    //if (Input.GetButtonDown("P11StartButton"))
    //{
    //  controllerAdd = "P11";

    //}

    //if (Input.GetButtonDown("P12StartButton"))
    //{
    //  controllerAdd = "P12";

    //}

    //if (Input.GetButtonDown("P13StartButton"))
    //{
    //  controllerAdd = "P13";

    //}

    //if (Input.GetButtonDown("P14StartButton"))
    //{
    //  controllerAdd = "P14";

    //}

    //if (Input.GetButtonDown("P15StartButton"))
    //{
    //  controllerAdd = "P15";

    //}

    //if (Input.GetButtonDown("P16StartButton"))
    //{
    //  controllerAdd = "P16";

    //}
    #endregion


  }

}
