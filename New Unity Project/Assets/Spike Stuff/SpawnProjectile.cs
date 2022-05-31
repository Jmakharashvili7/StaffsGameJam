using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public RotateToMouse rotateToMouse;

    private GameObject effectSpawning;
    private float timeToFire = 0;

    // Start is called before the first frame update
    void Start()
    {
        effectSpawning = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectSpawning.GetComponent<ProjectileMovement>().fireRate;
            SpawnEffect();
        }
    }

    void SpawnEffect()
    {
        GameObject effect;

        if (firePoint != null)
        {
            effect = Instantiate(effectSpawning, firePoint.transform.position, Quaternion.identity);
            if (rotateToMouse != null)
            {
                effect.transform.localRotation = rotateToMouse.GetRotation();
            }
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
