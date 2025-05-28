using System.Collections.Generic;
using UnityEngine;

public class KitchenCabinet : MonoBehaviour, IInteractable
{
    #region Fields
    [SerializeField] private List<Recipe> _recipes = null;
    [SerializeField] private GameObject _currentIngredientsCanvaCountainer = null;
    [SerializeField] private FoodImage _foodImagePrefab = null;
    [SerializeField] private int _maxCurrentIngredients = 6;

    private List<FoodType> _currentIngredients = null;
    #endregion Fields

    #region Methods
    private void Start()
    {
        _currentIngredients = new List<FoodType>();
    }

    private void OnDestroy()
    {
        _currentIngredients.Clear();
        _currentIngredients = null;
    }

    public void InteractWith(Rabbit rabbit)
    {
        if (rabbit.InHandFood != null)
        {
            if (_currentIngredients.Count >= _maxCurrentIngredients)
            {
                return;
            }

            _currentIngredients.Add(rabbit.InHandFood.FoodType);
            Destroy(rabbit.InHandFood.gameObject);
            rabbit.DropFood();
            
            foreach (var recipe in _recipes)
            {
                bool isRecipeValid = true;
                foreach (var ingredient in recipe.Ingredients)
                {
                    if (!_currentIngredients.Contains(ingredient))
                    {
                        isRecipeValid = false;
                        break;
                    }
                }
                if (isRecipeValid)
                {
                    foreach (var ingr in recipe.Ingredients)
                    {
                        _currentIngredients.Remove(ingr);
                    }
                    Food result = Instantiate(recipe.Result);
                    rabbit.PickUpFood(result);
                    break;
                }
            }
            UpdateIngredientsCanvas();
        }
    }

    private void UpdateIngredientsCanvas()
    {
        foreach (Transform child in _currentIngredientsCanvaCountainer.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (var ingredient in _currentIngredients)
        {
            FoodImage foodImage = Instantiate(_foodImagePrefab, _currentIngredientsCanvaCountainer.transform);
            foodImage.SetFoodType(ingredient);
        }
        _currentIngredientsCanvaCountainer.SetActive(_currentIngredients.Count > 0);
    }
    #endregion Methods
}
