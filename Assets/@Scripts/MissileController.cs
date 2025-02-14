using System.Collections;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    
    void OnEnable()
    {
        StartCoroutine(CoDeactivate());
    }

    
    void Update()
    {
        transform.Translate(Vector3.up * 5 * Time.deltaTime);
    }

    IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(10);
        gameObject.SetActive(false);
    }
}
