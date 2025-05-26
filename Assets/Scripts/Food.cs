using UnityEngine;
using System;

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

public class Food : MonoBehaviour, IEquatable<Food>
{
    #region Fields
    [SerializeField] private FoodType _foodType = FoodType.Default;
    #endregion

    #region Properties
    public FoodType FoodType => _foodType;
    #endregion

    #region Methods
    public bool Equals(Food other)
    {
        return _foodType == other.FoodType;
    }
    
    #endregion
}
