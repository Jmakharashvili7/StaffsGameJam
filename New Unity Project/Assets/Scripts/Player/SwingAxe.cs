using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAxe : MonoBehaviour
{
    Animator m_Animator;

    Quaternion PlayRotation;

    bool m_IsPlaying;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        PlayRotation = transform.parent.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = PlayRotation;
    }

    IEnumerator AxeCooldown()
    {
        m_Animator.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        m_Animator.enabled = true;
        PlayRotation = transform.parent.transform.rotation;
        transform.GetChild(0).gameObject.SetActive(true);
    }



}
