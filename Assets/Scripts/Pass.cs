using UnityEngine;

public class CounterDelivery : MonoBehaviour, IInteractable
{
    #region Methods
    public void InteractWith(Rabbit rabbit, InteractType interactType)
    {
        if (interactType != InteractType.Primary)
        {
            return;
        }

        if (rabbit.InHandFood != null)
        {
            Food food = rabbit.DropFood();
            OrderManager.Instance.TryValidateOrder(food);
            Destroy(food.gameObject);
            return;
        }
    }
    #endregion Methods
}