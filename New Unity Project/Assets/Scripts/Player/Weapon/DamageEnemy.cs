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
        
        if(collision.gameObject.tag == "MeleeBoss")
        {
 
            collision.gameObject.GetComponent<MeleeEnemy>().Health -= 1;
            Debug.Log("Boss Health: " + collision.gameObject.GetComponent<EnemyAI>().Health.ToString());
        }
        else if(collision.gameObject.tag == "RangedBoss")
        {
            collision.gameObject.GetComponent<RangedEnemyAI>().Health -= 1;
            Debug.Log("Boss Health " + collision.gameObject.GetComponent<EnemyAI>().Health.ToString());
        }
    }
}
