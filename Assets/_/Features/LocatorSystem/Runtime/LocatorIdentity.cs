using UnityEngine;

public class LocatorIdentity : MonoBehaviour
{
    #region Public Members

    public int m_priorityLevel;

    #endregion


    #region Unity API

    private void OnEnable()
    {
        _locatorSystem = FindObjectOfType<LocatorSytem>();

        _locatorSystem.m_locators.Add(this);
    }

    private void OnDisable()
    {
        _locatorSystem.m_locators.Remove(this);
    }

    #endregion


    #region Private and Protected

    LocatorSytem _locatorSystem;

    #endregion
}
