using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance = null;

    public static MenuManager Instance => _instance;

    #region Fields
    [SerializeField] private MainMenu _mainMenu = null;
    [SerializeField] private EndMenu _endMenu = null;
    [SerializeField] private GameMenu _gameMenu = null;
    [SerializeField] private PauseMenu _pauseMenu = null;
    [SerializeField] private AudioSource _startButtonAudioSource = null;
    #endregion Fields

    #region Properties
    public GameMenu GameMenu => _gameMenu;
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

    public void PlayStartButtonSound()
    {
        _startButtonAudioSource.Play();
    }

    public void ShowMainMenu()
    {
        _mainMenu.Show();
        _endMenu.Hide();
        _gameMenu.Hide();
        _pauseMenu.Hide();
    }
    
    public void ShowGameMenu()
    {
        _mainMenu.Hide();
        _endMenu.Hide();
        _gameMenu.Show();
        _pauseMenu.Hide();
    }

    public void ShowEndMenu()
    {
        _mainMenu.Hide();
        _endMenu.Show();
        _gameMenu.Hide();
        _pauseMenu.Hide();
    }

    public void ShowPauseMenu()
    {
        _pauseMenu.Show();
    }

    public void HidePauseMenu()
    {
        _pauseMenu.Hide();
    }
    #endregion Methods
}
