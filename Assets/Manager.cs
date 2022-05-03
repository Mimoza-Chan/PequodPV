using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
public class Manager: MonoBehaviour
{
    [SerializeField] Image fadePanel;
    [SerializeField] Image logoImage;
    [SerializeField] Image creditsImage;
    [SerializeField] float time;
    [SerializeField] float logoFadeTime;
    public void OnStartPV()
    {
        SceneManager.LoadScene(0);
    }
    
    public void SetAlphaZero()
    {
        fadePanel.color = new Color(0,0,0,0);
    }

    public void SetAlphaMax()
    {
        fadePanel.color = new Color(0,0,0,1);
        logoImage.color = new Color(1,1,1,0);
        creditsImage.color = new Color(1,1,1,0);
    }

    public void FadeIn()
    {
        fadePanel.DOFade(1, time);
    }

    public void FadeOut()
    {
        fadePanel.DOFade(0,time);
    }

    public void LogoFadeInOut()
    {
        logoImage.DOFade(1, logoFadeTime)
        .SetLoops(2, LoopType.Yoyo)
        .OnComplete(() => 
        {
            creditsImage.DOFade(1, logoFadeTime)
            .SetLoops(2, LoopType.Yoyo);
        });
    }
}