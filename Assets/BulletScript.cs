using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject enemyTarget;
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> TargetList = GetComponentInParent<Tower>().TargetList;
        enemyTarget = getLowestHealth(TargetList);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget == null && !ReferenceEquals(enemyTarget, null))
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 currentPos = transform.position;
            Vector3 enemyPos = enemyTarget.transform.position;
            transform.position = Vector3.MoveTowards(currentPos, enemyPos, 5 * Time.deltaTime);

            if (transform.position == enemyPos)
            {
                enemyTarget.GetComponent<EnemyScript>().Health -= GetComponentInParent<Tower>().Damage;
                enemyTarget.GetComponentInChildren<HealthBar>().setHealth(enemyTarget.GetComponent<EnemyScript>().Health);
                Destroy(gameObject);
            }
        }
        
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
        Debug.Log(lowestHealth.ToString());
        return lowestHealthEnemy;


    }
}
