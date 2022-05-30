using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : RangedEnemyState
{
    public RangedAttackState(RangedEnemyAI enemy)
    {
        Enemy = enemy;
        m_player = GameObject.Find("Player");
    }

    public override void Update()
    {
        float distance = Vector3.Distance(m_player.transform.position, Enemy.transform.position);

        if (distance > Enemy.AttackRange)
        {
            Enemy.SetDestination(m_player.transform.position);
        }
        else if (distance <= Enemy.AttackRange)
        {
            Vector3 dir = Enemy.transform.position - m_player.transform.position;
            dir.Normalize();
            Enemy.Shoot(dir);
        }

        if (distance <= Enemy.DangerDistance)
        {
            Vector3 runAway = Enemy.transform.position - m_player.transform.position.normalized;
            Enemy.SetDestination(runAway);
        }
    }
}
