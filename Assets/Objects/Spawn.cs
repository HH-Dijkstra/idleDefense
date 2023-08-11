using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 10;
    public float timer = 0;
    public float heightOffset = 1;
    public float maxSpawn = 1;
    public static float currentSpawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnEnemy();
            timer = 0;
        }

    }
    void spawnEnemy()
    {
        float lowestPoint = transform.position.y;
        float highestPoint = transform.position.y + heightOffset;

        if (currentSpawn < maxSpawn)
        {
            currentSpawn += 1;
            Instantiate(enemy, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }

    }
}
