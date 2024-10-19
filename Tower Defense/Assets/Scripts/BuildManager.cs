using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private Color hoverColor;
    [SerializeField]
    private Color defaultColor;

    private GameObject selectedNode;

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit zhit))
        {
            if (hit.collider.gameObject.tag == "Node")
            {
                selectedNode = hit.collider.gameObject;
                selectedNode.GetComponent<MeshRenderer>().material.color = hoverColor;
            }
            else
            {
                if (selectedNode != null)
                {
                    selectedNode.GetComponent<MeshRenderer>().material.color = defaultColor;
                }
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            selectedNode.GetComponent<BuildSettings>().StartBuild(turretPrefab, 0.35f);
        }
    }
}
