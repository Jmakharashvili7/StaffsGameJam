using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState : MeleeEnemyState
{

    public TestState(MeleeEnemy enemy)
    {
        m_Enemy = enemy;
    }

    public override void Update()
    {
        m_Enemy.State = new ChaseState(m_Enemy);
        Debug.Log(m_Enemy.name);
    }
}
