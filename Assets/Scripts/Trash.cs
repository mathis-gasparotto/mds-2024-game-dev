using UnityEngine;

public class Trash : MonoBehaviour, IInteractable
{
    public void InteractWith(Rabbit rabbit, InteractType interactType)
    {
        if (interactType != InteractType.Primary)
        {
            return;
        }

        if (rabbit.InHandFood != null)
        {
            Destroy(rabbit.InHandFood.gameObject);
            rabbit.DropFood();
        }
    }
}
