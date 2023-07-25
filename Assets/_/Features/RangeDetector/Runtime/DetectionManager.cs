using System.Collections.Generic;
using UnityEngine;

public class DetectionManager : MonoBehaviour
{
    #region Public Members

    public static DetectionManager instance;

    public List<Beacon> m_beacons = new List<Beacon>();
    public List<Beacon> m_closestBeacons = new List<Beacon>();

    public Transform m_player;
    public float m_range;

    #endregion


    #region Unity API

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        foreach (var beacon in m_beacons)
        {
            if(beacon.m_distance <= m_range && !m_closestBeacons.Contains(beacon))
            {
                m_closestBeacons.Add(beacon);
            }
            else if(beacon.m_distance > m_range)
            {
                m_closestBeacons.Remove(beacon);
            }
        }
    }

    public void SortList()
    {
        m_beacons.Sort((x, y) => x.m_distance.CompareTo(y.m_distance));
    }

    #endregion


    #region Private and Protected
    #endregion
}
