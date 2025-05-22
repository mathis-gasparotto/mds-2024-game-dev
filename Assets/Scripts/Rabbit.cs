using UnityEngine;
using UnityEngine.InputSystem;

public class Rabbit : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionReference _interactInputRef = null;
    [SerializeField] private InputActionReference _moveInputRef = null;
    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private float _speed = 0.0f;
    [SerializeField] private float _rotationSpeed = 0.0f;
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    private void Start()
    {
        Debug.Log("Start");
    }

    private void Update()
    {
        Vector2 rawInput = _moveInputRef.action.ReadValue<Vector2>();

        if (_interactInputRef.action.WasPerformedThisFrame())
        {
            Debug.Log("Interact");
        }

        
        // rotation
        transform.Rotate(new Vector3(0, rawInput.x * _rotationSpeed * Time.deltaTime, 0));

        // movement
        Vector3 movement = new Vector3(0, 0, rawInput.y);
        movement  = transform.TransformDirection(movement);

        _controller.SimpleMove(movement * _speed);
    }

    private void Trigger()
    {
        Debug.Log("Trigger");
    }
    #endregion Methods
}
