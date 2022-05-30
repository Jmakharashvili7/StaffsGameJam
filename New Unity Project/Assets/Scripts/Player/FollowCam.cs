using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] GameObject CamTarget;

    [SerializeField] float KeepDistanceY;
    [SerializeField] float KeepDistanceZ;
    [SerializeField] float TiltRotation;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(CamTarget.transform.position.x, CamTarget.transform.position.y + KeepDistanceY, CamTarget.transform.position.z + KeepDistanceZ);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(CamTarget.transform.position.x, CamTarget.transform.position.y + KeepDistanceY, CamTarget.transform.position.z + KeepDistanceZ);
    }
}
