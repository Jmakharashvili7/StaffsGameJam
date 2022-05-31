using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxFill : MonoBehaviour
{
    [SerializeField] private GameObject m_CirclePrefab;
    [SerializeField] private int m_Damage;
    [SerializeField] private float m_fillSpeed;
    private GameObject m_fillCircle;
    private GameObject m_player;
    Vector3 m_CircleSize;
    bool m_colliding;
    Material m_material;

    // Start is called before the first frame update
    void Start()
    {
        m_fillCircle = Instantiate(m_CirclePrefab, transform.position, Quaternion.identity);
        m_CirclePrefab.transform.localScale = Vector3.zero;
        m_CircleSize = new Vector3();
        m_material = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        m_CircleSize.x += m_fillSpeed * Time.deltaTime;
        m_CircleSize.y += m_fillSpeed * Time.deltaTime;
        m_CircleSize.z += m_fillSpeed * Time.deltaTime;
        m_fillCircle.transform.localScale = m_CircleSize;

        m_material.SetVector("_CenterPos", transform.position);
        m_material.SetFloat("_Radius", GetComponent<SphereCollider>().radius);

        if (m_fillCircle.transform.localScale.x >= transform.localScale.x)
        {
            if (m_colliding)
            {
                if (m_player)
                {
                    // take damage
                }
            }

            Destroy(m_fillCircle);
            Destroy(gameObject);
        }
    }

    public void Setup(Vector3 scale, float fillSpeed, Vector3 destination)
    {
        m_fillSpeed = fillSpeed;
        transform.localScale = scale;
        transform.position = destination;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_colliding = true;
            m_player = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_colliding = false;
            m_player = null;
        }
    }
}
