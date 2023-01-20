﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAreaSpawner : MonoBehaviour
{
    public GameObject itemToSpread;
    public int numItemsToSpawn = 10;
    public string spawnerTag;
    public float itemXSpread = 10;
    public float itemYSpread = 0;
    public float itemZSpread = 10;

    // Start is called before the first frame update
    public void StartSpawning()
    {
        for (int i = 0; i < numItemsToSpawn; i++)
        {
            SpreadItem();
        }
    }
    void SpreadItem()
    {
        Vector3 randPosition = new Vector3(Random.Range(-itemXSpread, itemXSpread), Random.Range(-itemYSpread, itemYSpread), Random.Range(-itemZSpread, itemZSpread)) + transform.position;
        GameObject spawner = Pool.singleton.Get(spawnerTag);
        if (spawner != null)
        {
            spawner.transform.position = randPosition;
            spawner.transform.rotation = itemToSpread.transform.rotation;
            spawner.SetActive(true);
            spawner.SetActive(false);
        }
        //GameObject clone = Instantiate(itemToSpread, randPosition, itemToSpread.transform.rotation);
    }
}
