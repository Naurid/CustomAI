using UnityEngine;
using UnityEngine.AI;

public class PNJAutoWalk : MonoBehaviour
{
    #region Public Members

    public float _innerRadiusWalk;
    public float _outerRadiusWalk;

    public bool m_isWalkingAimlessly;
    public bool m_isWalkingForward;

    #endregion


    #region Unity API

    private void Start()
    {
        _locatorSytem = FindObjectOfType<LocatorSytem>();
        _spawner = FindObjectOfType<PNJSpawner>();
        _navMeshAgent = GetComponent<NavMeshAgent>();

        if (m_isWalkingAimlessly) SetAgentDestination();

        SetRoundStart();
      
    }
    private void Update()
    {   
        PathCompletedCheck(); 
        OutOfBoundariesCheck();
    }
 
    #endregion


    #region Main Methods

    private void SetRoundStart()
    {
        _currentDestination = _locatorSytem.GetNearest(this.transform);

        _navMeshAgent.SetDestination(_currentDestination.transform.position);
    }

    private void SetNextDestination()
    {
        if(_locatorSytem.m_isWalkingForward)
        {
            SetNextLocation();
        }
        else
        {
            SetPreviousLocation();
        }      

        Debug.Log(_navMeshAgent.destination);
    }

    private void SetNextLocation()
    {
        _currentDestination = _locatorSytem.GetNext(_currentDestination);

        _navMeshAgent.SetDestination(_currentDestination.transform.position);
    }

    private void SetPreviousLocation()
    {
        _currentDestination = _locatorSytem.GetPrevious(_currentDestination);

        _navMeshAgent.SetDestination(_currentDestination.transform.position);
    }

    private void SetAgentDestination()
    {
        _target = GetPositionOnCircle(_spawner.m_player.position, _spawner.m_innerRadius, _spawner.m_outerRadius);
        _navMeshAgent.SetDestination(_target);
    }

    private void OutOfBoundariesCheck()
    {
        if (Vector3.Distance(_spawner.m_player.position, this.transform.position) > _spawner.m_outerRadius)
        {
            _spawner.m_population.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void PathCompletedCheck()
    {
        if (_navMeshAgent.pathPending || _navMeshAgent.remainingDistance >= _navMeshAgent.stoppingDistance) return;

        if (!m_isWalkingAimlessly)
        {
            SetNextDestination();
        }
        else
        {
            SetAgentDestination();
        }
    }

    private Vector3 GetPositionOnCircle(Vector3 center, float innerRadius, float outerRadius)
    {
        Vector3 position;

        float angle = Random.Range(0, 361);

        position.x = Mathf.Cos(Mathf.Deg2Rad * angle) * Random.Range(innerRadius, outerRadius);
        position.y = 0f;
        position.z = Mathf.Sin(Mathf.Deg2Rad * angle) * Random.Range(innerRadius, outerRadius);

        return position;
    }

    #endregion


    #region Private and Protected

    private LocatorSytem _locatorSytem;
    private LocatorIdentity _currentDestination;
    private PNJSpawner _spawner;
    private NavMeshAgent _navMeshAgent;
   
    Vector3 _target;

    #endregion
}