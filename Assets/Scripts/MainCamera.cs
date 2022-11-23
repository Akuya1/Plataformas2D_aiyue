using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]private Transform cameraTarget;
   
    void Update()
    {
        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y, -10);
    }
}
