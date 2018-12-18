﻿using UnityEngine;

public class ChipSpawner : MonoBehaviour, IChipSpawner
{
    public void SpawnChip(GameObject prefab, Vector3 position, float scale)
    {
        var newItem = Instantiate(prefab, position, Quaternion.identity);
        //newItem.GetComponentInChildren<SpriteRenderer>().sprite = image;
        newItem.GetComponentInChildren<SpriteRenderer>().transform.localScale = new Vector3(scale, scale, 1);
    }
}
