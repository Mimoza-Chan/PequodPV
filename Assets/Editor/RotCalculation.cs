using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class Calculation : EditorWindow
{
    GameObject planet;
    Transform[] Text = new Transform[] {};
    int radius;
    int dividValue;
    float dividRange;
    float maxRandomValue;
    float interval;
    float nullInterval;
    float textRadius;
    int TextCount;
    bool isCicle;
    float startPoint;

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
                planet.transform.position = OrbitCalculation(radius, dividValue);
            }

            GUILayout.Label("Text Cal");
            TextCount = EditorGUILayout.IntSlider("Text Count", TextCount, 0, 20);
            interval = EditorGUILayout.Slider("Text Interval", interval, 0, 1);
            nullInterval = EditorGUILayout.Slider("Text Null Interval", nullInterval, 0, 1);

            if (TextCount != Text.Length)
            {
                Array.Resize(ref Text, TextCount);
            }
            for (int i = 0;i < TextCount;i++)
            {
                Text[i] = (Transform)EditorGUILayout.ObjectField($"Text No.{i}", Text[i], typeof(Transform), true);
            }
            if (GUILayout.Button("Apply"))
            {
                if (!isCicle) TextPosition(Text);
            }
            if (GUILayout.Button("Reset"))
            {
                Text = new Transform[] {};
                TextCount = 0;
            }
        }
        
    }

    Vector3 OrbitCalculation(float r, float n)
    {
        return new Vector3( r * MathF.Cos(MathF.PI / n), 0, r * Mathf.Sin(Mathf.PI / n));
    }

    void TextPosition(Transform [] Text)
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
                totalvalue += interval;
            }
        }
        // Reuse float value...
        totalvalue = -1 * (totalvalue / 2);
        foreach (Transform tr in Text)
        {
            if (tr == null)
            {
                totalvalue += nullInterval;
            }
            else
            {
                tr.localPosition = new Vector3(totalvalue,0,0);
                totalvalue += interval;
            }
        }
    }
}
