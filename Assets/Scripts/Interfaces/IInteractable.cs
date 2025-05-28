public enum InteractType
{
    Primary,
    Secondary
}

public interface IInteractable
{
    void InteractWith(Rabbit rabbit, InteractType interactType);
}