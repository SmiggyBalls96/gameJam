using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Enemy gameobject")]
    [SerializeField] private GameObject enemy;

    [Space]

    [Header("Spawning area")]
    [SerializeField] private Vector2 Point1;
    [SerializeField] private Vector2 Point2;

    [Space]

    [Header("Enemy spawning data")]
    [SerializeField] private int enemiesToSpawn;
    [SerializeField] private float minTimePerSpawn;
    [SerializeField] private float maxTimePerSpawn;

    private float timeToWait;

    public List<GameObject> enemies;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //when the player enters the room (detected using a trigger), start spawning enemies
        if(other.CompareTag("Player"))
            StartCoroutine(spawn());
    }

    private IEnumerator spawn()
    {
        for(int i=0; i<enemiesToSpawn; i++)
        {
            timeToWait = Random.Range(minTimePerSpawn, maxTimePerSpawn); //calculate a random spawning time for the next enemy

            //get random spawn position
            float x = Random.Range(Point1.x, Point2.x);
            float y = Random.Range(Point1.y, Point2.y);

            Vector2 spawnPos = new Vector2(x, y);

            enemies.Add(Instantiate(enemy, spawnPos, Quaternion.identity));
            enemies[enemies.Count - 1].SetActive(true);

            Enemy.EnemyTypes randomType = (Enemy.EnemyTypes)Random.Range(0, Enemy.enemyTypeCount);
            enemies[enemies.Count - 1].GetComponent<Enemy>().SetEnemyType(randomType);

            yield return new WaitForSeconds(timeToWait);
        }
    }
}
