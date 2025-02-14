using UnityEngine;

public class Coin : MonoBehaviour
{
    Rigidbody2D _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float posX = Random.Range(-50f, 50f);
        float posY = Random.Range(200f, 300f);
        _rigidbody.AddForce(new Vector3(posX, posY, 0));
        Destroy(gameObject, 10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            GameManager.Instance.Score += 1;
            Destroy(gameObject);
        }
    }
}
