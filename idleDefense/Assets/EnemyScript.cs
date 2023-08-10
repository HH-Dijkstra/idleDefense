using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Health;
    public HealthBar script; 

    void Start()
    {
        Health = Random.Range(6, 12);
        script = GetComponentInChildren<HealthBar>();
        script.setMaxHealth(Health);
    }

    void Update()
    {
        if (Health <= 0)
        {
            Destroy(transform.parent.gameObject);
            Spawn.currentSpawn -= 1;
        }

        
    }

    void OnTriggerEnter2D(Collider2D HeartDamage)
    {
        if (HeartDamage.transform.CompareTag("Heart"))
        {
            Destroy(transform.parent.gameObject);

        }
    }
}
