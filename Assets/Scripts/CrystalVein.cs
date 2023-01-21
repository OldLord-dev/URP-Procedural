using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrystalVein : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> crystals= new List<GameObject>();
    private List<GameObject> crystalsTransform = new List<GameObject>();
    public GameObject nagroda;
    int hitCount = 0;
    bool block;
    private void OnEnable()
    {
        crystalsTransform = crystals;
    }
    public void OnPickaxeHit()
    {
        if (hitCount == 4)
        {
            crystals[crystals.Count - 1].AddComponent<Rigidbody>();
           // crystals[crystals.Count - 1].layer = 9;
            StartCoroutine(Wait2Seconds());
            hitCount = 0;
        }else
        hitCount++;
        Debug.Log(hitCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            if (!block)
            {
                OnPickaxeHit();
                block = true;
            }
        }     
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            block = false;
        }
    }
    IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2);
        Instantiate(nagroda, crystals[crystals.Count - 1].transform.position,Quaternion.identity);
        Instantiate(nagroda, crystals[crystals.Count - 1].transform.position, Quaternion.identity);
        Instantiate(nagroda, crystals[crystals.Count - 1].transform.position, Quaternion.identity);
        crystals[crystals.Count - 1].SetActive(false);
        crystals.Remove(crystals[crystals.Count - 1]);
    }
}
