using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private int speed = 20;
    private float xRange = 15.0f;
    private GameManager gameManager;

    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        BoundsOfPlayer();
        ProjectileShoot();
        PlayerMovement();
    }

    void BoundsOfPlayer()
    {
        //Maximum position on the X axis a player can move
        if (transform.position.x < -xRange)
        {
            transform.position = new UnityEngine.Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new UnityEngine.Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    void ProjectileShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    void PlayerMovement()
    {
        //Movement of the player
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(UnityEngine.Vector3.right * horizontalInput * Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Golden Apple"))
        {
            Destroy(other.gameObject);
            if (gameManager.health < 5)
            {
                gameManager.UpdateHealth(1);
            }
        }
    }
}

