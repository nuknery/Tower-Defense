using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private const int NODE_GRID_ROW_COUNT = 4;

    [SerializeField]
    private GameObeject nodePrefab;

    private void Start()
    {
        CreateNodes();
    }

    private void CreateNodes()
    {
        for(int x = 0; x < NODE_GRID_SIZE; x++)
        {
            for (int z = 0; z < NODE_GRID_SIZE; z++)
            {
                Instantiate(nodePrefab, new Vector3(x, 0, y), Quaternion.identity);
            }
        }
    }
}