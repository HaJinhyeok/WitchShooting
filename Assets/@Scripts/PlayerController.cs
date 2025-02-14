using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float Speed = 3f;
    
    
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
            SceneManager.LoadScene("Result");
        }
    }
}
