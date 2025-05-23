using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text = null;

    private void Update()
    {
        float timer = GameManager.Instance.Timer;
        _text.text = timer.ToString("F1");
    }
}
