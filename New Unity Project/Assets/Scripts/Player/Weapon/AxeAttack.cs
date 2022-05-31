using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : Attack
{
    private void OnEnable()
    {
        Debug.Log("Begin");
        WeaponAttack();
    }

    protected override IEnumerator ResetAttack()
    {
        Debug.Log("Reset");
        yield return new WaitForSeconds(m_ResetTime);
        WeaponAttack();
    }

    protected override void WeaponAttack()
    {
        m_WeaponInstance = Instantiate(m_WeaponPrefab, transform.position, Quaternion.Euler(transform.parent.transform.rotation.x, transform.parent.transform.rotation.y - 180, transform.parent.transform.rotation.z));
        m_Animatior = m_WeaponInstance.GetComponent<Animator>();
        m_ResetTime = 1 / m_Animatior.speed * m_CoolDown;
        m_WeaponInstance.transform.SetParent(null);
        StartCoroutine(ResetAttack());
    }

    private void Update()
    {
        if(m_WeaponInstance)
        {
            m_WeaponInstance.transform.position = transform.position;
        }
    }

    
}
