using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemyAI : EnemyAI
{
    [SerializeField] protected float m_TargetRange;
    public float TargetRange
    {
        get { return m_TargetRange; }
        set { m_TargetRange = value; }
    }

    [SerializeField] protected float m_DangerDistance;
    public float DangerDistance
    {
        get { return m_DangerDistance; }
        set { m_DangerDistance = value; }
    }

    [SerializeField] protected GameObject m_ProjectilePrefab;
    [SerializeField] protected float m_FiringForce;

    public override void Start()
    {
        base.Start();
        m_state = new RangedAttackState(this);
    }

    public override void Update()
    {
        base.Update();
    }

    public void Shoot(Vector3 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        GameObject temp = Instantiate(m_ProjectilePrefab, transform.position, Quaternion.AngleAxis(angle, Vector3.forward));
        temp.GetComponent<Rigidbody>().AddForce(dir * m_FiringForce, ForceMode.Force);
    }
}
