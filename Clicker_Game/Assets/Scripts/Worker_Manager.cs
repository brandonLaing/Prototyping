using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Worker_Manager : MonoBehaviour {
  // link to display boxes for workers
  public Text workersIdleDisplay;

  public Text workerWoodDisplay;
  public Text workerStoneDisplay;

  public Text workersHuntDisplay;
  public Text workersMHuntDisplay;
  public Text workersFisherDisplay;

  public Text workersHerbDisplay;

  public Text workersMinerDisplay;


  //set up variables for each worker type
  public int workersIdle;

  public int workersWood;
  public int workersStone;

  public int workersRegularHunt;
  public int workersMonsterHunt;
  public int workersFisher;

  public int workersHerb;

  public int workersMine;

  public int totalWorkers;

  // Update is called once per frame
  void Update ()
  {
    // find total workers
    totalWorkers = workersIdle + workersWood + workersStone + workersRegularHunt + workersMonsterHunt
      + workersFisher + workersHerb + workersMine;
    // set displays for each worker type
    workersIdleDisplay.text = "Idle workers: " + workersIdle + " / " + totalWorkers;

    workerWoodDisplay.text = "Lumberjacks: " + workersWood;
    workerStoneDisplay.text = "Stone gatherer: " + workersStone;

    workersHuntDisplay.text = "Hunter: " + workersRegularHunt;
    workersMHuntDisplay.text = "Monster Hunter: " + workersMonsterHunt;
    workersFisherDisplay.text = "Fisher: " + workersFisher;

    workersHerbDisplay.text = "Herbalist: " + workersHerb;

    workersMinerDisplay.text = "Miner: " + workersMine;
    		
	} // end UPDATE

  // Update is called when worker up button is pressed
  public void _woodWorkerUp()
  {
    // check if there are enough idle workers to pull from then move them to wood worker and out of idle worker
    if (workersIdle > 0)
    {
      workersWood += 1;
      workersIdle -= 1;
    }

  } // end WOODWORKERUP

  // Update is called when worker down button is pressed
  public void _woodWorkerDown()
  {
    // check if their are enough wood workers to pull from and if there are remove from wood and move to idle
    if (workersWood > 0)
    {
      workersIdle += 1;
      workersWood -= 1;
    }

  } // end WOODWORKERDOWN

  // Update is called when worker up button is pressed
  public void _stoneWorkerUp()
  {
    // check if there are enough idle workers to pull from then move them to stone worker and out of idle worker
    if (workersIdle > 0)
    {
      workersStone += 1;
      workersIdle -= 1;
    }

  } // end STONEWORKERUP

  // Update is called when worker down button is pressed
  public void _stoneWorkerDown()
  {
    // check if their are enough stone workers to pull from and if there are remove from stone and move to idle
    if (workersStone > 0)
    {
      workersIdle += 1;
      workersStone -= 1;
    }

  } // end STONEWORKERDOWN

  // Update is called when worker up button is pressed
  public void _regularHunterWorkerUp()
  {
    // check if there are enough idle workers to pull from then move them to regularHunt worker and out of idle worker
    if (workersIdle > 0)
    {
      workersRegularHunt += 1;
      workersIdle -= 1;
    }

  } // end REGULARHUNTWORKERUP

  // Update is called when worker down button is pressed
  public void _regularHunterWorkerDown()
  {
    // check if their are enough regularHunt workers to pull from and if there are remove from regularHunt and move to idle
    if (workersRegularHunt > 0)
    {
      workersIdle += 1;
      workersRegularHunt -= 1;
    }

  } // end REGULARHUNTWORKERDOWN

  // Update is called when worker up button is pressed
  public void _monsterHunterWorkerUp()
  {
    // check if there are enough idle workers to pull from then move them to monsterHunt worker and out of idle worker
    if (workersIdle > 0)
    {
      workersMonsterHunt += 1;
      workersIdle -= 1;
    }

  } // end MONSTERHUNTERWORKERUP

  // Update is called when worker down button is pressed
  public void _monsterHunterWorkerDown()
  {
    // check if their are enough monsterHunt workers to pull from and if there are remove from monsterHunt and move to idle
    if (workersMonsterHunt > 0)
    {
      workersIdle += 1;
      workersMonsterHunt -= 1;
    }

  } // end MONSTERHUNTERWORKERDOWN

  // Update is called when worker up button is pressed
  public void _FisherWorkerUp()
  {
    // check if there are enough idle workers to pull from then move them to monsterHunt worker and out of idle worker
    if (workersIdle > 0)
    {
      workersFisher += 1;
      workersIdle -= 1;
    }

  } // end MONSTERHUNTERWORKERUP

  // Update is called when worker down button is pressed
  public void _FisherWorkerDown()
  {
    // check if their are enough monsterHunt workers to pull from and if there are remove from monsterHunt and move to idle
    if (workersFisher > 0)
    {
      workersIdle += 1;
      workersFisher -= 1;
    }

  } // end MONSTERHUNTERWORKERDOWN

  // Update is called when worker up button is pressed
  public void _HerbalistWorkerUp()
  {
    // check if there are enough idle workers to pull from then move them to monsterHunt worker and out of idle worker
    if (workersIdle > 0)
    {
      workersHerb += 1;
      workersIdle -= 1;
    }

  } // end MONSTERHUNTERWORKERUP

  // Update is called when worker down button is pressed
  public void _HerbalistWorkerDown()
  {
    // check if their are enough monsterHunt workers to pull from and if there are remove from monsterHunt and move to idle
    if (workersHerb > 0)
    {
      workersIdle += 1;
      workersHerb -= 1;
    }

  } // end MONSTERHUNTERWORKERDOWN

  // Update is called when worker up button is pressed
  public void _MineWorkerUp()
  {
    // check if there are enough idle workers to pull from then move them to monsterHunt worker and out of idle worker
    if (workersIdle > 0)
    {
      workersMine += 1;
      workersIdle -= 1;
    }

  } // end MONSTERHUNTERWORKERUP

  // Update is called when worker down button is pressed
  public void _MineWorkerDown()
  {
    // check if their are enough monsterHunt workers to pull from and if there are remove from monsterHunt and move to idle
    if (workersMine > 0)
    {
      workersIdle += 1;
      workersMine -= 1;
    }

  } // end MONSTERHUNTERWORKERDOWN

} // end CLASS