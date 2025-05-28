using UnityEngine;
using TMPro;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private FoodImage _orderImageRef = null;
    [SerializeField] private TextMeshProUGUI _orderScoreRef = null;
    [SerializeField] private FoodImage _recipefoodImagePrefab = null;
    [SerializeField] private Transform _recipeIngredientUiParent = null;
    

    public void Initialize(Order order)
    {
        _orderImageRef.SetFoodType(order.Recipe.Result.FoodType);
        _orderScoreRef.text = order.Score.ToString() + " pts";

        foreach (FoodType ingredient in order.Recipe.Ingredients)
        {
            FoodImage foodImage = Instantiate(_recipefoodImagePrefab, _recipeIngredientUiParent);
            foodImage.SetFoodType(ingredient);
        }
    }
}
