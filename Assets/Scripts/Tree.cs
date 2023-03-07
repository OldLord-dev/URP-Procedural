using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tree : MonoBehaviour
{

    private List<(Vector3, Quaternion)> transformList = new List<(Vector3, Quaternion)>();
    [SerializeField]
    private TagsSet nagroda;
    private int hitCount = 0;
    private bool block;
    private void Start()
    {
            transformList.Add((this.transform.localPosition, this.transform.localRotation));
    }
    private void OnDisable()
    {
        int i = 0;
        foreach (var (pos, rot) in transformList)
        {
            this.transform.localPosition = pos;
            this.transform.localRotation = rot;
            //this.gameObject.SetActive(true);
            //Destroy(crystals[i].GetComponent<Rigidbody>());
            i++;
        }
    }
    private void OnEnable()
    {
        //crystalfLeft = crystals.Count;
    }
    private void OnPickaxeHit()
    {
        if (hitCount == 4)
        {
            //crystals[crystalfLeft - 1].AddComponent<Rigidbody>();
            StartCoroutine(Wait2Seconds());
            hitCount = 0;
        }
        else
            hitCount++;
        Debug.Log(hitCount);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
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
        if (other.CompareTag("Axe"))
        {
            StartCoroutine(Wait1Seconds());
        }
    }
    IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(10);
        for (int i = 0; i < Random.Range(1, 4); i++)
        {
            GameObject item = Pool.singleton.Get(nagroda.Tags[0]);
            if (item != null)
            {
                item.transform.position = this.transform.position;
                item.transform.rotation = Quaternion.identity;
                item.SetActive(true);
            }
        }
        this.gameObject.SetActive(false);
    }

    IEnumerator Wait1Seconds()
    {
        yield return new WaitForSeconds(1);
        block = false;
    }
}
