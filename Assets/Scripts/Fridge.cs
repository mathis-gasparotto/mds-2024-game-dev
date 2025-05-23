using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    #region Fields
    [SerializeField] private Food _foodPrefab = null;
    #endregion Fields

    #region Methods
    public void InteractWith(Rabbit rabbit)
    {
        if (!rabbit.IsHoldingFood && _foodPrefab != null)
        {
            Food food = Instantiate(_foodPrefab);
            rabbit.PickUpFood(food);
        }
    }
    #endregion Methods
}
