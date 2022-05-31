using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public GameObject hitPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
        else 
        {
            Debug.Log("No Speed");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Hit Something");
            speed = 0;

            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;

            if (hitPrefab != null)
            {
                var hitFX = Instantiate(hitPrefab, transform.position, Quaternion.identity);
                var psHit = hitFX.GetComponent<ParticleSystem>();
                if (psHit != null)
                {
                    Destroy(hitFX, psHit.main.duration);
                }
                else
                {
                    var psChild = hitFX.transform.GetChild(0).GetComponent<ParticleSystem>();
                    Destroy(hitFX, psChild.main.duration);
                }
            }

            Destroy(gameObject);
        }
    }
}
