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
            // EnemyController에서 점수 변화가 일어날 때마다 갱신해주는게 좀 더 좋긴함
            _tempScore = GameManager.Instance.Score;
            ScoreText.text = GameManager.Instance.Score.ToString();
        }
    }
}
