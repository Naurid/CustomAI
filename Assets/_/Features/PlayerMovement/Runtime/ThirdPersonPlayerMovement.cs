using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonPlayerMovement : MonoBehaviour
{
    #region Public Members
    
    public Vector3 DashVelocity
    {
        get => _dashVelocity;
        set => _dashVelocity = value;
    }

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }

    public float SprintValue
    {
        get => _sprintValue;
        set => _sprintValue = value;
    }

    #endregion
    
    #region Unity API

    private void Start()
    {
        if (Camera.main != null) _camTransform = Camera.main.transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_movement != Vector2.zero)
        {
            RotatePlayer(Vector3.Scale(_rigidbody.velocity, new Vector3(1, 0, 1)));
        }
    }

    private void FixedUpdate()
    {
        Vector3 camForward = Vector3.Scale(_camTransform.forward, new Vector3(1, 0, 1));
        Vector3 movementDirection = camForward * _movement.y + _camTransform.right * _movement.x;

        if (movementDirection.magnitude > 1f) movementDirection.Normalize();

        Vector3 _moveVelocity = movementDirection * (MoveSpeed * (_isSprinting ? SprintValue : 1f))  + new Vector3(0, _rigidbody.velocity.y, 0);
        
        _rigidbody.velocity = _moveVelocity + DashVelocity;
    }

    #endregion


    #region Main Methods

    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>();
    }

    private void RotatePlayer(Vector3 lookDirection)
    {
        if (lookDirection != Vector3.zero)
        {
            transform.forward = lookDirection;
        }
    }
    
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            _isSprinting = true;
        }
        else if (context.canceled)
        {
            _isSprinting = false;
        }
    }

    #endregion

    #region Private and Protected

    private float _moveSpeed;
    private float _sprintValue;

    private Transform _camTransform;
    private Rigidbody _rigidbody;
    private Vector2 _movement;

    private Vector3 _dashVelocity;
    private bool _isSprinting;

    #endregion
}
