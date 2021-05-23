using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private List<CollectableObject> inventory;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private string collectableTag;

    private void Start()
    {
        inventory = new List<CollectableObject>();
        UpdateInvetoryUI();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == collectableTag)
        {
            CollectableObject collectable = hit.gameObject.GetComponent<CollectableObject>();
            if (collectable != null)
            {
                inventory.Add(collectable);
                collectable.Collect();
                UpdateInvetoryUI();
            }
        }
    }

    private void UpdateInvetoryUI()
    {
        UIText.text = inventory.Count.ToString();
    }
}
