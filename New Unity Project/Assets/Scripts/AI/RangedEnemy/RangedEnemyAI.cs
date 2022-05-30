using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : EnemyAI
{
    [SerializeField] protected float m_TargetRange = 10.0f;
    public float TargetRange
    {
        get { return m_TargetRange; }
        set { m_TargetRange = value; }
    }

    [SerializeField] protected float m_DangerDistance = 5.0f;
    public float DangerDistance
    {
        get { return m_DangerDistance; }
        set { m_DangerDistance = value; }
    }

    [SerializeField] protected GameObject m_ProjectilePrefab;
    [SerializeField] protected float m_FiringForce = 3.0f;

    public override void Start()
    {
        base.Start();
        m_state = new RangedAttackState(this);
    }

    public override void Update()
    {
        base.Update();
    }

    public void Shoot()
    {
        Rigidbody temp = Instantiate(m_ProjectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

        temp.AddForce(transform.up * 8, ForceMode.Impulse);
        temp.AddForce(transform.forward * 32f, ForceMode.Impulse);
    }
}
