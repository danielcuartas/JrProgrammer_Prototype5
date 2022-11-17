using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosion;

    float xRange = 5;
    float ySpawn = -3;
    float maxTorque = 10;
    float minForce = 12;
    float maxForce = 16;

    public int pointValue;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        transform.position = RandomPos();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosion, transform.position, explosion.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
            gameManager.isGameActive = false;
        }
        Destroy(gameObject);
    }
    Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawn);
    }

    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque));
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
