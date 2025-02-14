using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainScene : MonoBehaviour
{
    public Button StartButton;

    void Start()
    {
        StartButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }
}
