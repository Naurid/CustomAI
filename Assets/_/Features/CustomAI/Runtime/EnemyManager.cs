using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Public Members

    public static EnemyManager instance;
    public List<EnemyPathFinding> m_enemies;
    #endregion


    #region Unity API

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Update()
    {
        // foreach (var enemy in m_enemies)
        // {
        //     foreach (var otherEnemy in m_enemies)
        //     {
        //         //if (otherEnemy.transform.position == enemy.transform.position) return;
        //
        //         float distance = (enemy.transform.position - otherEnemy.transform.position).magnitude;
        //         Debug.Log(distance);
        //
        //         if (distance > 0 && distance < _enemyMinDistance)
        //         {
        //             enemy.m_canMove = false;
        //         }
        //         else
        //         {
        //             enemy.m_canMove = true;
        //         }
        //         //enemy.m_canMove = !(distance < _enemyMinDistance);
        //     }
        // }
    }

    #endregion


    #region Private and Protected

    [SerializeField] private float _enemyMinDistance;

    #endregion
}
