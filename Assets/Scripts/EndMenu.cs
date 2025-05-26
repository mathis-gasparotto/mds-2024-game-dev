using UnityEngine;
using TMPro;

public class EndMenu : IMenu
{
    [SerializeField] private TextMeshProUGUI _scoreText = null;

    private void OnEnable()
    {
        int score = GameManager.Instance.Score;
        _scoreText.text = score.ToString();
    }
    
}
