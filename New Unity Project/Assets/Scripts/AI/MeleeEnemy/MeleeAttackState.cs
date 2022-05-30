using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackState : MeleeEnemyState
{
    float m_attackTimer;

    public MeleeAttackState(MeleeEnemy enemy)
    {
        m_Enemy = enemy;
        m_attackTimer = m_Enemy.AttackRate;
        m_player = GameObject.Find("Player");
    }

    public override void Update()
    {
        // check if the enemy left range
        if (Vector3.Distance(m_player.transform.position, m_Enemy.transform.position) >= m_Enemy.AttackRange)
        {
            m_Enemy.State = new ChaseState(m_Enemy);
        }

        m_attackTimer += Time.deltaTime;

        if (m_attackTimer >= m_Enemy.AttackRate)
        {
            m_attackTimer = 0.0f;
        }
    }
}
