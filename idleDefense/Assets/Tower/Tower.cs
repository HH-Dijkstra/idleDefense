using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Range;
    public float Damage;
    public float Speed;
    public float BulletSpeed;
    public float Targets;
    public float CritChance;
    public float CritMulti;
    public float timer = 0;
    public Vector3 currentPos;
    public GameObject TowerObject;
    public GameObject Bullet;
    public List<GameObject> TargetList = new();
    List<GameObject> BulletList = new();


    // Start is called before the first frame update
    void Start()
    {
        Range = 5;
        Damage = 3;
        BulletSpeed = 1f;
        CircleCollider2D TowerRadius = TowerObject.GetComponent<CircleCollider2D>();
        TowerRadius.radius = Range;
        currentPos = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void Update()
    {
        if (TargetList.Count != 0)
        {
            if (timer > Speed)
            {
                shootBullet();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
            
        }

    }

    void OnTriggerEnter2D(Collider2D Shoot)
    {
        if (Shoot.transform.CompareTag("Enemy"))
        {
            TargetList.Add(Shoot.gameObject);
            
        }
    }

    private void OnTriggerExit2D(Collider2D leave)
    {
        if (leave.transform.CompareTag("Enemy"))
        {
            TargetList.Remove(leave.gameObject);
        }
    }

    void shootBullet()
    {
        GameObject newBullet = Instantiate(Bullet, currentPos, transform.rotation);
        newBullet.transform.parent = transform;
    }

    GameObject getLowestHealth(List<GameObject> TargetList)
    {
        
        if (TargetList.Count == 0)
        {
            return null;        
        }

        float lowestHealth = Mathf.Infinity;
        GameObject lowestHealthEnemy = null;
        foreach (GameObject enemy in TargetList)
        {
            float Health = enemy.GetComponent<EnemyScript>().Health;
            if (lowestHealth > Health)
            {
                lowestHealth = Health;
                lowestHealthEnemy = enemy;
            }
        }
        return lowestHealthEnemy;

        
    }
}
