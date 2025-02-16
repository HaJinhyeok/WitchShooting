using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemy;
    public GameObject Meteo;

    Vector3 _initPos = new Vector3(-3, 6, 0);

    void Start()
    {
        StartCoroutine(CoSpawnEnemy());
    }

    IEnumerator CoSpawnEnemy()
    {
        Vector3 spawnPos = _initPos;
        int currentEnemy = Random.Range(0, Enemy.Length);
        for (int i = 0; i < 5; i++)
        {
            spawnPos.x += 1;
            Instantiate(Enemy[currentEnemy], spawnPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(CoSpawnEnemy());
    }
}
