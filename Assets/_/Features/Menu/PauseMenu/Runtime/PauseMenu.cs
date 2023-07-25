using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    #region Unity API

    private void Update()
    {
        if (_isPaused)
        {
            Time.timeScale = 0f;
            _pausePanel.SetActive(true);
        }
        else if (!_isPaused)
        {
            Time.timeScale = 1f;
            _pausePanel.SetActive(false);
        }
    }

    #endregion


    #region Main Methods

    public void PauseIt(InputAction.CallbackContext context)
    {
        _isPaused = !_isPaused;
    }

    #endregion

    #region Private and Protected

    private bool _isPaused;
    
    [Tooltip("Drop the pause panel here")]
    [SerializeField] private GameObject _pausePanel;

    #endregion
}
