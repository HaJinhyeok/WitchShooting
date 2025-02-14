using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Pattern ���
    #region SingleTon
    // * �̱��� ����
    // - ��ü�� �ν��Ͻ��� ���� 1���� ����
    // - �޸� ���� �����Ѵ�.
    // - �ٸ� Ŭ�������� ������ ������ ����.
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
        else // ���� �ִٸ� (�ߺ��Ǿ��ٸ�)
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
