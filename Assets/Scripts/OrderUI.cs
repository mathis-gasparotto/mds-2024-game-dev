using UnityEngine;
using TMPro;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _orderTitleRef = null;
    [SerializeField] private TextMeshProUGUI _orderScoreRef = null;
    

    public void Initialize(Order order)
    {
        _orderTitleRef.text = order.Recipe.Result.name;
        _orderScoreRef.text = order.Score.ToString() + " pts";
    }
}
