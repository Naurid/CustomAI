using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class PNJSpawner : MonoBehaviour
{
    #region Public Members

    [Header("Population Prefab")]
    public GameObject _pnjPrefab;

    [Header("Spawn Data")]
    public int m_maxEntities;
    public float m_innerRadius;
    public float m_outerRadius;
    public float m_spawnRate = 1.5f;

    [Header("Player")]
    public Transform m_player;

    [Header("Auto Spawn")]
    public bool m_autoSpawn;

    public List<GameObject> m_population = new List<GameObject>();

    #endregion


    #region Unity API
    private void OnGUI()
    {
        if (GUILayout.Button("Walk in Rounds"))
        {
            ToggleWalkType(false);
        }

        if (GUILayout.Button("Walk Aimlessly"))
        {
            ToggleWalkType(true);
        }
    }

    private void ToggleWalkType(bool walkbool)
    {
        foreach (GameObject person in m_population)
        {
            person.GetComponent<PNJAutoWalk>().m_isWalkingAimlessly = walkbool;
        }
    }

    private void Start()
    {
        if (m_autoSpawn) StartCoroutine(CycleSpawn());
    }

    private void Update()
    {
        if (m_autoSpawn && m_population.Count < m_maxEntities )
        {
            StartCoroutine(CycleSpawn());
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Handles.DrawWireDisc(m_player.position, Vector3.up, m_innerRadius);

        Gizmos.color = Color.red;
        Handles.DrawWireDisc(m_player.position, Vector3.up, m_outerRadius);
    }

    #endregion

    IEnumerator CycleSpawn()
    {
        //_isCoroutineActive = true;
        SpawnPnj();
        yield return new WaitForSeconds(m_spawnRate);

        if (m_population.Count < m_maxEntities)
        {
            StartCoroutine(CycleSpawn());
        }
        //_isCoroutineActive= false;
        
    }
    private Vector3 GetPositionOnCircle( Vector3 center, float innerRadius, float outerRadius)
    {
        Vector3 position = center;

        float angle = Random.Range(0, 361);

        position.x += Mathf.Cos(Mathf.Deg2Rad * angle) * Random.Range(innerRadius, outerRadius);
        position.y += 0f;
        position.z += Mathf.Sin(Mathf.Deg2Rad * angle) * Random.Range(innerRadius, outerRadius);

        return position;
    }

    #region Main Methods
    private void SpawnPnj()
    {
        Vector3 position = GetPositionOnCircle(m_player.position, m_innerRadius, m_outerRadius);

        if (NavMesh.FindClosestEdge(position, out NavMeshHit hit, NavMesh.GetAreaFromName("sidewalk")))
        {
            GameObject pnj = Instantiate(_pnjPrefab, hit.position, Quaternion.identity, this.transform);

            m_population.Add(pnj);
        }
    }

    #endregion

    #region Private and Protected

    //bool _isCoroutineActive = true;

    #endregion
}
