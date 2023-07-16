using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTakipOyuncu : MonoBehaviour
{
    [SerializeField] float sSpeed = 10;

    public Transform cameraTarget;
    public Transform lookTarget;
    public Vector3 dist;

    

    void LateUpdate()
    {
        Vector3 dPos = cameraTarget.position + dist;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, sSpeed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);  

    }
}
