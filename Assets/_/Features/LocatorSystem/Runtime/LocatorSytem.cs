using System.Collections.Generic;
using UnityEngine;

public class LocatorSytem : MonoBehaviour
{
    #region Public Members

    public static LocatorSytem Instance;

    public List<LocatorIdentity> m_locators = new List<LocatorIdentity>();

    public bool m_isWalkingForward = true;

    #endregion


    #region Unity API

    private void Awake()
    {
        if (Instance != null) return;
        Instance = this;
    }

    private void Start()
    {
        m_locators.Sort((x, y) => x.m_priorityLevel.CompareTo(y.m_priorityLevel));

    }

    private void OnGUI()
    {
        GUILayout.Space(50);

        if (GUILayout.Button("Walk Forward"))
        {
            m_isWalkingForward = true;

        }

        if (GUILayout.Button("Walk Backwards"))
        {
            m_isWalkingForward = false;
        }
    }
    #endregion


    #region Main Methods
    public LocatorIdentity GetNearest(Transform PNJTransform)
    {
        LocatorIdentity closestLocation = null;

        float minDist = Mathf.Infinity;

        foreach(var location in m_locators)
        {
            float dist = Vector3.Distance(location.transform.position, PNJTransform.position);

            if (dist < minDist)
            {
                closestLocation = location;
                minDist = dist;
            }
        }
        return closestLocation;
    }
    public LocatorIdentity GetRandom()
    {
        int _randomInt = Random.Range(0, m_locators.Count);
        return m_locators[_randomInt];
    }

    public LocatorIdentity GetNext(LocatorIdentity currentDestination)
    {
        _previousLocation = currentDestination;

        foreach (var location in m_locators)
        {
            if (location.m_priorityLevel > currentDestination.m_priorityLevel)
            {
                return location;
            }
        }
        return m_locators[0];
    }

    public LocatorIdentity GetPrevious(LocatorIdentity currentDestination)
    {
        for (int i = 0; i < m_locators.Count; i++)
        {
            if (m_locators[i].m_priorityLevel == currentDestination.m_priorityLevel)
            {
                if (i == 0)
                {
                    return m_locators[m_locators.Count - 1];
                }
                int previousIndex = i - 1;
                if (previousIndex >= 0)
                {
                    Debug.Log(previousIndex);
                    return m_locators[previousIndex];
                }
            }
        }

        Debug.Log("Previous Location");
        if (_previousLocation != null) return _previousLocation;

        return m_locators[0];
    }

    #endregion

    #region Private and Protected

    LocatorIdentity _previousLocation;

    #endregion
}