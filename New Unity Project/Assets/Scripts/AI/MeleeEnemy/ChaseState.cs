using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MeleeEnemyState
{
    float m_attackTimer;
    float m_cooldown;
    float m_cooldownTimer = 1.0f;

    public ChaseState(MeleeEnemy enemy)
    {
        m_Enemy = enemy;
        m_player = GameObject.Find("Player");
    }

    public override void Update()
    {
        m_attackTimer += Time.deltaTime;

        if (Vector3.Distance(m_Enemy.transform.position, m_player.transform.position) <= m_Enemy.AttackRange)
        {
            if (m_attackTimer >= m_Enemy.AttackRate)
            {
                m_Enemy.StopMoving();
                m_Enemy.Attack();
                m_attackTimer = 0.0f;
                m_cooldown = 0.0f;
            }
        }
        else
        {
            if (m_cooldownTimer >= m_cooldown)
            {
                m_Enemy.transform.LookAt(m_player.transform.position);
                m_Enemy.SetDestination(m_player.transform.position);
            }
        }
    }
}
