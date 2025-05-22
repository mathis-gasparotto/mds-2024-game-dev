using UnityEngine;

public class Sink : MonoBehaviour, IInteractable
{
    public void InteractWith(Rabbit rabbit)
    {
        Debug.Log("Interact with sink");
    }
}
