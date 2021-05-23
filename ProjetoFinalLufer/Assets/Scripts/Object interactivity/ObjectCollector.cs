using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private int keysPossessed;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private string collectableTag;

    private void Start()
    {
        UpdateInvetoryUI();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == collectableTag)
        {
            CollectableObject collectable = hit.gameObject.GetComponent<CollectableObject>();
            if (collectable != null)
            {
                ++keysPossessed;
                collectable.Collect();
                UpdateInvetoryUI();
            }
        }
    }

    public void UseKey()
    {
        --keysPossessed;
        UpdateInvetoryUI();
    }

    private void UpdateInvetoryUI()
    {
        UIText.text = keysPossessed.ToString();
    }

    public int GetKeysPossessed()
    {
        return keysPossessed;
    }
}
