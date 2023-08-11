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
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            moveBullet(target);
        }
    }

    void moveBullet(GameObject target)
    {
        Vector3 current_position = transform.position; // Current position of the bullet
        Vector3 target_position = target.transform.position; // Current position of the target    

        // Check if the bullet has reached the target position within a certain threshold
        if (Vector3.Distance(current_position, target_position) < 0.1f)
        {
            // Log the damage dealt
            Debug.Log("bullet_pos == target_pos ");

            // Log enemy health
            Debug.Log("Enemy health: " + target.GetComponent<EnemyScript>().health);

            target.GetComponent<EnemyScript>().health -= damage; // Subtract the damage from the target's health
            target.GetComponentInChildren<HealthBar>().setHealth(target.GetComponent<EnemyScript>().health); // Update the health bar

            // Destroy the bullet as it has reached the target
            Destroy(gameObject);
        }
        else
        {
            // Log the current position of the bullet
            Debug.Log("Bullet position: " + current_position);
            Debug.Log("Target position: " + target_position);

            // Move the projectile towards the target with speed value
            transform.position = Vector3.MoveTowards(current_position, target_position, (speed * Time.deltaTime));
        }
    }
}
