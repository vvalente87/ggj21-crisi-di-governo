using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PoliticInstantiator : MonoBehaviour
{
    [SerializeField]
    private GameObject politic;
    
    [ContextMenu("Generate")]
    void InstantiatePolitic()
    {
        for (int i = transform.childCount-1; i >=0 ; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        var escapes = GameObject.FindGameObjectsWithTag("Escape");
        var group = GetComponent<SpriteRenderer>();
        var politicSpritetrenderer = politic.GetComponent<SpriteRenderer>();

        var politicSize = politicSpritetrenderer.bounds.size;
        var groupSize = group.bounds.size;
        var columns = groupSize.x / politicSize.x;
        var rows = groupSize.y / politicSize.y;

        for (int i = 0; i < rows; i++)
        {
            for(int j=0;j< columns;j++)
            {                 
                 
                var instance = PrefabUtility.InstantiatePrefab(politic,transform) as GameObject;
                instance.transform.localPosition = new Vector2(j * politicSize.x, -i * politicSize.y);
                instance.GetComponent<PoliticianEscape>().Escape = escapes[Random.Range(0, escapes.Length)];
                EditorUtility.SetDirty(instance);
            }
            
        }

        
    }
}