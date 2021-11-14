using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ItemConfig", fileName = "ItemConfig")]
public class ItemConfig : ScriptableObject
{
    public string name;
    public string description;
    public Sprite inventorySprite;
    public Sprite HudSprite;
    public Color tint;
}