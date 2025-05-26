using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = null;

    private void Update()
    {
        float score = GameManager.Instance.Score;
        _text.text = score.ToString();
    }
}
