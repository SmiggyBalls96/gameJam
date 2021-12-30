using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class Item
{
    public enum ItemType
    {
        Sword,
        Axe,
        RecallPotion,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
        default:
        case ItemType.RecallPotion:     return ItemAssets.Instance.recallPotionSprite;
        case ItemType.Sword:            return ItemAssets.Instance.swordSprite;
        case ItemType.Axe:              return ItemAssets.Instance.battleAxeSprite;
        }
    }
}
