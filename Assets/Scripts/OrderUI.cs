using UnityEngine;
using TMPro;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _orderTitleRef = null;
    [SerializeField] private TextMeshProUGUI _orderScoreRef = null;
    [SerializeField] private IngredientUI _recipeIngredientUiPrefab = null;
    [SerializeField] private Transform _recipeIngredientUiParent = null;
    

    public void Initialize(Order order)
    {
        _orderTitleRef.text = order.Recipe.Result.name;
        _orderScoreRef.text = order.Score.ToString() + " pts";

        foreach (var ingredient in order.Recipe.Ingredients)
        {
            IngredientUI ingredientUi = Instantiate(_recipeIngredientUiPrefab, _recipeIngredientUiParent);
            ingredientUi.Initialize(ingredient);
        }
    }
}
