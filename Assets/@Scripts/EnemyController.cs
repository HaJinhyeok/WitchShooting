using TreeEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Effect;
    public GameObject Coin;
    public GameObject Kit;

    int _currentHp = 3;
    Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
        Destroy(gameObject, 10f);
    }

    void Update()
    {
        transform.Translate(Vector3.down * 3 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            _currentHp--;
            _animator.SetTrigger("Hit");
            collision.gameObject.SetActive(false);
            if (_currentHp <= 0)
            {
                GameManager.Instance.Score += 5;
                Instantiate(Effect, transform.position, Quaternion.identity);
                ItemProcess.SpawnItemDel(transform.position);
                Destroy(gameObject);
            }
        }
    }
}
