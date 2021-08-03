using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private int keysPossessed;
    private bool canCollect = true;
    private WaitForSeconds collectionDelay;
    [SerializeField] private TextMeshProUGUI UIText;
    [SerializeField] private string collectableTag;

    private void Start()
    {
        UpdateInvetoryUI();
        collectionDelay = new WaitForSeconds(0.4f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == collectableTag && canCollect)
        {
            StartCoroutine(PickupWithDelay(hit));
        }
    }

    IEnumerator PickupWithDelay(ControllerColliderHit hit)
    {
        CollectableObject collectable = hit.gameObject.GetComponent<CollectableObject>();

        if (collectable != null)
        {
            Item collectedItem = collectable.gameObject.GetComponent<Item>();

            GetItem(collectedItem);

            collectable.Collect();
        }

        canCollect = false;
        yield return collectionDelay;
        canCollect = true;
    }

    public void GetItem(Item item)
    {
        if (item.name == "Key")
        {
            ++keysPossessed;
        }
        else if(item.name == "Heal")
        {
            item.Use(gameObject);
        }
        UpdateInvetoryUI();
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
