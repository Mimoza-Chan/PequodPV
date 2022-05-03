using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CinemachinePosUpdate : MonoBehaviour
{
    [SerializeField] Manager fadeManager;
    [SerializeField] CinemachineVirtualCamera vcam;
    [SerializeField] CinemachinePathBase[] paths;
    [SerializeField] float timePerPlanet;
    [SerializeField] float timePerText;
    [SerializeField] Transform[] lookAt;
    CinemachineTrackedDolly dolly;
    float currentPos = 0;
    float additional = 0;

    void Awake()
    {
        dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>();
        dolly.m_Path = paths[0];
        dolly.m_PathPosition = 0;
        vcam.LookAt = lookAt[0];
        fadeManager.SetAlphaMax();
    }

    void Start()
    {
        fadeManager.FadeOut();
        DOTween.To(() => currentPos + additional, (val) => currentPos = val, additional + 1, timePerPlanet)
        .SetLoops(7, LoopType.Restart)
        .SetEase(Ease.InOutCubic)
        .OnStepComplete(() => 
        {
            Debug.Log("on step complete");
            additional += 1;
        })
        .OnComplete(() => 
        {
            Debug.Log("Path 0 clear");
            dolly.m_Path = paths[1];
            dolly.m_PathPosition = 0;
            currentPos = 0;
            vcam.m_LookAt = lookAt[8];
            DOTween.To(() => currentPos, (val) => currentPos = val, 5, timePerText)
            .OnComplete(() =>
            {
                Debug.Log("dotween text clear");
                fadeManager.LogoFadeInOut();
            });
        });
        
    }

    void LookControllerForPath1()
    {
        if (dolly.m_PathPosition > 3.3f && dolly.m_PathPosition < 3.4f)
            vcam.m_LookAt = lookAt[9];
    }

    void LookControllerForPath0()
    {
        if (dolly.m_PathPosition > 0.5f && dolly.m_PathPosition < 1.4f)
        {
            vcam.m_LookAt = lookAt[1];
        }
        else if (dolly.m_PathPosition > 1.5f && dolly.m_PathPosition < 2.4f)
        {
            vcam.m_LookAt = lookAt[2];
        }
        else if (dolly.m_PathPosition > 2.5f && dolly.m_PathPosition < 3.4f)
        {
            vcam.m_LookAt = lookAt[3];
        }
        else if (dolly.m_PathPosition > 3.5f && dolly.m_PathPosition < 4.4f)
        {
            vcam.m_LookAt = lookAt[4];
        }
        else if (dolly.m_PathPosition > 4.5f && dolly.m_PathPosition < 5.4f)
        {
            vcam.m_LookAt = lookAt[5];
        }
        else if (dolly.m_PathPosition > 5.5f && dolly.m_PathPosition < 6.4f)
        {
            vcam.m_LookAt = lookAt[6];
        }
        else if (dolly.m_PathPosition > 6.5f && dolly.m_PathPosition < 7.4f)
        {
            vcam.m_LookAt = lookAt[7];
        }
    }

    void LateUpdate()
    {
        if (dolly.m_Path == paths[0]) 
        {
            LookControllerForPath0();
            dolly.m_PathPosition = currentPos + additional;
        }
        else if (dolly.m_Path == paths[1]) 
        {
            LookControllerForPath1();
            dolly.m_PathPosition = currentPos;
        }
        
    }
}

