using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public playerController playerController;

    private void OnTriggerEnter(Collider other)
    {
        playerController.isGrounded = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerController.isGrounded = false;
    }
}
