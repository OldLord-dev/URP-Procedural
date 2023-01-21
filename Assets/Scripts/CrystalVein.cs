using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CrystalVein : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> crystals= new List<GameObject>();
    private List<(Vector3, Quaternion)> transformList = new List<(Vector3, Quaternion)>();
    public GameObject nagroda;
    private int hitCount = 0;
    private bool block;
    private int crystalfLeft;
    private void Start()
    {
        foreach(GameObject go in crystals)
        {
            transformList.Add((go.transform.localPosition, go.transform.localRotation));
        }
    }
    private void OnDisable()
    {
        int i = 0;
        foreach (var (pos, rot) in transformList)
        {
            crystals[i].transform.localPosition = pos;
            crystals[i].transform.localRotation = rot;
            crystals[i].SetActive(true);
            Destroy(crystals[i].GetComponent<Rigidbody>());
            i++;
        }
    }
    private void OnEnable()
    {
        crystalfLeft = crystals.Count;
    }
    private void OnPickaxeHit()
    {
        if (hitCount == 4)
        {
            crystals[crystalfLeft - 1].AddComponent<Rigidbody>();
            StartCoroutine(Wait2Seconds());
            hitCount = 0;
        }
        else
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
            StartCoroutine(Wait1Seconds());
        }
    }
    IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(2);
        Instantiate(nagroda, crystals[crystalfLeft - 1].transform.position,Quaternion.identity);
        Instantiate(nagroda, crystals[crystalfLeft - 1].transform.position, Quaternion.identity);
        Instantiate(nagroda, crystals[crystalfLeft - 1].transform.position, Quaternion.identity);
        crystals[crystalfLeft - 1].SetActive(false);
        if(crystalfLeft>0)
            crystalfLeft--;
        if (crystalfLeft == 0)
            this.gameObject.SetActive(false);
    }

    IEnumerator Wait1Seconds()
    {
        yield return new WaitForSeconds(1);
        block = false;
    }
    }
