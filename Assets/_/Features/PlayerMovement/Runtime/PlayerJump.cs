using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    #region Public Members

    [HideInInspector]
    public bool _isGrounded;

    public float JumpForce
    {
        get => _jumpForce;
        set => _jumpForce = value;
    }

    public float GravityMultiplier
    {
        get => _gravityMultiplier;
        set => _gravityMultiplier = value;
    }

    #endregion


    #region Unity API

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (_isFalling)
        {
            _rigidbody.AddForce(-Vector3.up * GravityMultiplier, ForceMode.Force);
        }

        if (_isGrounded)
        {
            _isFalling = false;
        }
    }

    #endregion


    #region Main Methods

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else if (context.canceled)
        {
            _isFalling = true;
        }
    }

  
    #endregion

    #region Private and Protected

    private Rigidbody _rigidbody;

    private bool _isFalling;

    [Space]
    [Tooltip("This is the force at which the player will jump")]
    private float _jumpForce;
    
    [Space]
    [Tooltip("This multiplies gravity when the body of the player is descending")]
    private float _gravityMultiplier;
    
    #endregion
}
