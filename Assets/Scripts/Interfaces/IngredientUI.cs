using UnityEngine;
using TMPro;

public class IngredientUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ingredientNameRef = null;

    public void Initialize(FoodType ingredient)
    {
        _ingredientNameRef.text = ingredient.ToString();
    }
}
