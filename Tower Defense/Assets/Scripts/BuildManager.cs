using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private Color hoverColor;
    [SerializeField]
    private Color defaultColor;

    [SerializeField]
    private GameObjectturretPrefab;

    private GameObject selectedNode;

    private bool canBuild;
    private int turretIndex, cost;

    private void Awake()
    {
        if (Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.gameObject.tag == "Node")
            {
                var node = hit.collider.GetComponent<BuildSettings>();
                if (node.structure == null)
                {
                    selectedNode = hit.collider.gameObject;
                    selectedNode.GetComponent<MeshRenderer>().material.color = hoverColor;
                }
            }
            else
            {
                if (selectedNode != null)
                {
                    selectedNode.GetComponent<MeshRenderer>().material.color = defaultColor;
                    selectedNode = null;
                }
            }
        }

        if (Input.GetMouseButtonDown(0) && selectedNode != null)
        {
            selectedNode.GetComponent<BuildSettings>().StartBuild(turretPrefab, 0.35f);
        }
    }

    public void SetBuildTurret(int cost, int buildIndex)
    {
        canBuild = true;
        turretIndex = buildIndex;
        this.cost = cost;
    }
}
