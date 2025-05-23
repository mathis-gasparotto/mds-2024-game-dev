using UnityEngine;

public enum FoodType
{
    Default,
    Avocado,
    Octopus,
    Cucumber,
    Tuna,
    CrabSticks,
    Salmon,
    EbiNigiri,
    Rice,
    OctopusNigiri,
}

public class Food : MonoBehaviour
{
    #region Fields
    [SerializeField] private FoodType _foodType = FoodType.Default;
    #endregion

    #region Properties
    public FoodType FoodType => _foodType;
    #endregion
    
}
