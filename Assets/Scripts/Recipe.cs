using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Rabbit/Recipe")]
public class Recipe : ScriptableObject
{
    #region Fields
    [SerializeField] private List<FoodType> _ingredients = null;
    [SerializeField] private Food _result = null;
    [SerializeField] private int _points = 0;
    #endregion Fields
    
    #region Properties
    public List<FoodType> Ingredients => _ingredients;
    public Food Result => _result;
    public int Points => _points;
    #endregion Properties
}
