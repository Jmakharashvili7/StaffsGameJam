using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySword : MonoBehaviour
{
    void EndOfAttack()
    {
        Destroy(gameObject);
    }
}
