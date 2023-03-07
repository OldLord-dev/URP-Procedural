using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalItem : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.collider.CompareTag("Rock"))
            StartCoroutine(Wait2Seconds());
    }

    private void OnDisable()
    {
        rb.isKinematic = true;
    }
    private void OnEnable()
    {
        rb.isKinematic = false;
    }
    IEnumerator Wait2Seconds()
    {
        yield return new WaitForSeconds(1);
        rb.isKinematic = true;
    }
}
