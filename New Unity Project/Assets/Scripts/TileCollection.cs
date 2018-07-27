using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu()]
public class TileCollection : ScriptableObject
{
    public ScriptableTile[] sT;
#if UNITY_EDITOR
    
    [ContextMenu("GatherTiles")]
    public void GatherTiles()
    {
        sT = GetAllInstances<ScriptableTile>();
        EditorUtility.SetDirty(this);
    }

    public static T[] GetAllInstances<T>() where T : ScriptableObject
    {
        string[] guids = AssetDatabase.FindAssets("t:" + typeof(T).Name, new[] { "Assets/Tiles" });  //FindAssets uses tags check and find in file location
        T[] a = new T[guids.Length];
        for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
        {
            string path = AssetDatabase.GUIDToAssetPath(guids[i]);
            a[i] = AssetDatabase.LoadAssetAtPath<T>(path);
        }

        return a;

    }
#endif
}
///<summary>
///sT is equal to get all instances of scriptable tile
///SetDirty(flag to save this data)
///GetAllInstances:
///AssetDatabase.find assets equal to scriptable object name in the data folder
///Add them to a new array
///Loop through that array
///Foreach get the guid to the asset path
///Then load those asset paths
///Return that path
/// </summary>
