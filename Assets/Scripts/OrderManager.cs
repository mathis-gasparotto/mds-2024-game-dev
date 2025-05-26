using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

[Serializable]
public struct WeightedOrder
{
    public Order Order;
    public int Weight;
}

public class OrderManager : MonoBehaviour
{
    private static OrderManager _instance = null;

    public static OrderManager Instance => _instance;

    #region Fields
    [SerializeField] private List<WeightedOrder> _potentialsOrders = null;
    [SerializeField] private float _orderInterval = 15f;
    [SerializeField] private int _maxOrders = 4;

    private List<Order> _currentOrders = null;
    private float _timer = 0f;
    #endregion Fields

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

    private void Start()
    {
        _currentOrders = new List<Order>();
    }

    public void TryValidateOrder(Food food)
    {
        if (_currentOrders.Count == 0)
        {
            return;
        }

        Order order = _currentOrders.Find(o => o.Recipe.Result.Equals(food));
        if (order != null)
        {
            _currentOrders.Remove(order);
            GameManager.Instance.AddScore(order.Score);
        }
    }

    public void AddNewOrder()
    {
        if (_potentialsOrders.Count == 0 || _currentOrders.Count >= _maxOrders)
        {
            return;
        }

        WeightedOrder order = Helper.GetRandomFromWeightedList(_potentialsOrders, o => o.Weight);
        Debug.Log("New order: " + order.Order.Recipe.Result.name);
        _currentOrders.Add(order.Order);
        // Debug.Log("New order: " + _currentOrders[0].Recipe.Result.name + " Weight: " + order.Weight);
    }

    private void Update()
    {
        if (GameManager.Instance.IsGamePlayed)
        {
            _timer += Time.deltaTime;
            if (_timer >= _orderInterval)
            {
                _timer = 0f;
                AddNewOrder();
            }
        }
    }
    #endregion Methods
}
