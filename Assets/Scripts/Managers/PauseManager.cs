using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionReference _pauseInputRef = null;

    private static PauseManager _instance = null;
    #endregion Fields

    #region Properties
    public static PauseManager Instance => _instance;
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

    private void Update()
    {
        if (_pauseInputRef.action.WasPerformedThisFrame() && GameManager.Instance.IsGameStarted)
        {
            if (GameManager.Instance.IsGamePlayed)
            {
                GameManager.Instance.PauseGame();
            }
            else
            {
                GameManager.Instance.ResumeGame();
            }
        }
    }
    #endregion Methods
}
