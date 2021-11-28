using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] screens;
    [SerializeField] private GameTransitionsManager transitionsManager;
    [SerializeField] private PlayerInputManager inputManager;
    [SerializeField] private PlayerNotActingState playerNotActingState;
    [SerializeField] private Image pageHeader;
    [SerializeField] private Sprite[] pageHeaders;
    [SerializeField] private GameObject playerRenderInUiObject;
    [SerializeField] private Transform playerModelInUi;
    [SerializeField] private float playerSpinSpeed = 5;
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject itemScreenFirstElement, mapScreenFirstElement, systemScreenFirstElement;

    [Header("Item menu")]
    [SerializeField] private ObjectCollector objectCollector;
    [SerializeField] private ItemSlot[] itemSlotsArray;
    [SerializeField] private ItemSlot[] skillSlotsArray;
    [SerializeField] private ItemConfig shieldConfig;
    [SerializeField] private TMP_Text itemNameText;
    [SerializeField] private TMP_Text itemDescriptionText;

    private int currScreenIndex;


    private void Update()
    {
        if (inputManager.actionLeftTrigger.triggered)
        {
            ChangeScreenLeft();
        }
        else if (inputManager.actionRightTrigger.triggered)
        {
            ChangeScreenRight();
        }
        else if (inputManager.actionCancel.triggered)
        {
            transitionsManager.SetShowInGameMenu(false);
        }

        float playerSpinAmount = inputManager.actionSpinPlayerInUI.ReadValue<Vector2>().x;
        playerModelInUi.Rotate(Vector3.up, playerSpinAmount * playerSpinSpeed);
    }

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
        playerRenderInUiObject.SetActive(false);
    }

    public void OpenItemsScreen()
    {
        SetSlotMenuReferences();
        playerRenderInUiObject.SetActive(true);

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

        if (playerNotActingState.canDefend)
        {
            skillSlotsArray[0].SetItem(shieldConfig);
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

    public void OpenSystemScreen()
    {
        eventSystem.SetSelectedGameObject(systemScreenFirstElement);
        currScreenIndex = 2;
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
        SetupScreenInIndex();
    }

    private void ChangeScreenRight()
    {
        screens[currScreenIndex].SetActive(false);
        currScreenIndex++;
        if (currScreenIndex >= screens.Length)
        {
            currScreenIndex = 0;
        }
        SetupScreenInIndex();
    }

    private void SetupScreenInIndex()
    {
        pageHeader.sprite = pageHeaders[currScreenIndex];

        switch (currScreenIndex)
        {
            case 0:
                OpenMapScreen();
                break;
            case 1:
                OpenItemsScreen();
                break;
            case 2:
                OpenSystemScreen();
                break;
        }
    }
}