using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;

    public static GameManager Instance => _instance;

    #region Fields
    [SerializeField] private float _timerStartValue = 100f;

    private int _score = 0;
    private float _timer = 0f;
    private bool _isGamePlayed = false;
    #endregion Fields

    #region Properties
    public int Score => _score;
    public float Timer => _timer;
    public bool IsGamePlayed => _isGamePlayed;
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
        _isGamePlayed = false;
        MenuManager.Instance.ShowMainMenu();
    }

    private void Update()
    {
        if (!_isGamePlayed)
        {
            return;
        }

        _timer -= Time.deltaTime;

        if (_timer <= 0f)
        {
            _timer = 0f;
            EndGame();
        }
    }

    public void StartGame()
    {
        MenuManager.Instance.ShowGameMenu();
    }

    public void PlayGame()
    {
        if (_isGamePlayed)
        {
            return;
        }

        SceneManager.LoadScene(1);
        
        _isGamePlayed = true;
        _score = 0;
        _timer = _timerStartValue;

        MenuManager.Instance.ShowGameMenu();
    }

    public void PauseGame()
    {
        _isGamePlayed = false;
    }

    public void ResumeGame()
    {
        _isGamePlayed = true;
    }

    public void EndGame()
    {
        _isGamePlayed = false;
        MenuManager.Instance.ShowEndMenu();
    }

    public void RestartGame()
    {
        _isGamePlayed = false;
        SceneManager.LoadScene(0);
        MenuManager.Instance.ShowMainMenu();
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
