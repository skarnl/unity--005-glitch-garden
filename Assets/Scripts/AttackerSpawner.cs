using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;

    [SerializeField]
    private bool canSpawn = true;

    private float lastYPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemyLoop());
    }

    IEnumerator SpawnEnemyLoop()
    {
        while (canSpawn)
        {
            float randomTimeDelay = 0.7f;//Random.Range(1f, 5f);

            yield return new WaitForSeconds(randomTimeDelay);

            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        float randomYPosition;

        do
        {
            randomYPosition = Mathf.Round(Random.Range(1f, 4f)) + 0.3f;
        } while (randomYPosition == lastYPosition);

        lastYPosition = randomYPosition;

        Instantiate(enemyPrefab, new Vector2(9.6f, randomYPosition), Quaternion.identity);
    }
}
