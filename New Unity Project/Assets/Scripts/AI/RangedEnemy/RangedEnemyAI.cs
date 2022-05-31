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

    [SerializeField] protected float m_blinkRate = 3.0f;
    public float BlinkRate
    {
        get { return m_blinkRate; }
    }
    
    [SerializeField] protected GameObject m_ProjectilePrefab;
    [SerializeField] protected float m_FiringForce = 3.0f;

    [SerializeField] protected EnemyType m_enemyType;
    public EnemyType EnemyType
    {
        get { return m_enemyType; }
    }

    [SerializeField] protected GameObject m_hitbox;
    [SerializeField] protected GameObject m_boulder;

    public List<Vector3> m_blinkPoints;

    public override void Start()
    {
        base.Start();
        m_state = new RangedAttackState(this);

        m_blinkPoints = new List<Vector3>();

        if (m_enemyType == EnemyType.Boss)
        {
            GameObject temp = GameObject.Find("BlinkPoints");
            
            for (int i = 0; i < temp.transform.childCount; i++)
            {
                m_blinkPoints.Add(temp.transform.GetChild(i).position);
            }
        }
    }

    public override void Update()
    {
        base.Update();
    }

    public void Shoot(Vector3 destination)
    {
        if (m_enemyType == EnemyType.NormalEnemy)
        {
            Rigidbody temp = Instantiate(m_ProjectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            temp.AddForce(transform.up * 8, ForceMode.Impulse);
            temp.AddForce(transform.forward * m_FiringForce, ForceMode.Impulse);
        }
        else if (m_enemyType == EnemyType.EliteEnemy || m_enemyType == EnemyType.Boss)
        {
            Rigidbody tempRef = Instantiate(m_boulder, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            tempRef.AddForce(transform.up * 8, ForceMode.Impulse);
            tempRef.AddForce(transform.forward * m_FiringForce, ForceMode.Impulse);

            GameObject tempRefHB = Instantiate(m_hitbox, transform.position, Quaternion.identity);

            Vector3 vel = (transform.up * 8 + transform.forward*m_FiringForce) / tempRef.mass;

            Vector3 scale = new Vector3(5.0f, 5.0f, 5.0f);
            float fillSpeed = Vector3.Distance(destination, transform.position) / vel.magnitude;
            fillSpeed = scale.x / fillSpeed;


            tempRef.GetComponent<BoulderThrow>().SetTimer(Vector3.Distance(destination, transform.position) / vel.magnitude);
            tempRefHB.GetComponent<HitboxFill>().Setup(scale, fillSpeed, destination);
        }
    }
}
