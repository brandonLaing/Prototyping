using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Manage_Players : MonoBehaviour
{

  public bool SetUpPlayers;

  public GameObject[] players;

  public GameObject playerSit;
  public GameObject playerFalling;

  public GameObject[] spawnPoints;

  public string[] arenas;

  public List<GameObject> deadPlayers = new List<GameObject>();

  public bool ableToLoad = true;

  bool loadNextScene = false;
  float loadTime = 0;

  public AudioSource mainAudioSource;
  public AudioSource playerAudioSource;

  public AudioClip explosion;

  private void Start()
  {
    DontDestroyOnLoad(gameObject);

    spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint").OrderBy(item => item.name).ToArray();
    mainAudioSource = GameObject.FindGameObjectWithTag("MainAudioListener").GetComponent<AudioSource>();
    playerAudioSource = GetComponent<AudioSource>();
    explosion = (AudioClip)Resources.Load("Audio/Map Explosion", typeof(AudioClip));

  }

  private void Update()
  {
    players = GameObject.FindGameObjectsWithTag("Player");

    if (deadPlayers.Count == players.Length && deadPlayers.Count > 0 && ableToLoad)
    {
      ableToLoad = false;
      MakeAllTilesFall();
      loadTime = Time.time + 2;
      deadPlayers = new List<GameObject>();
      loadNextScene = true;

    }

    if (loadNextScene && Time.time > loadTime)
    {
      LoadNextScene();
      loadNextScene = false;

    }
  }

  public void LoadNextScene()
  {
    foreach (GameObject player in players)
    {
      player.GetComponent<PlayerController>().StartedGame();

    }

    int tempRandomLevelNumber = Random.Range(0, arenas.Length);
    string tempRandomLevel = arenas[tempRandomLevelNumber];

    SceneManager.LoadScene(tempRandomLevel);
    SceneManager.sceneLoaded += OnSceneLoaded;

  }

  void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
  {
    spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

    for (int i = 0; i < players.Length; i++)
    {
      if (players[i] != null)
      {
        players[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        players[i].transform.position = spawnPoints[i].transform.position;

      }
    }
    
  }

  public void MakeAllTilesFall()
  {
    mainAudioSource.clip = explosion;
    mainAudioSource.Play();

    foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
    {
      tile.GetComponent<Rigidbody>().isKinematic = false;
      if (tile.GetComponent<MapTile>())
      {
        tile.GetComponent<MapTile>().PopShrink();

      }

      tile.GetComponent<Rigidbody>().velocity = new Vector3(UnityEngine.Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));

    }
  }

}
