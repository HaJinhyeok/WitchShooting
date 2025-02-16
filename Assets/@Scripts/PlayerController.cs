using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3f;

    #region SingleTon

    private static PlayerController s_instance = null;
    
    public static PlayerController Instance
    {
        get
        {
            if (s_instance == null)
                return null;
            return s_instance;
        }
    }

    private void Awake()
    {
        if(s_instance == null)
        {
            s_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    const int _maxHp = 100;
    int _currentHp = 100;

    public int HP
    {
        get { return _currentHp; }
        set
        {
            _currentHp = value;
            if (_currentHp <= 0) _currentHp = 0;
            else if (_currentHp >= _maxHp) _currentHp = _maxHp;
        }
    }

    public Vector3 Pos
    {
        get { return transform.position; }
    }

    void Update()
    {
        if(Input.GetButton("Horizontal"))
        {
            float h = Input.GetAxisRaw("Horizontal");

            transform.Translate(Vector3.right * h * Speed * Time.deltaTime);

            Vector3 currentPos = transform.position;
            // -2~2 사이값만 가질 수 있도록 조정
            currentPos.x = Mathf.Clamp(transform.position.x, -2, 2);
            transform.position = currentPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            _currentHp -= 20;
            Destroy(collision.gameObject);
            // 게임 종료
            if (_currentHp <= 0)
            {
                Die();
            }
        }
        if(collision.CompareTag("Meteo"))
        {
            _currentHp -= 40;
            Destroy(collision.gameObject);
            if (_currentHp <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Result");
    }
}
