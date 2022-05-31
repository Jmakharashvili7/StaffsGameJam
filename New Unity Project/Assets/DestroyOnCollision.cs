using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    float m_counter;

    private void Update()
    {
        m_counter += Time.deltaTime;

        if (m_counter >= 1.0f)
        {
            Destroy(transform.gameObject);
        }
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // do damage to player
            Destroy(transform.gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(transform.gameObject);
        }
    }
}
