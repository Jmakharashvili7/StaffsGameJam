using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : RangedEnemyState
{
    float m_attackTimer;

    public RangedAttackState(RangedEnemyAI enemy)
    {
        Enemy = enemy;
        m_player = GameObject.Find("Player");
    }

    public override void Update()
    {
        float distance = Vector3.Distance(m_player.transform.position, Enemy.transform.position);

        m_attackTimer += Time.deltaTime;
        Enemy.transform.LookAt(m_player.transform.position);

        if (distance > Enemy.AttackRange)
        {
            Enemy.SetDestination(m_player.transform.position);
        }
        else if (distance <= Enemy.DangerDistance)
        {
            Enemy.SetDestination(Enemy.transform.forward * -1);
        }
        else if (distance <= Enemy.AttackRange)
        {
            if (m_attackTimer >= Enemy.AttackRate)
            {
                Enemy.StopMoving();
                Enemy.Shoot();
                m_attackTimer = 0.0f;
            }
        }
    }
}
