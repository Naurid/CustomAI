using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GroundChecker : MonoBehaviour
{
    #region Public Members
    #endregion


    #region Unity API

    private void OnTriggerEnter(Collider other)
    {
        _playerJump._isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _playerJump._isGrounded = false;
    }

    #endregion


    #region Private and Protected

    [SerializeField] private PlayerJump _playerJump;

    #endregion
}
