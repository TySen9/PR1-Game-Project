using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManagerPowerup : MonoBehaviour
{
    private GameManager gameManager;
    //Makes an array to store gameobjects in called animal prefabs
    public List<GameObject> powerup;
    private float spawnInterval = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        //Repeats SpawnRandomSpawn starting from startDelay and every spawnInterval
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTarget()
    {
        while (gameManager.isGameActive)
        {
            yield return new WaitForSeconds(spawnInterval);
            int index = Random.Range(0, powerup.Count);
            Instantiate(powerup[index]);
        }
    }
}
