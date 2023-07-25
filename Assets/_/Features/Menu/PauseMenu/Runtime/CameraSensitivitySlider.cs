using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraSensitivitySlider : MonoBehaviour
{
    #region Unity API

    private void Update()
    {
        UpdateCameraSensitivity();
        ToggleAxisInversion();
    }
    
    #endregion


    #region Main Methods

    private void ToggleAxisInversion()
    {
        _cam.m_YAxis.m_InvertInput = _YToggle.isOn;
        _cam.m_XAxis.m_InvertInput = _XToggle.isOn;
    }

    private void UpdateCameraSensitivity()
    {
        _cam.m_XAxis.m_MaxSpeed = _XSlider.value * 500f;
        _XValueText.text = (Mathf.RoundToInt(_XSlider.value * 500f)).ToString();
        
        _cam.m_YAxis.m_MaxSpeed = _YSlider.value * 5f;
        _YValueText.text = (Mathf.RoundToInt(_YSlider.value * 5f)).ToString();
    }

    #endregion

    #region Private and Protected
    
    [Header("Sensitivity Sliders")]
    [Tooltip("Put the sensitivity sliders for the X axis here")]
    [SerializeField] private Slider _XSlider;
    [Tooltip("Put the sensitivity sliders for the Y axis here")]
    [SerializeField] private Slider _YSlider;
    
    [Space]
    [Header("Inversion Toggles")]
    [Tooltip("Put the toggle for inverting the camera X axis here")]
    [SerializeField] private Toggle _XToggle;
    [Tooltip("Put the toggle for inverting the camera Y axis here")]
    [SerializeField] private Toggle _YToggle;

    [Space]
    [Header("Value Texts")]
    [Tooltip("Put the text which are going to display the sensitivity of the X axis")]
    [SerializeField] private TMP_Text _XValueText;
    [Tooltip("Put the text which are going to display the sensitivity of the X axis")]
    [SerializeField] private TMP_Text _YValueText;

    [Space]
    [Header("Cinemachine Free Look Camera")]
    [SerializeField] private CinemachineFreeLook _cam;

    #endregion
}
