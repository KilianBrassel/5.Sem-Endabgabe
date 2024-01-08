using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using _GameName.Scripts.InventorySystem;


public class Cake : MonoBehaviour, ICollectible
{
    public static event HandleCakecollected OnCakeCollected;
    public delegate void HandleCakecollected(ItemData itemData);
    public ItemData cakeData;

    public void OnTrigeggerEnter(Collider collision)
    {
        Collect();
    }
    public void Collect()
    {
        Destroy(gameObject);
        OnCakeCollected?.Invoke(cakeData);

    }
}
