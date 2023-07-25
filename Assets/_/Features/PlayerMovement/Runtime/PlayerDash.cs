using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerDash : MonoBehaviour
{
    #region Public Members
    
    public float DashForce
    {
        get => _dashForce;
        set => _dashForce = value;
    }

    public float DashTime
    {
        get => _dashTime;
        set => _dashTime = value;
    }
    
    #endregion


    #region Unity API

    private void Awake()
    {
        _playerMovement = GetComponent<ThirdPersonPlayerMovement>();
    }

    private void FixedUpdate()
    {
        if (_isDashing)
        {
            _dashDelta += Time.deltaTime / DashTime;
            _playerMovement.DashVelocity = Vector3.Lerp(transform.forward * DashForce, Vector3.zero, _dashDelta);
        }
    }

    #endregion


    #region Main Methods

    public void Dash(InputAction.CallbackContext context)
    {
        if (context.started && !_isDashing)
        {
            StartCoroutine(DoTheDash());
        }
    }

    private IEnumerator DoTheDash()
    {
        _dashDelta = 0;
        _isDashing = true;
        yield return new WaitForSeconds(DashTime);
        _playerMovement.DashVelocity = Vector3.zero;
        _isDashing = false;
    }
    #endregion


    #region Private and Protected
    
    private ThirdPersonPlayerMovement _playerMovement;
        
    private float _dashForce;
    private float _dashTime;
    
    private float _dashDelta;
    private float _normalVelocity;
    private bool _isDashing;

    #endregion
}