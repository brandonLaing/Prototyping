using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed;
  public bool touchingGround;

  public CheckPlayerInputs playerInputs;

  public GameObject shootTransform;
  public GameObject targetTransform;

  public GameObject[] players;
  public int playersIndex = 0;

  private void Awake()
  {
    playerInputs = GetComponent<CheckPlayerInputs>();

  }

  private void Update()
  {
    #region Movement
    if (touchingGround)
    {
      transform.position += playerInputs.leftJoystick * speed * Time.deltaTime;

    }

    #endregion

    #region Choosing Target
    if (players.Length > 0)
    {
      if (playerInputs.aButton)
      {
        playersIndex++;

      }

      if (playerInputs.bButton)
      {
        playersIndex--;

      }

      if (playersIndex < 0)
      {
        playersIndex = players.Length - 1;

      }

      if (playersIndex >= players.Length)
      {
        playersIndex = 0;

      }

      #endregion

      #region Looking at Target
      if (players[playersIndex] != null)
      {
        Vector3 playerTargetVector = players[playersIndex].transform.position;
        playerTargetVector.y = transform.position.y;
        gameObject.transform.LookAt(playerTargetVector);

      }

    }

    #endregion


    #region Projectile Targeting
    shootTransform.transform.position = transform.position + transform.forward * 1;

    targetTransform.transform.position = shootTransform.transform.position + transform.forward * 1;

    targetTransform.transform.position = targetTransform.transform.position + transform.right * playerInputs.rightJoystick.x;
    targetTransform.transform.position = targetTransform.transform.position + transform.up * playerInputs.rightJoystick.z;

    shootTransform.transform.LookAt(targetTransform.transform.position);

    #endregion

  }

  private void OnCollisionExit(Collision collision)
  {
    if (collision.transform.tag == "Tile")
    {
      touchingGround = false;
    }
  }
  private void OnCollisionStay(Collision collision)
  {
    if (collision.transform.tag == "Tile")
    {
      touchingGround = true;
    }
  }

  public void StartedGame()
  {
    DontDestroyOnLoad(this.gameObject);

    List<GameObject> tempPlayers = new List<GameObject>();

    foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
    {
      if (player == this.gameObject)
        continue;
      tempPlayers.Add(player);

    }

    players = tempPlayers.ToArray();

  }
}
