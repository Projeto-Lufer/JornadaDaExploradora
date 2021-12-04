using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectCollector : MonoBehaviour
{
    private Dictionary<ItemConfig, int> inventory;
    private bool canCollect = true;
    private WaitForSeconds collectionDelay;
    [SerializeField] private List<Image> keyImages;
    [SerializeField] private ItemConfig regularKeyConfig, bossKeyConfig, blueKeyConfig, orangeKeyConfig, redKeyConfig;
    [SerializeField] private string collectableTag;
    [SerializeField] private ItemDescriptionPopup itemPopup;
    [SerializeField] private ConcurrentStateMachine stateMachine;
    [SerializeField] private float delayToShowItemPopup = 2;
    [SerializeField] private Animator animator;

    private void Start()
    {
        inventory = new Dictionary<ItemConfig, int>()
        {
            {regularKeyConfig, 0},
            {blueKeyConfig, 0},
            {orangeKeyConfig, 0},
            {redKeyConfig, 0},
            {bossKeyConfig, 0}
        };

        UpdateInvetoryUI();
        collectionDelay = new WaitForSeconds(0.4f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag(collectableTag) && canCollect)
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

    public int CheckQty(ItemConfig item)
    {
        return inventory[item];
    }

    public void GetItem(ItemConfig item)
    {
        StartCoroutine(GetItemWithDelay(item));
    }

    private IEnumerator GetItemWithDelay(ItemConfig item)
    {
        float fakeGrabbingAnimationDelay = 0.3f;
        stateMachine.ChangeState(typeof(PlayerReceivingItemState));
        animator.SetBool("Pushing", true);

        yield return new WaitForSeconds(fakeGrabbingAnimationDelay);
        animator.SetBool("Pushing", false);

        yield return new WaitForSeconds(delayToShowItemPopup - fakeGrabbingAnimationDelay);

        itemPopup.ShowPopup(item.name, item.description, item.inventorySprite, item.tint);

        if (item.name == "Shield")
        {
            GetComponentInChildren<PlayerNotActingState>().canDefend = true;
            yield break;
        }

        inventory[item]++;
        UpdateInvetoryUI();
    }

    public Dictionary<ItemConfig, int> GetInventory()
    {
        return inventory;
    }

    public bool UseItem(ItemConfig item)
    {
        return true;
        int keysAmount = inventory[item];
        if (keysAmount > 0)
        {
            inventory[item]--;
            UpdateInvetoryUI();
            return true;
        }
        return false;
    }

    private void UpdateInvetoryUI()
    {
        int lastKeyTypeFinalIndex = 0;
        foreach (ItemConfig item in inventory.Keys)
        {
            lastKeyTypeFinalIndex += ShowKeysOfType(lastKeyTypeFinalIndex, item);
        }
        for (int i = lastKeyTypeFinalIndex; i < keyImages.Count; i++)
        {
            keyImages[i].gameObject.SetActive(false);
        }
    }

    private int ShowKeysOfType(int lastKeyTypeFinalIndex, ItemConfig item)
    {
        var count = inventory[item];
        for (int i = 0 ; i < count; i++)
        {
            int currIndex = lastKeyTypeFinalIndex + i;
            keyImages[currIndex].gameObject.SetActive(true);
            keyImages[currIndex].sprite = item.HudSprite;
            keyImages[currIndex].color = item.tint;
        }
        return count;
    }
}