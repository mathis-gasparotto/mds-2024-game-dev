using UnityEngine;
using UnityEngine.InputSystem;

public class Rabbit : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionReference _interactInputRef = null;
    [SerializeField] private InputActionReference _moveInputRef = null;
    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private Transform _rayOrigin = null;
    [SerializeField] private float _speed = 18f;
    [SerializeField] private float _rotationSpeed = 1000f;
    [SerializeField] private float _maxDistance = 2f;
    [SerializeField] private LayerMask _layerMask = default;
    [SerializeField] private Vector3 _foodLocalPosition = new Vector3(0f, 1.694f, 1.04f);
    [SerializeField] private Animator _animator = null;

    private Food _inHandFood = null;
    #endregion Fields

    #region Properties
    public bool IsHoldingFood => _inHandFood != null;
    public Food InHandFood => _inHandFood;
    #endregion Properties

    #region Methods
    private void Update()
    {
        Vector2 rawInput = _moveInputRef.action.ReadValue<Vector2>();

        if (_interactInputRef.action.WasPerformedThisFrame())
        {
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

        // movement + rotation
        Vector3 direction = new Vector3(-rawInput.y, 0f, rawInput.x);
        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        // animation
        _animator.SetBool("IsWalking", direction.magnitude > 0.01f);

        _controller.SimpleMove(direction * _speed);
    }

    public void PickUpFood(Food food)
    {
        _inHandFood = food;

        _inHandFood.transform.SetParent(transform);
        _inHandFood.transform.localPosition = _foodLocalPosition;
        _inHandFood.transform.localRotation = Quaternion.Euler(0f, -180f, 0f);

        // animation
        _animator.SetBool("IsHolding", IsHoldingFood);
    }

    public Food DropFood()
    {
        Food food = _inHandFood;
        _inHandFood = null;

        // animation
        _animator.SetBool("IsHolding", IsHoldingFood);

        return food;
    }
    #endregion Methods
}
