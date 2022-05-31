using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSai : MonoBehaviour
{
    [SerializeField] GameObject m_SaiPrefab;
    GameObject m_SaiInstance;

    Rigidbody m_Rb;

    [SerializeField] float m_SaiLifetime;
    [SerializeField] float m_SaiCooldown;
    [SerializeField] float m_SaiThrowForce;

    bool m_CanThrow = true;

    // Update is called once per frame
    void Update()
    {
        if(m_CanThrow)
        {
            m_CanThrow = false;
            StartCoroutine(SaiAttack());
        }
    }

    IEnumerator SaiAttack()
    {
        m_SaiInstance = Instantiate(m_SaiPrefab, transform.position + transform.forward + transform.up/2, transform.rotation);
        m_Rb = m_SaiInstance.GetComponent<Rigidbody>();
        m_Rb.AddForce(transform.forward * m_SaiThrowForce, ForceMode.Impulse);

        yield return new WaitForSeconds(m_SaiCooldown);

        m_CanThrow = true;

        Destroy(m_SaiInstance);
    }
}
