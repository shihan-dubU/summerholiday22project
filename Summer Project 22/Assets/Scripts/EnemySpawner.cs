using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] EnemyReference;

    private GameObject spawnedEnemy;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            randomIndex = Random.Range(0, EnemyReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedEnemy = Instantiate(EnemyReference[randomIndex]); // Random enemy is spawned

            // Left side
            if (randomSide == 0)
            {
                spawnedEnemy.transform.position = leftPos.position;
                spawnedEnemy.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else
            {
                spawnedEnemy.transform.position = rightPos.position;
                // right side
            }
        }
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}


































