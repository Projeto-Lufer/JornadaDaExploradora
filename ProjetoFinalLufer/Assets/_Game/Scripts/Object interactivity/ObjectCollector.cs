using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    private bool canCollect = true;
    private WaitForSeconds collectionDelay;
    [SerializeField] private List<Image> keyImages;
    [SerializeField] private Color regularKeyColor;
    [SerializeField] private Color bossKeyColor;
    [SerializeField] private Color blueKeyColor;
    [SerializeField] private Color orangeKeyColor;
    [SerializeField] private Color redKeyColor;

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
        List<Tuple<Item, Color>> itemColorMap = new List<Tuple<Item, Color>>{
            new Tuple<Item, Color>(Item.regularKey,regularKeyColor),
            new Tuple<Item, Color>(Item.blueKey,blueKeyColor),
            new Tuple<Item, Color>(Item.orangeKey,orangeKeyColor),
            new Tuple<Item, Color>(Item.redKey,redKeyColor),
            new Tuple<Item, Color>(Item.bossKey,bossKeyColor),
        };
        int offset = 0;
        foreach (var pair in itemColorMap)
        {
            offset += FillSlots(offset, pair.Item1, pair.Item2);
        }
        for (int i = offset; i < keyImages.Count; i++)
        {
            keyImages[i].gameObject.SetActive(false);
        }
    }
    private int FillSlots(int offset, Item itemType, Color color)
    {
        var count = (inventory.ContainsKey(itemType) ? inventory[itemType] : 0);
        for (int i = 0; i < count; i++)
        {
            keyImages[offset + i].gameObject.SetActive(true);
            keyImages[offset + i].color = color;
        }
        return count;
    }

    public int GetKeysPossessed()
    {
        return (inventory.ContainsKey(Item.regularKey) ? inventory[Item.regularKey] : 0);
    }
}
