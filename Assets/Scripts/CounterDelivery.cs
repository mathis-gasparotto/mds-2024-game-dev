using UnityEngine;

public class CounterDelivery : MonoBehaviour, IInteractable
{
    #region Methods
    public void InteractWith(Rabbit rabbit)
    {
        // TODO: check if the food is cooked
        // TODO: display score on canvas
        if (rabbit.InHandFood != null)
        {
            GameManager.Instance.AddScore(10);
            Food food = rabbit.DropFood();
            Destroy(food.gameObject);
            return;
        }
    }
    #endregion Methods
}