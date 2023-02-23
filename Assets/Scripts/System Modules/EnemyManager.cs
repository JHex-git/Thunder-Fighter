using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public GameObject RandomEnemy => enemyList.Count == 0 ? null : enemyList[Random.Range(0, enemyList.Count)];
    public int WaveNumber => waveNumber;
    public float TimeBetweenWaves => timeBetweenWaves;
    [SerializeField] bool spawnEnemy = true;
    [SerializeField] GameObject waveUI;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] int minEnemyAmount = 4;
    [SerializeField] int maxEnemyAmount = 10;
    [SerializeField] float timeBetweenSpawns = 1f;

    int waveNumber = 1;
    int enemyAmount;

    List<GameObject> enemyList;
    WaitForSeconds waitTimeBetweenSpawns;
    WaitForSeconds waitTimeBetweenWaves;
    WaitUntil waitUntilNoEnemy;

    protected override void Awake()
    {
        base.Awake();

        waitTimeBetweenSpawns = new WaitForSeconds(timeBetweenSpawns);
        waitTimeBetweenWaves = new WaitForSeconds(timeBetweenWaves);
        waitUntilNoEnemy = new WaitUntil(() => enemyList.Count == 0);
        enemyList = new List<GameObject>();
    }
    IEnumerator Start()
    {
        while (spawnEnemy)
        {
            yield return waitUntilNoEnemy;
            waveUI.SetActive(true);
            yield return waitTimeBetweenWaves;
            waveUI.SetActive(false);
            yield return StartCoroutine(nameof(RandomlySpawnCoroutine));
        }
    }

    IEnumerator RandomlySpawnCoroutine()
    {
        enemyAmount = Mathf.Clamp(enemyAmount, minEnemyAmount + waveNumber / 3, maxEnemyAmount);
        for (int i = 0; i < enemyAmount; ++i)
        {
            enemyList.Add(PoolManager.Release(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)]));

            yield return waitTimeBetweenSpawns;
        }

        waveNumber += 1;
    }

    public void RemoveFromList(GameObject enemy) => enemyList.Remove(enemy);
}
