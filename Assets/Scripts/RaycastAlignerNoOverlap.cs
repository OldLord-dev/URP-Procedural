using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastAlignerNoOverlap : MonoBehaviour
{
    public TagsSet prefabTags;
    public float raycastDistance = 100f;
    public float overlapTestBoxSize = 1f;
    public LayerMask spawnedObjectLayer;
    public Vector3 offset = new Vector3(0, 0.2f, 0);
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
            
            if (numberOfCollidersFound == 0)
            {
                Pick(hit.point, spawnRotation);
                return;
            }
        }
    }
    void Pick(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, prefabTags.Tags.Length);
        GameObject go = Pool.singleton.Get(prefabTags.Tags[randomIndex]);
        if (go != null)
        {
            go.transform.position = positionToSpawn - offset;
            go.transform.rotation = Quaternion.identity;
            go.SetActive(true);
        }
    }
}
