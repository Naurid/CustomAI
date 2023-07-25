using UnityEngine;

public class ValueSetter : MonoBehaviour
{
    #region Unity API

    private void Start()
    {
        _playerMovement = GetComponent<ThirdPersonPlayerMovement>();
        _jump = GetComponent<PlayerJump>();
        _dash = GetComponent<PlayerDash>();
        
        InitiateValues();
    }

    private void InitiateValues()
    {
        if (_playerMovement != null)
        {
            _playerMovement.MoveSpeed = _characterPreset.m_moveSpeed;
            _playerMovement.SprintValue = _characterPreset.m_sprintMultiplicator;
        }

        if (_dash != null)
        {
            _dash.DashForce = _characterPreset.m_dashForce;
            _dash.DashTime = _characterPreset.m_dashTime;
        }

        if (_jump != null)
        {
            _jump.JumpForce = _characterPreset.m_jumpForce;
            _jump.GravityMultiplier = _characterPreset.m_gravityMultiplier;
        }
    }

    #endregion


    #region Private and Protected

    [SerializeField] private PresetScriptableEmpty _characterPreset;

    private ThirdPersonPlayerMovement _playerMovement;
    private PlayerDash _dash;
    private PlayerJump _jump;

    #endregion
}