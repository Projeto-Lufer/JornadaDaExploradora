using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] screens;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject itemScreenFirstElement, mapScreenFirstElement, systemScreenFirstElement;

    [Header("Item menu")]
    [SerializeField] private ObjectCollector objectCollector;
    [SerializeField] private ItemSlot[] itemSlotsArray;
    [SerializeField] private ItemSlot[] skillSlotsArray;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemDescriptionText;

    private int currScreenIndex;

    private void SetSlotMenuReferences()
    {
        foreach (var slot in itemSlotsArray)
        {
            slot.inGameMenu = this;
        }

        foreach (var skill in skillSlotsArray)
        {
            skill.inGameMenu = this;
        }
    }

    private void OnDisable()
    {
        screens[currScreenIndex].SetActive(false);
    }

    public void OpenItemsScreen()
    {
        SetSlotMenuReferences();

        currScreenIndex = 1;
        screens[currScreenIndex].SetActive(true);

        Dictionary<ItemConfig, int> inventory = objectCollector.GetInventory();

        int lastSetKeyIndex = 0;
        ItemConfig itemToSet = null;

        foreach (ItemConfig item in inventory.Keys)
        {
            for (int j = 0 ; j < inventory[item] ; j++)
            {
                itemSlotsArray[lastSetKeyIndex].SetItem(item);
                lastSetKeyIndex++;
            }
        }
        for (; lastSetKeyIndex < itemSlotsArray.Length; lastSetKeyIndex++)
        {
            itemSlotsArray[lastSetKeyIndex].SetItem(itemToSet);
        }

        eventSystem.SetSelectedGameObject(itemScreenFirstElement);
    }

    public void SetItemTexts(string itemName, string description)
    {
        itemNameText.text = itemName;
        itemDescriptionText.text = description;
    }

    public void OpenMapScreen()
    {
        eventSystem.SetSelectedGameObject(mapScreenFirstElement);
        currScreenIndex = 0;
        screens[currScreenIndex].SetActive(true);
    }

    private void ChangeScreenLeft()
    {
        screens[currScreenIndex].SetActive(false);
        currScreenIndex--;
        if (currScreenIndex < 0)
        {
            currScreenIndex = screens.Length - 1;
        }
        screens[currScreenIndex].SetActive(true);
    }

    private void ChangeScreenRight()
    {
        screens[currScreenIndex].SetActive(false);
        currScreenIndex++;
        if (currScreenIndex >= screens.Length)
        {
            currScreenIndex = 0;
        }
        screens[currScreenIndex].SetActive(true);
    }
}