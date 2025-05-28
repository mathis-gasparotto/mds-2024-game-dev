using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class FoodImage : MonoBehaviour
{
    [SerializeField] private Image _image = null;
    [SerializeField] private FoodSprites _foodSprites = null;
    [SerializeField] private FoodType _foodType = FoodType.Default;

    public void SetFoodType(FoodType foodType) {
        _foodType = foodType;
    }

    private void Start()
    {
        _image.sprite = _foodSprites.GetSprite(_foodType);
    }
}
