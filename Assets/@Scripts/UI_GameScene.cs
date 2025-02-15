using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI_GameScene : MonoBehaviour
{
    public TMP_Text ScoreText;
    public Button PauseButton;
    public Image CurrentHp;

    int _tempScore;
    bool _isPaused = false;

    private void Start()
    {
        PauseButton.onClick.AddListener(OnPauseButtonClick);
    }

    void Update()
    {
        if (_tempScore != GameManager.Instance.Score)
        {
            // EnemyController에서 점수 변화가 일어날 때마다 갱신해주는게 좀 더 좋긴함
            _tempScore = GameManager.Instance.Score;
            ScoreText.text = GameManager.Instance.Score.ToString();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                Time.timeScale = 1.0f;
                _isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                _isPaused = true;
            }
        }

        float hp = PlayerController.Instance.HP / 100f;
        CurrentHp.fillAmount = hp;
    }

    void OnPauseButtonClick()
    {
        if(_isPaused)
        {
            Time.timeScale = 1.0f;
            _isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            _isPaused = true;
        }
    }
}
