using UnityEngine;

public class Counter : MonoBehaviour, IInteractable
{
    public void InteractWith(Rabbit rabbit)
    {
        Debug.Log("Interact with counter");
    }
}
