using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    private int NODE_GRID_ROW_COUNT = 4;
    [SerializeField]
    private int NODE_GRID_COLUMN_COUNT = 4;
    [SerializeField]
    [Tooltip("Offset between nodes")]
    private float offset = 1f;

    [Space(15)]
    [Header("Prefabs:")]
    [SerializeField]
    private GameObject nodePrefab;

    private void Start()
    {
        
    }

    [ContextMenu("Create Nodes")]
    private void CreateNodes()
    {
       
    
        for(int x = 0; x < NODE_GRID_ROW_COUNT; x++)
        {
            for (int z = 0; z < NODE_GRID_COLUMN_COUNT; z++)
            {
                Instantiate(nodePrefab, new Vector3(x * offset, 0, z * offset), Quaternion.identity, transform);
            }
        }
    }
}