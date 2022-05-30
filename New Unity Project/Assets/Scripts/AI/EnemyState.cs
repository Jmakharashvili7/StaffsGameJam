using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    private EnemyAI m_Enemy;
    public EnemyAI Enemy
    {
        get { return m_Enemy; }
        set { m_Enemy = value; }
    }

    protected GameObject m_player;

    public virtual void Update() { }
}
