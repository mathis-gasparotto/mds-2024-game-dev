using UnityEngine;

[CreateAssetMenu(fileName = "NewOrder", menuName = "Rabbit/Order")]
public class Order : ScriptableObject
{
    [SerializeField] private Recipe _recipe = null;
    [SerializeField] private int _score = 0;
    [SerializeField] private float _orderDuration = 50f;

    public Recipe Recipe => _recipe;
    public int Score => _score;
    public float OrderDuration => _orderDuration;
}
