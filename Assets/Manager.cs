using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.UI;
public class Manager: MonoBehaviour
{
    [SerializeField] Volume m_Volume;
    [SerializeField] Image fadePanel;
    [SerializeField] float smoothTime;
    float currentVelocity;
    float currentValue;
    bool startSmoothDamp;
    bool endSmoothDamp;
    Vignette vignette;
    public void OnStartPV()
    {
        SceneManager.LoadScene(0);
    }

    public void OnStartFade()
    {
        startSmoothDamp = true;
    }

    void Awake()
    {
        VolumeProfile profile = m_Volume.sharedProfile;
        profile.TryGet<Vignette>(out vignette);
        startSmoothDamp = false;
        endSmoothDamp = false;
        currentValue = 0;
    }

    public void OnResetFade()
    {
        startSmoothDamp = false;
        vignette.intensity.value = 0;
        fadePanel.color = new Color(0,0,0,0);
    }

    public void OnResetFadeOut()
    {
        endSmoothDamp = false;
        vignette.intensity.value = 1;
        fadePanel.color = new Color(0,0,0,1);
    }

    public void OnFadeOut()
    {
        endSmoothDamp = true;
    }

    void Update()
    {
        if (startSmoothDamp)
        {
            if (currentValue > 1) return;
            currentValue = Mathf.SmoothDamp(currentValue, 1 ,ref currentVelocity, smoothTime);
            vignette.intensity.value = currentValue;
            fadePanel.color = new Color(0,0,0,currentValue);
        }
        if (endSmoothDamp)
        {
            if (currentValue >= 1)
            {
                currentValue = 1;
                return;
            }
            currentValue += Time.deltaTime;
            vignette.intensity.value = 1 - currentValue;
            fadePanel.color = new Color(0,0,0,1 - currentValue);
        }
    }

}