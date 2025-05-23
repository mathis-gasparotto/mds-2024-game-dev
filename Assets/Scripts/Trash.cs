using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    public void InteractWith(Rabbit rabbit)
    {
        if (rabbit.InHandFood != null)
        {
            Destroy(rabbit.InHandFood.gameObject);
            rabbit.DropFood();
        }
    }
}
