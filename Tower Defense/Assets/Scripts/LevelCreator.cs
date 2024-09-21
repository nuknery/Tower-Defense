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
    [SerializeField]
    private GameObject planePrefab;

    [Space(10)]
    [SerializeField]
    private Transform nodeParent;

    [ContextMenu("Create Map")]
    private void CreateMap()
    {
       while (nodeParent.childCount > 0)
        {
            DestroyImmediate(nodeParent.GetChild(0).gameObject);
        }

        GameObject plane = Instantiate(planePrefab, new Vector3((NODE_GRID_ROW_COUNT * offset) / 2 - 1, 0, (NODE_GRID_COLUMN_COUNT * offset) / 2 - 1), Quaternion.identity, nodeParent);
        plane.transform.localScale = new Vector3(0.2f * NODE_GRID_ROW_COUNT, plane.transform.localScale.y, 0.2f * NODE_GRID_COLUMN_COUNT);

        for(int x = 0; x < NODE_GRID_ROW_COUNT; x++)
        {
            for (int z = 0; z < NODE_GRID_COLUMN_COUNT; z++)
            {
                GameObject obj = Instantiate(nodePrefab, new Vector3(x * offset, 0, z * offset), Quaternion.identity, nodeParent);
                obj.name = "Node: " + x + " " + z; 
            }
        }
    }
}