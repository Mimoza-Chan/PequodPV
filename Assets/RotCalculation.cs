using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;


public class RotCalculation : EditorWindow
{
    GameObject planet;
    int radius;
    int dividValue;
    float maxRandomValue;

    [MenuItem("Tools/Calculate")]
    public static void Excute()
    {
        RotCalculation window = GetWindow<RotCalculation>();
        window.titleContent = new GUIContent("Calculation Window");
    }

    void OnGUI()
    {
        using (new EditorGUILayout.VerticalScope())
        {
            planet = (GameObject)EditorGUILayout.ObjectField("GameObject", planet, typeof(GameObject), true);
            radius = EditorGUILayout.IntField("Radius", radius);
            GUILayout.Label("Enter minus value to set the angle over 180");
            dividValue = EditorGUILayout.IntField("Polygon value", dividValue);
        }
        if (GUILayout.Button("Apply"))
        {
            planet.transform.position = Calculate(radius, dividValue);
        }
    }

    Vector3 Calculate(int r, int n)
    {
        return new Vector3( r * MathF.Cos(MathF.PI / n), 0, r * Mathf.Sin(Mathf.PI / n));
    }
}
