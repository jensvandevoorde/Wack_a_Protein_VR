using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProteinSpawn : MonoBehaviour
{
    public GameObject[] protein;
    public int xPos;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    public int zPos;
    public float currentTime = 0f;
    public float startingTime = 60f;
    [SerializeField] Text countdownTimer;




    //Begint het spel
    void StartGame()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        countdownTimer.text = currentTime.ToString("0");
        if (currentTime <= 0)
        {
            currentTime = 0;
            countdownTimer.text = "Start New Game";

        }
    }

    //Trigger om het spel te beginnen
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Hammer")
        {
            InvokeRepeating("SpawnProtein", spawnTime, spawnDelay);
            StartGame();

        }


    }



    void SpawnProtein()
    {
        xPos = Random.Range(-1, 1);
        zPos = Random.Range(-1, 1);
        int prefab_num = Random.Range(0, 11);
        GameObject RigidPrefab;

        RigidPrefab = Instantiate(protein[prefab_num], new Vector3(xPos, 0, zPos), Quaternion.identity);
        if (stopSpawning || currentTime <= 0)
        {
            CancelInvoke("SpawnProtein");
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
