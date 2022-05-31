using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackState : RangedEnemyState
{
    float m_attackTimer;
    float m_blinkTimer;

    public RangedAttackState(RangedEnemyAI enemy)
    {
        Enemy = enemy;
        m_player = GameObject.Find("Player");
    }

    public override void Update()
    {
        float distance = Vector3.Distance(m_player.transform.position, Enemy.transform.position);

        m_attackTimer += Time.deltaTime;
        m_blinkTimer += Time.deltaTime;
        
        Enemy.transform.LookAt(m_player.transform.position);

        if (distance > Enemy.AttackRange)
        {
            Enemy.SetDestination(m_player.transform.position);
        }
        else if (distance <= Enemy.AttackRange)
        {
            if (m_attackTimer >= Enemy.AttackRate)
            {
                Enemy.StopMoving();
                Enemy.Shoot(m_player.transform.position);
                m_attackTimer = 0.0f;
            }
        }

        if (distance <= Enemy.DangerDistance)
        {
            if (Enemy.EnemyType == EnemyType.Boss && m_blinkTimer >= Enemy.BlinkRate)
            {
                float distToBlink = int.MaxValue;
                int index = 0;

                if (Enemy.m_blinkPoints != null)
                {
                    do
                    {
                        index = Random.Range(0, Enemy.m_blinkPoints.Count);
                        distToBlink = Vector3.Distance(Enemy.transform.position, Enemy.m_blinkPoints[index]);
                    }
                    while (distToBlink >= 15.0f && distToBlink <= 3.0f);
                }

                Enemy.GetComponent<Rigidbody>().MovePosition(Enemy.m_blinkPoints[index]);
                Enemy.transform.position = Enemy.m_blinkPoints[index];


                m_blinkTimer = 0.0f;
            }
            else
            {
                Enemy.SetDestination(Enemy.transform.position + Enemy.transform.forward * -1);
            }
        }
    }
}
