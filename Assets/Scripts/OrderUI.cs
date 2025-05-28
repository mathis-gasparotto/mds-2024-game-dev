using UnityEngine;
using TMPro;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _orderTitleRef = null;
    [SerializeField] private TextMeshProUGUI _orderScoreRef = null;
    [SerializeField] private FoodImage _recipefoodImagePrefab = null;
    [SerializeField] private Transform _recipeIngredientUiParent = null;
    

    public void Initialize(Order order)
    {
        _orderTitleRef.text = order.Recipe.Result.name;
        _orderScoreRef.text = order.Score.ToString() + " pts";

        foreach (var ingredient in order.Recipe.Ingredients)
        {
            FoodImage foodImage = Instantiate(_recipefoodImagePrefab, _recipeIngredientUiParent);
            foodImage.SetFoodType(ingredient);
        }
    }
}
