using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public const string HIGH_SCORE_KEY = "highscore";

    private static GameManager _instance = null;

    public static GameManager Instance => _instance;

    #region Fields
    [SerializeField] private float _timerStartValue = 100f;
    [SerializeField] private float _timerWarningValue = 15f;

    private int _score = 0;
    private int _highscore = 0;
    private float _timer = 0f;
    private bool _isGameStarted = false;
    private bool _isGamePlayed = false;
    #endregion Fields

    #region Properties
    public int Score => _score;
    public float Timer => _timer;
    public bool IsGamePlayed => _isGamePlayed;
    public bool IsGameStarted => _isGameStarted;
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
        _highscore = PlayerPrefs.GetInt(HIGH_SCORE_KEY, 0);
        _score = 0;
        _timer = _timerStartValue;
        _isGamePlayed = false;
        _isGameStarted = false;
        MenuManager.Instance.ShowMainMenu();
        AudioManager.Instance.PlayGameSoundAudio();
    }

    private void Update()
    {
        if (!_isGamePlayed)
        {
            return;
        }

        _timer -= Time.deltaTime;

        if (_timer <= _timerWarningValue && AudioManager.Instance.IsClockTickAudioPlaying == false)
        {
            AudioManager.Instance.PlayClockTickAudio();
        }
        if (_timer <= 0f)
        {
            _timer = 0f;
            AudioManager.Instance.StopClockTickAudio();

            EndGame();
        }
    }

    public void PlayGame()
    {
        if (_isGamePlayed)
        {
            return;
        }

        MenuManager.Instance.PlayStartButtonSound();

        AsyncOperation op = SceneManager.LoadSceneAsync(1);
        op.completed += OnLoadOperationComplete;
    }

    private void OnLoadOperationComplete(AsyncOperation op)
    {
        op.completed -= OnLoadOperationComplete;

        _isGamePlayed = true;
        _isGameStarted = true;
        _score = 0;
        _timer = _timerStartValue;

        MenuManager.Instance.ShowGameMenu();
        OrderManager.Instance.AddNewOrder();
    }

    public void PauseGame()
    {
        _isGamePlayed = false;
        MenuManager.Instance.ShowPauseMenu();

        AudioManager.Instance.StopClockTickAudio();
    }

    public void ResumeGame()
    {
        _isGamePlayed = true;
        MenuManager.Instance.HidePauseMenu();

        AudioManager.Instance.PlayGameSoundAudio();
    }

    public void EndGame()
    {
        AudioManager.Instance.PlayEndGameAudio();
        AudioManager.Instance.StopGameSoundAudio();
        _isGamePlayed = false;
        _isGameStarted = false;

        if (_score > _highscore)
        {
            _highscore = _score;
            PlayerPrefs.SetInt(HIGH_SCORE_KEY, _highscore);
        }

        OrderManager.Instance.CleanCurrentOrders();

        MenuManager.Instance.ShowEndMenu();
    }

    public void RestartGame()
    {
        _isGamePlayed = false;
        _isGameStarted = false;
        SceneManager.LoadScene(0);
        MenuManager.Instance.ShowMainMenu();
        AudioManager.Instance.PlayGameSoundAudio();
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
