using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
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
