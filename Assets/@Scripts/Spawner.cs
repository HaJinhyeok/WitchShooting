using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;

    Vector3 _initPos = new Vector3(-3, 6, 0);

    void Start()
    {
        StartCoroutine(CoSpawnEnemy());
    }

    IEnumerator CoSpawnEnemy()
    {
        Vector3 spawnPos = _initPos;

        for (int i = 0; i < 5; i++)
        {
            spawnPos.x += 1;
            Instantiate(Enemy, spawnPos, Quaternion.identity);
        }
        yield return new WaitForSeconds(2.5f);
        StartCoroutine(CoSpawnEnemy());
    }
}
