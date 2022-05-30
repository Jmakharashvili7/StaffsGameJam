using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyState : EnemyState
{
    private RangedEnemyAI m_Enemy;
    public new RangedEnemyAI Enemy
    {
        get { return m_Enemy; }
        set { m_Enemy = value; }
    }
}
