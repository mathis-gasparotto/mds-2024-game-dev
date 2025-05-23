using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour, IInteractable
{
    #region Fields
    [SerializeField] private Recipe _recipe = null;

    private List<FoodType> _remainingIngredients = null;
    #endregion Fields

    #region Methods
    private void Start()
    {
        _remainingIngredients = new List<FoodType>(_recipe.Ingredients);
    }

    private void OnDestroy()
    {
        _remainingIngredients.Clear();
        _remainingIngredients = null;
    }

    public void InteractWith(Rabbit rabbit)
    {
        if (rabbit.InHandFood != null)
        {
            if (_remainingIngredients.Contains(rabbit.InHandFood.FoodType))
            {
                _remainingIngredients.Remove(rabbit.InHandFood.FoodType);
                Destroy(rabbit.InHandFood.gameObject);
                rabbit.DropFood();
                
                if (_remainingIngredients.Count == 0)
                {
                    Debug.Log("Recipe complete");
                    Food result = Instantiate(_recipe.Result);
                    rabbit.PickUpFood(result);
                    _remainingIngredients = new List<FoodType>(_recipe.Ingredients);
                }
            }
        }
    }
    #endregion Methods
}
