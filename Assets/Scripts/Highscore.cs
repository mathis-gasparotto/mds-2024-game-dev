using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = null;

    private void Update()
    {
        int highscore = PlayerPrefs.GetInt(GameManager.HIGH_SCORE_KEY, 0);
        _text.text = highscore.ToString();
    }
}
