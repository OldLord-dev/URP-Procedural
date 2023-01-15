using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventListener : MonoBehaviour
{
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }
    public void AnimationDone()
    {
        anim.SetBool("PickUp", false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            anim.SetBool("CanPickUp", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            anim.SetBool("CanPickUp", false);
        }
    }
}
