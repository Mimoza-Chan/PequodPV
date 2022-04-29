using UnityEditor;
using UnityEngine;

public static class DelSceneIDMap
    {
        [MenuItem("Tools/DelSceneIDMap")]
        public static void DelSceneIdMap()
        {
            var obj = GameObject.Find("SceneIDMap");
            if (obj != null)
            {
                Object.DestroyImmediate(obj);
                Debug.Log("del");
            }
        }
    }