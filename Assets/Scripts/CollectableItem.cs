using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefabsSet;
    int randomIndex;
    private void OnEnable()
    {
        randomIndex = Random.Range(0, prefabsSet.Length);
        prefabsSet[randomIndex].SetActive(true);
    }

    private void OnDisable()
    {
        prefabsSet[randomIndex].SetActive(false);
    }


}
