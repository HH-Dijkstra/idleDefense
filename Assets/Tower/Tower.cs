using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // Tower prefab
    public GameObject TowerObject;

    // Bullet prefab
    public GameObject Bullet;

    // Tower stats
    public float range;
    public float fire_rate;
    public float total_targets;
    public Vector3 position;

    // Bullet stats
    public float bullet_speed;
    public float bullet_damage;
    public float bullet_crit_chance;
    public float bullet_crit_multi;

    // Lists
    public List<GameObject> target_list = new();

    public float timer = 0; // Timer for the tower to shoot

    // Start is called before the first frame update
    void Start()
    {
        range = 20.0f;
        bullet_damage = 3.0f;
        bullet_speed = 1.0f;

        CircleCollider2D tower_radius = TowerObject.GetComponent<CircleCollider2D>();
        tower_radius.radius = range;

        position = new Vector3(transform.position.x, transform.position.y, 0); // Get the position of the tower
    }

    void Update()
    {
        if (targetAvailable(target_list)) // Check if the target list contains any valid targets
        {
            // Check if the tower has reloaded yet
            if (timer < fire_rate)
            {
                timer = timer + Time.deltaTime;
            }
            else
            {
                shootBullet();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D shoot)
    {
        if (shoot.transform.CompareTag("Enemy"))
        {
            target_list.Add(shoot.gameObject);

        }
    }

    private void OnTriggerExit2D(Collider2D leave)
    {
        if (leave.transform.CompareTag("Enemy"))
        {
            target_list.Remove(leave.gameObject);
        }
    }

    bool targetAvailable(List<GameObject> target_list) => target_list.Count > 0 ? true : false; // if target list is greater than 0 return true else return false

    GameObject acquireTarget(List<GameObject> target_list)
    {
        if (target_list.Count == 0)
        {
            return null;
        }

        float lowest_health = Mathf.Infinity;
        GameObject lowest_health_target = null;

        foreach (GameObject target in target_list)
        {
            // Check if target is null
            if (target != null)
            {
                bool marked_for_death = target.GetComponent<EnemyScript>().marked_for_death; // Get the marked for death status of the target
                if (marked_for_death)
                {
                    // Log target marked for death
                    Debug.Log("Target marked for death, continuing");
                    continue;
                }

                float health = target.GetComponent<EnemyScript>().health; // Get the health of the target
                if (lowest_health > health)
                {
                    lowest_health = health;
                    lowest_health_target = target;
                }
            }
        }
        return lowest_health_target;
    }

    void shootBullet()
    {
        // Acquire a target
        GameObject target = acquireTarget(target_list);

        // Check if the target is still alive
        if (target != null)
        {
            // Log firing bullet
            Debug.Log("Firing bullet");

            // Create a new projectile
            GameObject new_projectile = Instantiate(Bullet, position, transform.rotation);

            // Set the projectile's parent to the tower. Because when the tower is destroyed, we want the projectiles to be destroyed as well.
            new_projectile.transform.parent = transform;

            // Set the projectile's target and other values
            new_projectile.GetComponent<BulletScript>().target = target;
            new_projectile.GetComponent<BulletScript>().damage = bullet_damage;
            new_projectile.GetComponent<BulletScript>().speed = bullet_speed;
            new_projectile.GetComponent<BulletScript>().crit_chance = bullet_crit_chance;
            new_projectile.GetComponent<BulletScript>().crit_multi = bullet_crit_multi;

            // Add the projectile to the target's projectile list
            target.GetComponent<EnemyScript>().incoming_projectiles.Add(new_projectile);

            // Reset the timer
            timer = 0;
        }
    }
}