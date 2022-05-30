using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MeleeEnemyState
{
    public ChaseState(MeleeEnemy enemy)
    {
        m_Enemy = enemy;
        m_player = GameObject.Find("Player");
    }

    public override void Update()
    {
        if (Vector3.Distance(m_Enemy.transform.position, m_player.transform.position) <= m_Enemy.AttackRange)
        {
            m_Enemy.m_state = new MeleeAttackState(m_Enemy);
        }

        m_Enemy.SetDestination(m_player.transform.position);
    }
}
