using UnityEngine;

[CreateAssetMenu(fileName = "NewOrder", menuName = "Rabbit/Order")]
public class Order : ScriptableObject
{
    [SerializeField] private Recipe _recipe = null;
    [SerializeField] private int _score = 0;
    // [SerializeField] private int _weight = 1;

    public Recipe Recipe => _recipe;
    public int Score => _score;
    // public int ChanceToHave => _weight;
}
