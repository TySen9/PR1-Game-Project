using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.CompareTag("Projectile"))
            {
                gameManager.UpdateScore(5);
                Destroy(gameObject);
                Destroy(other.gameObject);
                //only targets steak and increases score
            }
            if (other.CompareTag("Out Of Bounds"))
            {
                if (gameManager.health > 0)
                {
                    gameManager.UpdateScore(-10);
                    gameManager.UpdateHealth(-1);
                }
            }
    }
}
