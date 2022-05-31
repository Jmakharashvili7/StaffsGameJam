using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : Attack
{

    protected override void WeaponAttack()
    {
        m_WeaponInstance = Instantiate(m_WeaponPrefab, transform);
        m_WeaponInstance.transform.SetParent(null);
        m_WeaponInstance.transform.rotation = Quaternion.Euler(transform.parent.transform.rotation.x, transform.parent.transform.rotation.y - 180, transform.parent.transform.rotation.z);
        ResetAttack();
    }

    private void Update()
    {
        if(m_WeaponInstance)
        {
            m_WeaponInstance.transform.position = transform.position;
        }
    }

    protected override IEnumerator ResetAttack()
    {
        
        yield return new WaitForSeconds(m_ResetTime);

        WeaponAttack();
    }
}
