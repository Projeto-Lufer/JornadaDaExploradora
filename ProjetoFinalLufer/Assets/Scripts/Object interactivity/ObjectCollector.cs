using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private List<CollectableObject> inventory;
    private TextMeshProUGUI UIText;
    [SerializeField] private LayerMask collectacbelLayer;

    private void Start()
    {
        UpdateInvetoryUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == collectacbelLayer.value)
        {
            CollectableObject collectable = collision.gameObject.GetComponent<CollectableObject>();
            if (collectable != null)
            {
                inventory.Add(collectable);
                collectable.Collect();
            }
        }
    }

    private void UpdateInvetoryUI()
    {
        UIText.text = inventory.Count.ToString();
    }
}
