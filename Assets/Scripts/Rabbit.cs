using UnityEngine;
using UnityEngine.InputSystem;

public class Rabbit : MonoBehaviour
{
    #region Fields
    [SerializeField] private InputActionReference _interactInputRef = null;
    [SerializeField] private InputActionReference _moveInputRef = null;
    [SerializeField] private CharacterController _controller = null;
    [SerializeField] private Transform _rayOrigin = null;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rotationSpeed = 1000f;
    [SerializeField] private float _maxDistance = 2f;
    [SerializeField] private LayerMask _layerMask = default;
    [SerializeField] private Vector3 _foodLocalPosition = new Vector3(0f, 1.694f, 1.04f);

    private Food _inHandFood = null;
    #endregion Fields

    #region Properties
    public bool IsHoldingFood => _inHandFood != null;
    public Food InHandFood => _inHandFood;
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

        _controller.SimpleMove(direction * _speed);
    }

    public void PickUpFood(Food food)
    {
        _inHandFood = food;

        _inHandFood.transform.SetParent(transform);
        _inHandFood.transform.localPosition = _foodLocalPosition;
        _inHandFood.transform.localRotation = Quaternion.Euler(0f, -180f, 0f);

        Debug.Log("Pick  food: " + _inHandFood);
    }

    public Food DropFood()
    {
        Food food = _inHandFood;
        _inHandFood = null;

        Debug.Log("Drop food: " + food);

        return food;
    }
    #endregion Methods
}
