using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpin : MonoBehaviour
{
    [SerializeField] GameObject m_SwordPrefab;
    GameObject m_SwordInstance;

    Animator m_Animator;
    float m_Cooldown;

    // Start is called before the first frame update
    void Start()
    {
        
        SwordAttack();
    }

    private void Update()
    {
        if(m_SwordInstance)
        {
            m_SwordInstance.transform.position = transform.position;
        }
    }

    void SwordAttack()
    {
        m_SwordInstance = Instantiate(m_SwordPrefab, transform);
        m_SwordInstance.transform.SetParent(null);
        StartCoroutine(ResetAttack());
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(m_Cooldown);
        SwordAttack();
    }

}
