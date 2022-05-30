using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyState : EnemyState
{
    protected MeleeEnemy m_Enemy;
    public new MeleeEnemy Enemy
    {
        get { return m_Enemy; }
        set { m_Enemy = value; }
    }
}
