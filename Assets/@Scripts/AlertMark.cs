using System.Collections;
using UnityEngine;

public class AlertMark : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    Color _color;
    int _flag = 1;
    float _timeCount;
    Vector3 _target;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _color = _spriteRenderer.color;
        _timeCount = 0;
        StartCoroutine(Deactivate());
    }

    void Update()
    {
        Twinkle();
        Move();
    }

    void Twinkle()
    {
        if (_timeCount <= 3.0f)
        {
            if (_color.a <= 0.4f)
            {
                _flag = -1;
            }
            else if (_color.a >= 1.0f)
            {
                _flag = 1;
            }
            _color.a -= _flag * Time.deltaTime;

            _spriteRenderer.color = _color;
        }
        else
        {
            _color.a += Time.deltaTime * 2;
            _spriteRenderer.color = _color;

            // 1.5배까지 스케일 커지도록
            transform.localScale = Vector3.one * (_timeCount - 2f);

        }
            _timeCount += Time.deltaTime;
    }

    void Move()
    {
        _target = PlayerController.Instance.Pos;
        _target.y = 3;
        if (Vector3.Distance(_target, transform.position) > 0.01f)
        {
            transform.Translate((_target - transform.position).normalized * 0.5f * Time.deltaTime);
        }
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(3.5f);
        // gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
