using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Preciso Abrir");
        animator.SetBool("close", true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Preciso Fechar");
        animator.SetBool("close", false);
    }
}
