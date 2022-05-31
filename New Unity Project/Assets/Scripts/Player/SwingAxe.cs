using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAxe : MonoBehaviour
{
    [SerializeField] GameObject m_AxePrefab;
    GameObject m_AxeInstance;

    Animator m_Animator;

    float m_Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Cooldown = 1 / m_Animator.speed * 2;
        AxeAttack();
    }

    private void Update()
    {
        if(m_AxeInstance)
        {
            m_AxeInstance.transform.position = transform.position;
        }
    }

    void AxeAttack()
    {
        m_AxeInstance = Instantiate(m_AxePrefab, transform);
        m_AxeInstance.transform.SetParent(null);
        m_AxeInstance.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y - 180, transform.rotation.z);
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(m_Cooldown);
        AxeAttack();
    }
}
