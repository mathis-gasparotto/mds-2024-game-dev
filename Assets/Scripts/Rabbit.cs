using UnityEngine;
using UnityEngine.InputSystem;

public class Rabbit : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionReference _interactInputRef = null;
    [SerializeField] private InputActionReference _moveInputRef = null;
    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private Transform _rayOrigin = null;
    [SerializeField] private float _speed = 12f;
    [SerializeField] private float _rotationSpeed = 350f;
    [SerializeField] private float _maxDistance = 1f;
    [SerializeField] private LayerMask _layerMask = default;
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

            Ray ray = new Ray(_rayOrigin.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, _maxDistance, _layerMask))
            {
                IInteractable interactable = hit.transform.gameObject.GetComponent<IInteractable>();
                if (interactable != null)
                {
                    interactable.InteractWith(this);
                }
            }
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
