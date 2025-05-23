using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance => _instance;

    #region Fields
    [SerializeField] private float _timerStartValue = 100f;

    private int _score = 0;
    private float _timer = 0f;
    #endregion Fields

    #region Properties
    public int Score => _score;
    public float Timer => _timer;
    #endregion Properties

    #region Methods
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _score = 0;
        _timer = _timerStartValue;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            Debug.Log("Game over");
            _timer = 0f;
        }
    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public void RemoveScore(int score)
    {
        if (_score - score < 0)
        {
            _score = 0;
        }
        else
        {
            _score -= score;
        }
    }
    #endregion Methods
}
