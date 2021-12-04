using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDescriptionPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image iconImage;
    [SerializeField] private GameObject visualsParent;
    [SerializeField] private float delayToAllowClosePopup = 0;
    [SerializeField] private GameObject animatedArrow;

    [HideInInspector] public bool canClosePopup;

    public void ShowPopup(string title, string description, Sprite icon, Color iconColor)
    {
        StartCoroutine(TimerToAllowClosePopup());
        visualsParent.SetActive(true);
        nameText.text = title;
        descriptionText.text = description;
        iconImage.sprite = icon;
        iconImage.color = iconColor;
    }

    IEnumerator TimerToAllowClosePopup()
    {
        canClosePopup = false;
        animatedArrow.SetActive(false);
        yield return new WaitForSeconds(delayToAllowClosePopup);
        animatedArrow.SetActive(true);
        canClosePopup = true;
    }

    public void HidePopup()
    {
        visualsParent.SetActive(false);
    }
}