using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    bool CanTakeDamage = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && CanTakeDamage)
        {
            DamageTaken();
        }
    }

    void DamageTaken()
    {
        GetComponent<Health>().TakeDamage(3);
    }

}
