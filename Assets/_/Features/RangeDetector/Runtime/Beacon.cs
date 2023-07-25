using System;
using System.Collections;
using UnityEngine;

public class Beacon : MonoBehaviour
{
    #region Public Members

    public float m_distance;

    #endregion


    #region Unity API

    private void OnEnable()
    {
        m_detectionManager = FindObjectOfType<DetectionManager>();
        m_detectionManager.m_beacons.Add(this);
        CalculateDistance();
        m_detectionManager.SortList();
    }

    private void OnDisable()
    {
        m_detectionManager.m_beacons.Remove(this);
    }

    #endregion


    #region Main Methods
    private void CalculateDistance()
    {
        m_distance = Vector3.Distance(m_detectionManager.m_player.position, transform.position);
    }

    #endregion


    #region Private and Protected

    private DetectionManager m_detectionManager;

    #endregion
}
