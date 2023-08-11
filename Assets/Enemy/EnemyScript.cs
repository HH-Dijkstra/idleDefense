using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    // Enemy stats
    public float health;
    public HealthBar script;
    public int money_drop;

    public bool marked_for_death; // If the enemy is marked for death, the total amount of damage of projectiles en route is more than the enemy's health
    public List<GameObject> incoming_projectiles = new(); // List of projectiles that are en route to the enemy

    void Start()
    {
        health = 5;
        money_drop = 1;

        // Set the health bar, as a child of the enemy
        script = GetComponentInChildren<HealthBar>();
        script.setMaxHealth(health);

        marked_for_death = false;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
            Spawn.currentSpawn -= 1;
            StatsHandeler.playerMoney += money_drop;
        }

        if (getIncomingDamage() >= health)
        {
            marked_for_death = true; // If the total damage of projectiles en route is more than the our health, marked for death
        }
    }

    void OnTriggerEnter2D(Collider2D HeartDamage)
    {
        if (HeartDamage.transform.CompareTag("Heart"))
        {
            Destroy(transform.parent.gameObject);
            Spawn.currentSpawn -= 1;
            StatsHandeler.playerMoney -= money_drop;
        }
    }

    public float getIncomingDamage()
    {
        float incoming_damage = 0;

        foreach (GameObject incoming_projectile in incoming_projectiles)
        {
            incoming_damage += incoming_projectile.GetComponent<BulletScript>().damage;
        }

        return incoming_damage;
    }
}
