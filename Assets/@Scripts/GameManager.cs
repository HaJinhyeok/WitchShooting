using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern 사용
    #region SingleTon
    // * 싱글톤 패턴
    // - 객체의 인스턴스가 오직 1개인 패턴
    // - 메모리 낭비를 방지한다.
    // - 다른 클래스간의 데이터 공유가 쉽다.
    //
    private static GameManager s_instance = null;
    public static GameManager Instance
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
        if (s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // 값이 있다면 (중복되었다면)
        {
            Destroy(gameObject);
        }

    }
    #endregion

    private int _score = 0;
    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            if (_score > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", _score);
            }
        }
    }

    public int BestScore { get => PlayerPrefs.GetInt("Score"); }
}
