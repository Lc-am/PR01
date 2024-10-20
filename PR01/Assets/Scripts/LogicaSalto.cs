using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaSalto : MonoBehaviour
{
    public playerController playerController;

    private void OnTriggerStay(Collider other)
    {
        playerController.puedoSaltar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        playerController.puedoSaltar = false;
    }

}
