using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    private bool canCollect = true;
    private WaitForSeconds collectionDelay;
    [SerializeField] private List<GameObject> keyImages;
    [SerializeField] private string collectableTag;

    private void Start()
    {
        UpdateInvetoryUI();
        collectionDelay = new WaitForSeconds(0.4f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == collectableTag && canCollect)
        {
            StartCoroutine(PickupWithDelay(hit));
        }
    }

    IEnumerator PickupWithDelay(ControllerColliderHit hit)
    {
        CollectableObject collectable = hit.gameObject.GetComponent<CollectableObject>();

        if (collectable != null)
        {
            collectable.Collect(this);
        }

        canCollect = false;
        yield return collectionDelay;
        canCollect = true;
    }

    public int CheckQty(Item i)
    {
        return (inventory.ContainsKey(i) ? inventory[i] : 0);
    }

    public void GetItem(Item item)
    {
        inventory[item] = 1 + (inventory.ContainsKey(item) ? inventory[item] : 0);
        UpdateInvetoryUI();
    }

    public void UseKey()
    {
        UseItem(Item.regularKey);
    }
    public bool UseItem(Item item)
    {
        if ((inventory.ContainsKey(item) ? inventory[item] : 0) > 0)
        {
            inventory[item] = (inventory.ContainsKey(item) ? inventory[item] : 0) - 1;
            UpdateInvetoryUI();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateInvetoryUI()
    {
        var numberOfKeys = (inventory.ContainsKey(Item.regularKey) ? inventory[Item.regularKey] : 0);
        for (int i = 0; i < keyImages.Count; i++)
        {
            keyImages[i].SetActive(i < numberOfKeys);
        }
    }

    public int GetKeysPossessed()
    {
        return (inventory.ContainsKey(Item.regularKey) ? inventory[Item.regularKey] : 0);
    }
}
