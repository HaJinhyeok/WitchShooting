using System.Collections;
using UnityEngine;

public class MeteoController : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(CoDeactivate());
    }

    void Update()
    {
        transform.Translate(Vector3.down * 5 * Time.deltaTime);
    }

    IEnumerator CoDeactivate()
    {
        yield return new WaitForSeconds(5);
        // gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
