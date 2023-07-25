using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonPlayerMovement : MonoBehaviour
{
    #region Public Members
    #endregion


    #region Unity API

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        
        if (Camera.main != null) _camTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        
        Vector3 camForward = Vector3.Scale(_camTransform.forward, new Vector3(1, 0, 1));
        Vector3 movingForceDir = camForward * _movement.y + _camTransform.right * _movement.x;

        if (movingForceDir.magnitude > 1f) movingForceDir.Normalize();

        if (_rigidbody.velocity.magnitude < _maxSpeed )
        {
            _rigidbody.AddForce(movingForceDir * _moveSpeed, ForceMode.Force);
        }
        
        if (_movement != Vector2.zero)
        {
            RotatePlayer();
        }
    }


    #endregion


    #region Main Methods

    private void RotatePlayer()
    {
        transform.rotation = Quaternion.LookRotation(_camTransform.forward);
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        _movement = ctx.ReadValue<Vector2>();
    }

    #endregion
    #region Private and Protected

    private Vector2 _movement;
    private Rigidbody _rigidbody;
    private Transform _camTransform;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _maxSpeed;

    #endregion
}
