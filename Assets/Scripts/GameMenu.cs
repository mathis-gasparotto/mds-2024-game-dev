using UnityEngine;

public class GameMenu : IMenu
{
    [SerializeField] private OrderUI _orderUiPrefab = null;
    [SerializeField] private Transform _orderUiParent = null;

    public GameObject ShowNewOrder(Order order)
    {
        OrderUI orderUi = Instantiate(_orderUiPrefab, _orderUiParent);
        orderUi.Initialize(order);
        return orderUi.gameObject;
    }
}
