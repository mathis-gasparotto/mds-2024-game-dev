using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class FoodSprite
{
    public FoodType FoodType = FoodType.Default;
    public Sprite Sprite = null;
}

[CreateAssetMenu(fileName = "NewFoodSprites", menuName = "Rabbit/FoodSprites")]
public class FoodSprites : ScriptableObject
{
    [SerializeField] private List<FoodSprite> _foodSprites = null;

    public Sprite GetSprite(FoodType foodType)
    {
        return _foodSprites.Find(foodSprite => foodSprite.FoodType == foodType).Sprite;
    }
}
