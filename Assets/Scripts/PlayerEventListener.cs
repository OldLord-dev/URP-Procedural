using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventListener : MonoBehaviour
{
    Animator anim;

    [SerializeField]
    private BoxCollider boxCollider;
    Collider coll;
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
        anim.SetBool("CanPickUp", false);
        coll.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            coll = other;
            anim.SetBool("CanPickUp", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            anim.SetBool("CanPickUp", false);

        }
    }


    public void TurnOnCollider()
    {
        boxCollider.enabled = true;
    }
    public void OnAnimationEnd()
    {
        boxCollider.enabled = false;
    }
}
