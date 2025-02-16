using System.Collections;
using UnityEngine;

public class MeteoEvent : MonoBehaviour
{
    public GameObject AlertLine;
    public GameObject AlertMark;
    public GameObject Meteo;

    Vector3 _currentPos;

    void Start()
    {
        StartCoroutine(CoStartAlert());
    }

    IEnumerator CoStartAlert()
    {
        Vector3 randPos = new Vector3(Random.Range(-2f, 2f), 0, 0);
        GameObject line = Instantiate(AlertLine, randPos, Quaternion.identity);
        GameObject mark = Instantiate(AlertMark, randPos + new Vector3(0, 3, 0), Quaternion.identity);
        
        yield return new WaitForSeconds(3.3f);
        _currentPos = line.transform.position;
        // StartCoroutine(CoStartAlert());
        StartCoroutine(CoSpawnMeteo());
    }

    IEnumerator CoSpawnMeteo()
    {
        Vector3 spawnPos = _currentPos + new Vector3(0, 8, 0);
        Instantiate(Meteo, spawnPos, Quaternion.identity);

        yield return new WaitForSeconds(8f);
        StartCoroutine(CoStartAlert());
    }
}
