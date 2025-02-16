using System.Collections;
using UnityEngine;

public class HealthKit : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float posX = Random.Range(-50f, 50f);
        float posY = Random.Range(200f, 300f);
        _rigidbody.AddForce(new Vector3(posX, posY, 0));
        // ���ΰ� ŰƮ ���� �ð� �� ��Ȱ��ȭ
        StartCoroutine(Deactivate());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController.Instance.HP += 30;
            gameObject.SetActive(false);
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
