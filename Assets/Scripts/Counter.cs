using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour, IInteractable
{
    #region Fields
    private Food _food = null;
    #endregion Fields

    #region Methods
    public void InteractWith(Rabbit rabbit)
    {
        if (rabbit.IsHoldingFood && _food != null) {
            return;
        }

        if (_food != null && !rabbit.IsHoldingFood)
        {
            // pick up food
            rabbit.PickUpFood(_food);
            _food = null;
            return;
        }
        
        if (rabbit.IsHoldingFood && _food == null)
        {
            // drop food
            Food food = rabbit.DropFood();

            // set food position
            SetFoodPosition(food);
            _food = food;
            return;
        }
    }

    private void SetFoodPosition(Food food)
    {
        food.transform.SetParent(transform);
        food.transform.localPosition = new Vector3(0f, 0f, 0f);
        food.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }
    #endregion Methods
}
