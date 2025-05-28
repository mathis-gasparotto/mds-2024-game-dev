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

public struct ObjectOrder
{
    public Order Order;
    public GameObject Object;
}

public class OrderManager : MonoBehaviour
{
    private static OrderManager _instance = null;

    public static OrderManager Instance => _instance;

    #region Fields
    [SerializeField] private List<WeightedOrder> _potentialsOrders = null;
    [SerializeField] private float _orderInterval = 10f;
    [SerializeField] private int _maxOrders = 5;

    private List<ObjectOrder> _currentOrders = null;
    private Dictionary<ObjectOrder, float> _orderTimers = null;
    private List<ObjectOrder> _ordersToRemove = null;
    private float _timer = 0f;
    #endregion Fields

    #region Properties
    public List<ObjectOrder> CurrentOrders => _currentOrders;
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

    private void Start()
    {
        _currentOrders = new List<ObjectOrder>();
        _orderTimers = new Dictionary<ObjectOrder, float>();
        _ordersToRemove = new List<ObjectOrder>();
    }

    private void OnDestroy()
    {
        _currentOrders.Clear();
        _orderTimers.Clear();
        _ordersToRemove.Clear();
    }

    public void TryValidateOrder(Food food)
    {
        if (_currentOrders.Count == 0)
        {
            return;
        }

        ObjectOrder order = _currentOrders.Find(o => o.Order.Recipe.Result.Equals(food));
        if (order.Order != null)
        {
            _currentOrders.Remove(order);
            Destroy(order.Object);
            GameManager.Instance.AddScore(order.Order.Score);
            AudioManager.Instance.PlayFoodDeliveryAudio();
        }
    }

    public void AddNewOrder()
    {
        if (_potentialsOrders.Count == 0 || _currentOrders.Count >= _maxOrders)
        {
            return;
        }

        WeightedOrder order = Helper.GetRandomFromWeightedList(_potentialsOrders, o => o.Weight);
        ObjectOrder objectOrder = new ObjectOrder()
        {
            Order = order.Order,
            Object = MenuManager.Instance.GameMenu.ShowNewOrder(order.Order),
        };
        _currentOrders.Add(objectOrder);
        _orderTimers.Add(objectOrder, objectOrder.Order.OrderDuration);
    }

    public void CleanCurrentOrders()
    {
        MenuManager.Instance.GameMenu.DestroyAllOrders();
        _currentOrders.Clear();
    }

    public void RemoveSingleOrder(ObjectOrder order)
    {
        _currentOrders.Remove(order);
        Destroy(order.Object);
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
            foreach (ObjectOrder order in _currentOrders)
            {
                _orderTimers[order] -= Time.deltaTime;
                if (_orderTimers[order] <= 0f)
                {
                    _ordersToRemove.Add(order);
                }
            }
            foreach (ObjectOrder order in _ordersToRemove)
            {
                RemoveSingleOrder(order);
            }
            _ordersToRemove.Clear();
        }
    }
    #endregion Methods
}
