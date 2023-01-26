using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAnimalsNew : MonoBehaviour
{
    private float animalspeed = 10.0f;
    private Rigidbody animalRb;
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;

    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        //Moves foward
        transform.Translate(UnityEngine.Vector3.forward * Time.deltaTime * animalspeed);
    }

    Vector3 RandomSpawnPos()
    {
        return new UnityEngine.Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
    }

}
