using UnityEngine;

public class Coin : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        float posX = Random.Range(-100f, 100f);
        float posY = Random.Range(200f, 300f);
        _rigidbody.AddForce(new Vector3(posX, posY, 0));
        // 코인과 키트 일정 시간 후 비활성화
        Invoke("Deactivate", 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.Score += 1;
            gameObject.SetActive(false);
            CancelInvoke("Deactivate");
        }
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
