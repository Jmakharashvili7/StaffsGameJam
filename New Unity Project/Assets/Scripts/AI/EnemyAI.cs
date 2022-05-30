using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] protected float m_health = 3;
    public float Health
    {
        get { return m_health; }
        set { m_health = value; }
    }

    [SerializeField] protected float m_Speed = 3;
    public float Speed
    {
        get { return m_Speed; }
        set { m_Speed = value; }
    }

    [SerializeField] protected float m_AttackRate = 1.0f;
    public float AttackRate
    {
        get { return m_AttackRate; }
    }

    [SerializeField] protected float m_AttackRange = 1.0f;
    public float AttackRange
    {
        get { return m_AttackRange; }
    }

    public EnemyState m_state;
    public EnemyState State
    {
        get { return m_state; }
        set { m_state = State; }
    }

    [SerializeField] protected Material m_deathMaterial;
    [SerializeField] protected float m_fadeTime = 1.25f;
    protected bool m_fading = false;
    protected NavMeshAgent m_agent;

    public virtual void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_agent.speed = m_Speed;
    }

    // Update is called once per frame
    virtual public void Update()
    {
        if (m_health <= 0)
        {
            if (!m_fading)
            {
                m_health = 0;
                Destroy(gameObject, m_fadeTime);

                GetComponent<MeshRenderer>().material = m_deathMaterial;
                gameObject.tag = "DeadEnemy";

                m_state = null;
                m_fading = true;
            }
            else
            {
                GetComponent<MeshRenderer>().material.SetFloat("_FadeValue", m_fadeTime);
                m_fadeTime -= Time.deltaTime;
            }
        }

        m_state.Update();
    }

    // Set destination for the nav mesh
    public void SetDestination(Vector3 destination)
    {
        m_agent.isStopped = false;
        m_agent.SetDestination(destination);
    }

    public void StopMoving()
    {
        m_agent.isStopped = true;
    }
}
