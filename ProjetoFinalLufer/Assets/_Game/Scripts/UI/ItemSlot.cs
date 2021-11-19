using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] private GameObject selector;
    [SerializeField] private Image itemImage;
    private ItemConfig itemConfig;
    public InGameMenu inGameMenu;

    public void OnSelect(BaseEventData eventData)
    {
        selector.SetActive(true);
        if (itemConfig)
        {
            inGameMenu.SetItemTexts(itemConfig.name, itemConfig.description);
        }
        else
        {
            inGameMenu.SetItemTexts("", "");
        }
    }

    public void OnDeselect(BaseEventData eventData)
    {
        selector.SetActive(false);
    }

    private void OnDisable()
    {
        selector.SetActive(false);
    }

    public void SetItem(ItemConfig config)
    {
        itemConfig = config;
        if (config)
        {
            itemImage.gameObject.SetActive(true);
            itemImage.sprite = config.inventorySprite;
            itemImage.color = config.tint;
        }
        else
        {
            itemImage.gameObject.SetActive(false);
        }
    }
}