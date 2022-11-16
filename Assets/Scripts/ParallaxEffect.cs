using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField]private float ParallaxMultiplier;

    private Transform cameraTransform;
    private Vector3 cameraPreviousPos;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        cameraPreviousPos = cameraTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = cameraTransform.position.x - cameraPreviousPos.x;
        transform.Translate(new Vector3(x, 0f, 0f));
    }
}
