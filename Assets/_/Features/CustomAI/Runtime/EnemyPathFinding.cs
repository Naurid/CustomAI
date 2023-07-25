using System;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    #region Public Members
    #endregion


    #region Unity API

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        m_canMove = true;
        FindPath();
    }

    private void Start()
    {
        _manager = EnemyManager.instance;
        _manager.m_enemies.Add(this);
    }
    
    private void OnDisable()
    {
        _manager.m_enemies.Remove(this);
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if (_rigidbody.velocity.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
        }
        
        var distanceFromPlayer = Vector3.Distance(_player.transform.position, transform.position);
        //Debug.Log(distanceFromPlayer);
        
        if (m_canMove && distanceFromPlayer > _stoppingDistance) FindPath();
        else { _rigidbody.velocity = Vector3.zero; }
    }

    private void FindPath()
    {
        var playerPosition = _player.transform.position;
        _direction = (playerPosition - transform.position).normalized;
        if (!CheckIfWallAhead())
        {
            _rigidbody.velocity = _direction * _speed;
        }
        else
        {
            _rigidbody.velocity = transform.right * _speed;
        }

    }

    private bool CheckIfWallAhead()
    {
        Ray ray = new Ray(transform.position, _player.transform.position);
        return Physics.Raycast(ray, out RaycastHit hit, _stoppingDistance) && hit.transform.CompareTag("Wall");
    }

    #endregion


    #region Private and Protected

    [SerializeField] private GameObject _player;
    
    [Space]
    [SerializeField] private float _speed;
    [SerializeField] private float _stoppingDistance;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Vector3 _direction;
    
    private Rigidbody _rigidbody;
    private EnemyManager _manager;

    public bool m_canMove;

    #endregion
}
