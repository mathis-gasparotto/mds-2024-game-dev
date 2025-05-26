using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private static MenuManager _instance = null;

    public static MenuManager Instance => _instance;

    [SerializeField] private MainMenu _mainMenu = null;
    [SerializeField] private EndMenu _endMenu = null;
    [SerializeField] private GameMenu _gameMenu = null;

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

    public void ShowMainMenu()
    {
        _mainMenu.Show();
        _endMenu.Hide();
        _gameMenu.Hide();
    }
    
    public void ShowGameMenu()
    {
        _mainMenu.Hide();
        _endMenu.Hide();
        _gameMenu.Show();
    }

    public void ShowEndMenu()
    {
        _mainMenu.Hide();
        _endMenu.Show();
        _gameMenu.Hide();
    }
    #endregion Methods
}
