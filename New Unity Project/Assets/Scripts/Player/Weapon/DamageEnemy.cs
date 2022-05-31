using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.tag == "Boss")
        {
            --collision.gameObject.GetComponent<EnemyAI>().Health;
            Debug.Log(collision.gameObject.GetComponent<EnemyAI>().Health.ToString());
        }
    }
}
