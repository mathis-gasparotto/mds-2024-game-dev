using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    public void InteractWith(Rabbit rabbit, InteractType interactType)
    {
        if (interactType != InteractType.Primary)
        {
            return;
        }
        
        Debug.Log("Interact with sink");
    }
}
