using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager: MonoBehaviour
{
    public void OnStartPV()
    {
        SceneManager.LoadScene(0);
    }
}