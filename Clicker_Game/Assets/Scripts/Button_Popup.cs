using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Button_Popup : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
  public GameObject textBox;

  private Vector2 originUpgradeBoxPosition;

  private bool pointerOverBox = false;

  void Start()
  {
    textBox.SetActive(false);
    originUpgradeBoxPosition = textBox.transform.position;
  }

  public void OnPointerEnter(PointerEventData eventData)
  {
    pointerOverBox = true;
  }

  public void OnPointerExit(PointerEventData eventData)
  {
    pointerOverBox = false;
  }

  private void Update()
  {
    if (pointerOverBox)
    {
      Vector2 mousePosition = new Vector2(Input.mousePosition.x + 220, Input.mousePosition.y - 25);
      textBox.transform.position = mousePosition;
      textBox.SetActive(true);

    } // end POINTER OVER BOX

    else
    {
      textBox.SetActive(false);
      textBox.transform.position = originUpgradeBoxPosition;

    }

  } // end UPDATE

} // end CLASS
