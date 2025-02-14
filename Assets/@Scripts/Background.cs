using UnityEngine;

public class Background : MonoBehaviour
{
    public GameObject[] Backgrounds;
    public float Speed = 5;

    private void FixedUpdate()
    {
        for (int i = 0; i < Backgrounds.Length; i++)
        {
            // 아래로 이동
            Backgrounds[i].transform.position +=
                Vector3.down * Speed * Time.deltaTime;

            if (Backgrounds[i].transform.position.y<-8)
            {
                Backgrounds[i].transform.position =
                    new Vector3(0, 15.5f, 0);
            }
        }
    }
}
