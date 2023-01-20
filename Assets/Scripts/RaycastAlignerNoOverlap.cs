﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastAlignerNoOverlap : MonoBehaviour
{
    public GameObject[] itemsToPickFrom;
    public TagsSet prefabTags;
    public float raycastDistance = 100f;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;
    public Vector3 offset = new Vector3(0, 0.2f, 0);
    public int k=0;
   // public string prefabTag;
    void OnEnable()
    {
        PositionRaycast();
    }

    void PositionRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {

            Quaternion spawnRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            Vector3 overlapTestBoxScale = new Vector3(overlapTestBoxSize, overlapTestBoxSize, overlapTestBoxSize);
            Collider[] collidersInsideOverlapBox = new Collider[1];
            int numberOfCollidersFound = Physics.OverlapBoxNonAlloc(hit.point, overlapTestBoxScale, collidersInsideOverlapBox, spawnRotation, spawnedObjectLayer);

           // Debug.Log("number of colliders found " + numberOfCollidersFound);
            
            if (numberOfCollidersFound == 0)
            {
                //Debug.Log("spawned robot");
                Pick(hit.point, spawnRotation);
                return;
            }
        }
    }

    void Pick(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, prefabTags.Tags.Length);
        GameObject tree = Pool.singleton.Get(prefabTags.Tags[randomIndex]);
        if (tree != null)
        {
            tree.transform.position = positionToSpawn - offset;
            tree.transform.rotation = Quaternion.identity;
            tree.SetActive(true);
        }
        //GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn-offset, Quaternion.identity);
    }
}
