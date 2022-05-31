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
        if (Vector3.Distance(m_player.transform.position, Enemy.transform.position) >= Enemy.AttackRange)
        {
            Enemy.State = new ChaseState(Enemy);
            Debug.Log(Enemy.State.ToString());
        }

        m_attackTimer += Time.deltaTime;
        
        if (m_attackTimer >= Enemy.AttackRate)
        {
            Enemy.Attack();
            m_attackTimer = 0.0f;
        }
    }
}
