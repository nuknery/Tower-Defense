using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShop : MonoBehaviour
{
    [SerializeField]
    private Text costText
    [SerializeField]
    private int cost;
    [SerializeField]
    private int buildIndex;

    [SerializeField]
    private ButtonShop button;

    private void Start()
    {
        costText.text = cost.ToString();
        var buildManager = buildManager.Instance;
        button.onClick.AddListener(() => buildManager.SetBuildTurret(cost, buildIndex));
    }

    
    private void Awake()
    {
        costText.text = cost.ToString();
    }
}
