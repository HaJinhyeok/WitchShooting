using UnityEngine;
using TMPro;

public class UI_GameScene : MonoBehaviour
{
    public TMP_Text ScoreText;
    int _tempScore;

    void Update()
    {
        if (_tempScore != GameManager.Instance.Score)
        {
            // EnemyController���� ���� ��ȭ�� �Ͼ ������ �������ִ°� �� �� ������
            _tempScore = GameManager.Instance.Score;
            ScoreText.text = GameManager.Instance.Score.ToString();
        }
    }
}
