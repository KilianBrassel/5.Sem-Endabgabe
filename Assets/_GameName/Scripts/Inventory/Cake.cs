using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cake : MonoBehaviour, ICollectible
{
    public static event HandleCakecollected OnCakeCollected;
    public delegate void HandleCakecollected(ItemData itemData);
    public ItemData cakeData;
    public void Collect()
    {
        Destroy(gameObject);
        OnCakeCollected?.Invoke(cakeData);

    }
}
