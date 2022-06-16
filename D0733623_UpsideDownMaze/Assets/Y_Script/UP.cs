using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UP : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "XR Rig走動版")
        {
            animator.SetBool("UP", true);
            animator.SetBool("DOWN", false);
        }
        else
        {
            animator.SetBool("UP", false);
            animator.SetBool("DOWN", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "XR Rig走動版")
        {
            animator.SetBool("UP", false);
            animator.SetBool("DOWN", true);
        }
        else
        {
            animator.SetBool("UP", true);
            animator.SetBool("DOWN", false);
        }
    }
}
