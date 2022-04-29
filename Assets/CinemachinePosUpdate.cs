using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachinePosUpdate : MonoBehaviour
{
    [SerializeField, Range(0,2)] float Velocity = 1;
    [SerializeField] GameObject[] planets;
    CinemachineTrackedDolly dolly;
    CinemachineVirtualCamera vcam;
    float path;
    int currenIndex = 0;
    int lastIndex;
    void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();
        vcam.m_LookAt = planets[0].transform;
        lastIndex = 0;
    }

    void Start()
    {
        path = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (path > lastIndex + 1)
        {
            lastIndex += 1;
        }
        path = (1 - Mathf.Cos(Time.time)) + lastIndex;
        Debug.Log(path);
        // dolly.m_PathPosition = path;
    }
}
