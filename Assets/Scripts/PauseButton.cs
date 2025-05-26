using UnityEngine;
using TMPro;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _content = null;

    private void Update()
    {
        if (GameManager.Instance.IsGamePlayed)
        {
            _content.text = "Pause";
        }
        else
        {
            _content.text = "Resume";
        }
    }

    public void PauseGame()
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
