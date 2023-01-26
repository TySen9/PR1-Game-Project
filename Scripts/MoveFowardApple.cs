using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFowardApple : MonoBehaviour
{
    private float speed = 20.0f;
    private Rigidbody appleRb;
    private float spawnRangeX = 15;
    private float spawnPosZ = 20;

    // Start is called before the first frame update
    void Start()
    {
        appleRb = GetComponent<Rigidbody>();
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(UnityEngine.Vector3.forward * Time.deltaTime * speed);
    }

    Vector3 RandomSpawnPos()
    {
        return new UnityEngine.Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
    }
}
