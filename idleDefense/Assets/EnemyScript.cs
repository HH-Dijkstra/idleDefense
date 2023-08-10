using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float Health;
    public HealthBar script;
    public int MoneyDrop;

    void Start()
    {
        MoneyDrop = 1;
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
            StatsHandeler.playerMoney += MoneyDrop;
        }

        
    }

    void OnTriggerEnter2D(Collider2D HeartDamage)
    {
        if (HeartDamage.transform.CompareTag("Heart"))
        {   
            Destroy(transform.parent.gameObject);
            Spawn.currentSpawn -= 1;
            StatsHandeler.playerMoney -= MoneyDrop;
        }
    }
}
