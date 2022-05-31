using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyAI
{
    [SerializeField] EnemyType m_enemyType;
    public EnemyType EnemyType
    {
        get { return m_enemyType; }
    }

    [SerializeField] GameObject m_stomp;

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
    }

    public void Attack()
    {
        if (m_enemyType == EnemyType.NormalEnemy)
        {
            
        }
        else if (m_enemyType == EnemyType.EliteEnemy)
        {
            GameObject temp = Instantiate(m_stomp, transform.position, Quaternion.identity);
            temp.GetComponent<HitboxFill>().Setup(new Vector3(8.0f, 8.0f, 8.0f), 10.0f, transform.position + transform.forward*3.5f);
        }
        else
        {

        }
    }
}
