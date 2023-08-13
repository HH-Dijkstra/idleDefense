using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // target is the object that the projectile is currently tracking
    public GameObject target;

    // Bullet stats
    public float damage;
    public float speed;
    public float crit_chance;
    public float crit_multi;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            move(target);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void move(GameObject target)
    {
        Vector3 current_position = transform.position; // Current position of the bullet
        Vector3 target_position = target.transform.position; // Current position of the target    

        // Check if the bullet has reached the target position within a certain threshold
        if (Vector3.Distance(current_position, target_position) < 0.1f)
        {
            target.GetComponent<EnemyScript>().takeDamage(calculateDamage(damage, crit_chance, crit_multi)); // Subtract the damage from the target's health

            // Destroy the bullet as it has reached the target
            Destroy(gameObject);
        }
        else
        {
            // Move the projectile towards the target with speed value
            transform.position = Vector3.MoveTowards(current_position, target_position, (speed * Time.deltaTime));
        }
    }


    float calculateDamage(float damage, float crit_chance, float crit_multi)
    {
        float crit = Random.Range(0.0f, 1.0f); // Generate a random number between 0 and 1

        // Check if the crit is less than the crit chance
        if (crit < crit_chance)
        {
            // Return the damage multiplied by the crit multiplier
            return damage * crit_multi;
        }
        else
        {
            // Return the damage
            return damage;
        }
    }
}
