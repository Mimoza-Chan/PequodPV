using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class Calculation : EditorWindow
{
    GameObject planet;
    GameObject[] Text = new GameObject[] {};
    int radius;
    int dividValue;
    float maxRandomValue;
    float interval;
    float nullInterval;
    int TextCount;

    [MenuItem("Tools/Calculate")]
    public static void Excute()
    {
        Calculation window = GetWindow<Calculation>();
        window.titleContent = new GUIContent("Calculation Window");
        
    }

    void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            GUILayout.Label("Planet Cal");
            planet = (GameObject)EditorGUILayout.ObjectField("GameObject", planet, typeof(GameObject), true);
            radius = EditorGUILayout.IntField("Radius", radius);
            GUILayout.Label("Enter minus value to set the angle over 180");
            dividValue = EditorGUILayout.IntField("Polygon value", dividValue);
            if (GUILayout.Button("Apply"))
            {
                planet.transform.position = Calculate(radius, dividValue);
            }
            GUILayout.Label("Text Cal");
            TextCount = EditorGUILayout.IntField("Text Count", TextCount);
            interval = EditorGUILayout.FloatField("Text Interval", interval);
            nullInterval = EditorGUILayout.FloatField("Text Null Interval", nullInterval);

            if (TextCount != Text.Length)
            {
                Array.Resize(ref Text, TextCount);
            }
            for (int i = 0;i < TextCount;i++)
            {
                Text[i] = (GameObject)EditorGUILayout.ObjectField($"Text No.{i}", Text[i], typeof(GameObject), true);
            }
            if (GUILayout.Button("Apply"))
            {
                float totalvalue = 0;
                for (int i = 0;i < Text.Length;i++)
                {
                    if (Text[i] == null)
                    {
                        totalvalue += nullInterval;
                    }
                    else
                    {
                        Text[i].transform.localPosition = new Vector3(totalvalue, 0, 0);
                        totalvalue += interval;
                    }
                }
            }
            if (GUILayout.Button("Reset"))
            {
                Text = new GameObject[] {};
                TextCount = 0;
            }
        }
        
    }

    Vector3 Calculate(int r, int n)
    {
        return new Vector3( r * MathF.Cos(MathF.PI / n), 0, r * Mathf.Sin(Mathf.PI / n));
    }
}
