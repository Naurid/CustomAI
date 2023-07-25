using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : MonoBehaviour
{
    #region Public Members
    #endregion


    #region Unity API

    private void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, _cameraAnchor.position, _smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, _cameraAnchor.rotation, _smoothing);
    }

    #endregion


    #region Main Methods

    #endregion


    #region Private and Protected

    [SerializeField] private Transform _cameraAnchor;
    [SerializeField] [Range(0,1f)]private float _smoothing;

    #endregion
}
