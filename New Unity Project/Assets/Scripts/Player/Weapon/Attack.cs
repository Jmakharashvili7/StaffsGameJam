using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected GameObject m_WeaponPrefab;
    protected GameObject m_WeaponInstance;

    protected Animator m_Animatior;

    [SerializeField] protected float m_CoolDown;
    protected float m_ResetTime;

    protected void Start()
    {
        m_Animatior = GetComponent<Animator>();
        m_ResetTime = 1 / m_Animatior.speed * m_CoolDown;
        WeaponAttack();
    }

    // Start is called before the first frame update
    protected void OnEnable()
    {
        m_Animatior = GetComponent<Animator>();
        m_ResetTime = 1 / m_Animatior.speed * m_CoolDown;
        WeaponAttack();
    }

    protected virtual void WeaponAttack() { }

    protected virtual void DestroyWeapon() { Destroy(m_WeaponInstance); }

    protected virtual IEnumerator ResetAttack() { yield return new WaitForSeconds(m_ResetTime); }
}

