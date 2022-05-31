using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireOrbs : Attack
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
        m_WeaponInstance = Instantiate(m_WeaponPrefab, transform.position + transform.forward, transform.rotation);
        StartCoroutine(ResetAttack());
    }
}
