using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyAI
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        m_state = new ChaseState(this);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        Debug.Log(m_state.ToString());
    }
}
