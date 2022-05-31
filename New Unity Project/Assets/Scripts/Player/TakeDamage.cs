using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    float health = 100.0f;
    bool CanTakeDamage = true;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && CanTakeDamage)
        {
            DamageTaken();
        }
    }

    IEnumerator DamageCooldown()
    {
        yield return new WaitForSeconds(2.0f);
        CanTakeDamage = true;
    }

    void DamageTaken()
    {
        health -= 20.0f;
        if(health < 0)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DamageCooldown());
        }
    }

}
