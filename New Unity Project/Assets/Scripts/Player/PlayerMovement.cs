using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody m_Rb;

    Vector3 m_MoveDirection;

    float m_HorizontalMovement;
    float m_VerticalMovement;
    [SerializeField] [Range(0, 1)] float m_RotateRate = 0.5f; //Keep between 0 and 1



    [SerializeField] float m_MoveSpeed = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb = gameObject.GetComponent<Rigidbody>();
        m_MoveDirection = new Vector3();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_HorizontalMovement = Input.GetAxis("Horizontal");
        m_VerticalMovement = Input.GetAxis("Vertical");

        if (m_HorizontalMovement != 0 || m_VerticalMovement != 0)
        {
            m_MoveDirection = new Vector3(m_HorizontalMovement, 0.0f, m_VerticalMovement);

            m_Rb.MovePosition(transform.position + m_MoveDirection * m_MoveSpeed * Time.fixedDeltaTime);
            m_Rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(m_MoveDirection.normalized), m_RotateRate);
        }
    }
}
