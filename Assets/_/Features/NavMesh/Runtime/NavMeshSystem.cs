using UnityEngine;
using UnityEngine.AI;

public class NavMeshSystem : MonoBehaviour
{

    #region Public Members

    

    #endregion


    #region Unity API

    private void Start() => _navMeshAgent = GetComponent<NavMeshAgent>();

    private void Update()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            _navMeshAgent.SetDestination(hit.point);
        }
    }

    #endregion


    #region Private and Protected

    private NavMeshAgent _navMeshAgent;

    #endregion
}
