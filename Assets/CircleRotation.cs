using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    private float radius;
    private Transform tr;
    void Awake()
    {
        tr = gameObject.transform;   
    }

    void Start()
    {
        radius = tr.position.x;
        tr.position = new Vector3(Mathf.Cos(UnityEngine.Random.Range(-0.1f,0.1f)) * radius,
        0, 
        Mathf.Sin(UnityEngine.Random.Range(-0.1f,0.1f)) * radius);
    }
}
