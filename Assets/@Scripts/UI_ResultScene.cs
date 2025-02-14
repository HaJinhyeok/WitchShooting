using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_ResultScene : MonoBehaviour
{
    public TMP_Text CurrentScoreText;
    public TMP_Text BestScoreTetxt;

    public Button MainButton;
    public Button RetryButton;

    void Start()
    {
        CurrentScoreText.text = $"CurrentScore : {GameManager.Instance.Score}";
        BestScoreTetxt.text = $"BestScore : {GameManager.Instance.BestScore}";
        MainButton.onClick.AddListener(OnMainButtonClick);
        RetryButton.onClick.AddListener(OnRetryButtonClick);
    }

    void OnMainButtonClick()
    {
        SceneManager.LoadScene("Main");
    }

    void OnRetryButtonClick()
    {
        SceneManager.LoadScene("Game");
    }

}
