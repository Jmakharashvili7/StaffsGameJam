using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : Attack
{
    private void OnEnable()
    {
        WeaponAttack();
    }

    protected override IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(m_ResetTime);
        WeaponAttack();
    }

    protected override void WeaponAttack()
    {
        m_WeaponInstance = Instantiate(m_WeaponPrefab, transform);
        m_Animatior = m_WeaponInstance.GetComponent<Animator>();
        m_ResetTime = 1 / m_Animatior.speed * m_CoolDown;
        m_WeaponInstance.transform.SetParent(null);
        StartCoroutine(ResetAttack());
    }

    private void Update()
    {
        if (m_WeaponInstance)
        {
            m_WeaponInstance.transform.position = transform.position;
        }
    }
}
